using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dungeonmaker
{
    public class DungeonMap
    {
        //default values, changed by get/setters
        private int _mapWidth = 11;
        private int _mapHeight = 11;
        private int _startX = 5;
        private int _startY = 5;
        private int _mainPathLength = 5;
        private int _maxTries = 10;

        public double _creationTime = -1;
        public bool _creationSuccessfull;
        public int _neededTries = 0;

        /// <summary>
        /// how long it took to generate your map
        /// </summary>
        public double creationTime
        {
            get { return _creationTime; }
        }

        /// <summary>
        /// was the creation successfull?
        /// </summary>
        public bool creationSuccessfull
        {
            get { return _creationSuccessfull; }
        }

        /// <summary>
        /// how many tries it took to generate your map
        /// </summary>
        public int neededTries
        {
            get { return _neededTries; }
        }

        /// <summary>
        /// how wide the generated map should be (default: 11)
        /// </summary>
        public int mapWidth
        {
            get { return _mapWidth; }
            set
            {
                if (value > 0)
                {
                    _mapWidth = value;
                }
            }
        }

        /// <summary>
        /// how high the generated map should be (default: 11)
        /// </summary>
        public int mapHeight
        {
            get { return _mapHeight; }
            set
            {
                if (value > 0)
                {
                    _mapHeight = value;
                }
            }
        }

        /// <summary>
        /// zero indexed X position of the start room (default: 5)
        /// </summary>
        public int startX
        {
            get { return _startX; }
            set
            {
                if (value >= 0)
                {
                    _startX = value;
                }
            }
        }

        /// <summary>
        /// zero indexed Y position of the start room (default: 5)
        /// </summary>
        public int startY
        {
            get { return _startY; }
            set
            {
                if (value >= 0)
                {
                    _startY = value;
                }
            }
        }

        /// <summary>
        /// length of the main Path (default: 5)
        /// </summary>
        public int mainPathLength
        {
            get { return _mainPathLength; }
            set
            {
                if (value > 0)
                {
                    _mainPathLength = value;
                }
            }
        }

        /// <summary>
        /// Amount of tries the generateDungeonMap has before it returns null. Causes for that can f.e. be inputting a mainPathLength too large (default: 1000)
        /// </summary>
        public int maxTries
        {
            get { return _maxTries; }
            set
            {
                if (value > 0)
                {
                    _maxTries = value;
                }
            }
        }

        private Tile[,]? map;

        public Tile[,]? getTiles()
        {
            if (map == null)
            {
                return map;
            }

            return null;
        }

        public void visualize()
        {
            if (map == null)
            {
                Console.WriteLine("nothing to output");
                return;
            }

            string output = "";

            for (int i = 0; i < map.GetLength(0); i++)
            {
                string topL = "";
                string midL = "";
                string botL = "";

                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j] == null)
                    {
                        topL += "      ";
                        midL += "  <>  ";
                        botL += "      ";
                    }
                    else
                    {
                        topL += "  ";
                        if (map[i, j].getConnections()[0])
                        {
                            topL += "||  ";
                        }
                        else
                        {
                            topL += "    ";
                        }

                        if (map[i, j].getConnections()[3])
                        {
                            midL += "==";
                        }
                        else
                        {
                            midL += "  ";
                        }
                        midL += "[]";
                        if (map[i, j].getConnections()[1])
                        {
                            midL += "==";
                        }
                        else 
                        {
                            midL += "  ";
                        }

                        botL += "  ";
                        if(map[i, j].getConnections()[2])
                        {
                            botL += "||  ";
                        }
                        else
                        {
                            botL += "    ";
                        }
                    }
                }

                output += topL + "\n";
                output += midL + "\n";
                output += botL + "\n";
            }

            Console.WriteLine(output);
        }

        public Tile[,]? generateDungeonMap()
        {
            Tile[,]? t = null;
            _neededTries = 0;

            Stopwatch stoppy = Stopwatch.StartNew();

            for (int i = 0;i < maxTries && t == null; i++) { t = tryDungeonMapGen(); _neededTries++; }

            stoppy.Stop();
            _creationTime = stoppy.ElapsedTicks * (1000.0 / Stopwatch.Frequency);

            _creationSuccessfull = t != null;
            if(t == null)
            {
                map = null;
                return null;
            }
            return map;
        }

        private Tile[,]? tryDungeonMapGen()
        {
            map = new Tile[_mapHeight, _mapWidth];

            //create basic path
            int lastTileX = _startX;
            int lastTileY = _startY;
            int previousConnection = -1;

            for (int i = 0; i < _mainPathLength; i++)
            {
                bool movePossible;
                int direction = -1;

                List<int> directions = new List<int>() { 0, 1, 2, 3 };

                if (i != _mainPathLength - 1)
                {
                    do
                    {
                        if (directions.Count == 0)
                        {
                            //error, no place to go
                            return null;
                        }

                        movePossible = true;

                        Random random = new Random();
                        int num = random.Next(0, directions.Count);
                        direction = directions[num];
                        directions.RemoveAt(num);

                        //check if move in direction is possible
                        movePossible = movePossible && !(direction == 0 && (lastTileY == 0 || map[lastTileY - 1, lastTileX] != null));
                        movePossible = movePossible && !(direction == 1 && (lastTileX == mapWidth - 1 || map[lastTileY, lastTileX + 1] != null));
                        movePossible = movePossible && !(direction == 2 && (lastTileY == mapHeight - 1 || map[lastTileY + 1, lastTileX] != null));
                        movePossible = movePossible && !(direction == 3 && (lastTileX == 0 || map[lastTileY, lastTileX - 1] != null));
                    } while (!movePossible);
                }

                bool[] connections = new bool[4];
                if (previousConnection != -1)
                {
                    connections[previousConnection] = true;
                }
                if (direction != -1)
                {
                    connections[direction] = true;
                }

                map[lastTileY, lastTileX] = new Tile(connections);

                //add "start" Attribute to first Tile
                if (i == 0)
                {
                    map[lastTileY, lastTileX].AddAttribute("start");
                }

                //add "end" Attribute to last Tile
                if (direction == -1)
                {
                    map[lastTileY, lastTileX].AddAttribute("end");
                }

                if (direction == 0)
                {
                    lastTileY = lastTileY - 1;
                    previousConnection = 2;
                }
                else if (direction == 1)
                {
                    lastTileX = lastTileX + 1;
                    previousConnection = 3;
                }
                else if (direction == 2)
                {
                    lastTileY = lastTileY + 1;
                    previousConnection = 0;
                }
                else if (direction == 3)
                {
                    lastTileX = lastTileX - 1;
                    previousConnection = 1;
                }
            }

            return map;
        }
    }
}

