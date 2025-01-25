namespace Dungeonmaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DungeonMap dungeonMap = new DungeonMap();
            MapSettings mapSettings = new MapSettings();
            mapSettings.height = 11;
            mapSettings.width = 11;
            mapSettings.startPosition = new Tuple<int, int> (5,5);

            
            
            Console.WriteLine(dungeonMap.createDungeonMap(mapSettings));
        }
    }
}
