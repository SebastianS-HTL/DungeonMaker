using System;

namespace Dungeonmaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DungeonMap dungeon = new DungeonMap();
            dungeon.mapWidth = 3;
            dungeon.mapHeight = 3;
            dungeon.startX = 1;
            dungeon.startY = 1;
            dungeon.mainPathLength = 5;
            dungeon.generateDungeonMap();

            dungeon.visualize();
        }
    }
}
