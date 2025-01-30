# DungeonMaker

This project is a 2D dungeon generator written in C#. It introduces 2 custom classes:
- `DungeonMap`: Handles the creation and management of the dungeon map.
- `Tile`: Represents individual tiles in the dungeon, storing their connections to each other

## Usage
Here's an example of how to create a new `DungeonMap` and generate a dungeon:

```csharp
DungeonMap dungeon = new DungeonMap();
dungeon.generateDungeonMap();

Tile[,] tiles = dungeon.getTiles();
```

## Customisation
A `DungeonMap` has multiple propertys for customizing the result:
- `mapWidth`: Width of your desired map
- `mapHeight`: Height of your desired map
- `startX`: X position of the starting room **(zero indexed)**
- `startY`: Y position of the starting room **(zero indexed)**
- `mainPathLength`: Length of the path from the start to the end room
- `maxTries`: The amount of times the algorythm can start over if it gets stuck in a corner
  
All of the above propertys have default values assigned, that can be changed before creating the map:
```csharp
DungeonMap dungeon = new DungeonMap();
dungeon.mapWidth = 3;
dungeon.mapHeight = 3;
dungeon.startX = 1;
dungeon.startY = 1;
dungeon.mainPathLength = 9;
dungeon.generateDungeonMap();

Tile[,] tiles = dungeon.getTiles();
```

## Visualization
Using the method `visualize()` implemented in  `DungeonMap`, a simple representation of the dungeon is printed to the console:
```csharp
DungeonMap dungeon = new DungeonMap();
dungeon.mapWidth = 5;
dungeon.mapHeight = 5;
dungeon.startX = 2;
dungeon.startY = 2;
dungeon.mainPathLength = 10;
dungeon.generateDungeonMap();

dungeon.visualize();
```

![alt text](pics/visualize().png)

*console output of the code above*
