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
        public int _mapWidth = 11;
        public int _mapHeight = 11;
        public int _startX = 5;
        public int _startY = 5;
        public int _mainPathLength = 5;

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

        private Tile[,]? map;

        public Tile[,]? getTiles()
        {
            if (map != null)
            {
                return map;
            }

            return null;
        }

        public void createDungeonMap()
        {
            map = new Tile[_mapHeight, _mapWidth];

            //create basic path
            int lastTileX = startX;
            int lastTileY = startY;
            int previousConnection = -1;

            for (int i = 0; i < _mainPathLength; i++)
            {
                bool movePossible = true;
                int direction;

                do
                {
                    Random random = new Random();
                    direction = random.Next(0, 4);

                    //check if move in direction is possible
                    movePossible = movePossible && !(direction == 0 && (lastTileY == 0 || map[lastTileY-1,lastTileX] == null));
                    movePossible = movePossible && !(direction == 1 && (lastTileX == mapWidth - 1 || map[lastTileY,lastTileX+1] == null));
                    movePossible = movePossible && !(direction == 2 && (lastTileY == mapHeight - 1 || map[lastTileY + 1, lastTileX] == null));
                    movePossible = movePossible && !(direction == 3 && (lastTileX == 0 || map[lastTileY, lastTileX - 1] == null));

                } while (!movePossible);

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
                }
                else if (direction == 1)
                {
                    lastTileX = lastTileX + 1;
                }
                else if (direction == 2)
                {
                    lastTileY = lastTileY + 1;
                }
                else if (direction == 3)
                {
                    lastTileX = lastTileX - 1;
                }


            }
        }
    }
}

