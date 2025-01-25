using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dungeonmaker
{
    internal class DungeonMap
    {
        //default values, changed by get/setters
        private int _mapWidth = 11;
        private int _mapHeight = 11;
        private int _startX = 5;
        private int _startY = 5;
        private int _mainPathLength = 5;
        private int _tries = 1000;

        /// <summary>
        /// how wide the generated map should be
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
        /// how high the generated map should be
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
        /// x position of the start room
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
        /// y position of the start room
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
        /// length of the main Path
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
        /// Amount of tries the generateDungeonMap has before it returns null. Causes for that can f.e. be inputting a mainPathLength too large
        /// </summary>
        public int tries
        {
            get { return _tries; }
            set
            {
                if (value > 0)
                {
                    _tries = value;
                }
            }
        }

        private Tile[,]? map;

        public Tile[,]? getTiles()
        {
            if (map != null)
            {
                return map;
            }

            return null;
        }

        public Tile[,]? generateDungeonMap()
        {
            map = new Tile[_mapHeight, _mapWidth];

            //create basic path
            int lastTileX = _startX;
            int lastTileY = _startY; 
            int previousConnection = -1;

            for (int i = 0; i < _mainPathLength; i++)
            {
                bool movePossible;
                int direction;

                List<int> directions = new List<int>() { 0, 1, 2, 3 };

                do
                {
                    if (directions.Count == 0)
                    {
                        Console.WriteLine("we shat ourself");
                        return null;
                    }

                    movePossible = true;

                    Random random = new Random();
                    int num = random.Next(0, directions.Count);
                    direction = directions[num];
                    directions.RemoveAt(num);

                    //check if move in direction is possible
                    movePossible = movePossible && !(direction == 0 && (lastTileY == 0 || map[lastTileY-1,lastTileX] != null));
                    movePossible = movePossible && !(direction == 1 && (lastTileX == mapWidth - 1 || map[lastTileY,lastTileX+1] != null));
                    movePossible = movePossible && !(direction == 2 && (lastTileY == mapHeight - 1 || map[lastTileY + 1, lastTileX] != null));
                    movePossible = movePossible && !(direction == 3 && (lastTileX == 0 || map[lastTileY, lastTileX - 1] != null));
                } while (!movePossible);

                Console.WriteLine(direction);

                bool[] connections = new bool[4];
                if (previousConnection != -1)
                {
                    connections[previousConnection] = true;
                }
                connections[direction] = true;

                map[lastTileY, lastTileX] = new Tile(connections);

                //add "start" Attribute to first Tile
                if (i == 0)
                {
                    map[lastTileY, lastTileX].addAttribute("start");
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

