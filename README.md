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
- `creationTime`: the time it took to generate your `DungeonMap` (in milliseconds)
- `creationSuccessfull`: was the creation of your Dungeon successful
- `neededAttempts`: how many of the `maxTries` were used
  
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

## Read-Only Properties
These properties cannot be modified and only return meaningfull values after dungeon generation:

- `creationTime`: the time it took to generate your `DungeonMap` (in milliseconds)
- `creationSuccessfull`: was the creation of your Dungeon successful
- `neededAttempts`: how many of the `maxTries` were used
  
Example of how to use them:
```csharp
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
```

## Visualization
The method `visualize()` implemented in  `DungeonMap` prints the dungeon to the console:
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

*possible console output of the code above*
