using System;
using System.Diagnostics;

namespace Dungeonmaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DungeonMap dungeon = new DungeonMap();
            dungeon.mapWidth = 111;
            dungeon.mapHeight = 111;
            dungeon.startX = 55;
            dungeon.startY = 55;
            dungeon.mainPathLength = 100;

            while (true)
            {
                Console.SetCursorPosition(0, 0);

                dungeon.generateDungeonMap();

                dungeon.visualize();

                Console.ReadKey();
            }
        }
    }
}