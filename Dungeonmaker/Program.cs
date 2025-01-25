using System;

namespace Dungeonmaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DungeonMap dungeonMap = new DungeonMap();
            dungeonMap.mainPathLength = 100;
            dungeonMap.generateDungeonMap();
        }
    }
}
