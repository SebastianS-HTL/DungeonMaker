using System;
using System.Diagnostics;

namespace Dungeonmaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DungeonMap dungeon = new DungeonMap();
            dungeon.mapWidth = 11;
            dungeon.mapHeight = 11;
            dungeon.startX = 5;
            dungeon.startY = 5;
            dungeon.mainPathLength = 10;

            while (true)
            {
                Console.SetCursorPosition(0, 0);

                dungeon.generateDungeonMap();

                dungeon.visualize();

                Console.WriteLine(dungeon.creationtime);

                Console.ReadKey();
            }
        }
    }
}