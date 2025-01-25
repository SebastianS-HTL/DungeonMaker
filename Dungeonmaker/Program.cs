using System;

namespace Dungeonmaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DungeonMap dungeonMap = new DungeonMap();
            dungeonMap.mainPathLength = 1;
            var e = dungeonMap.generateDungeonMap();
            Console.WriteLine(e);
        }
    }
}
