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
            dungeon.mainPathLength = 25;
            dungeon.generateDungeonMap();

            dungeon.visualize();

            Console.WriteLine("Time: " + dungeon.creationTime);
            Console.WriteLine("Successfull: " + dungeon.creationSuccessfull);
            Console.WriteLine("Attempts: " + dungeon.neededTries + " of " + dungeon.maxTries);
        }
    }
}