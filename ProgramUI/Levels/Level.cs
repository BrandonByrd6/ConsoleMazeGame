using System.Dynamic;
using ProgramUI.Levels.Rooms;

namespace ProgramUI.Levels;

public class Level
{
    // Hold some Number of Rooms
    public List<List<Room>> Rooms { get; private set; }

    public int LevelNumber { get; private set; }

    public Level(int levelNumber, List<List<Room>> rooms){
        LevelNumber = levelNumber;
        Rooms = rooms;
    }

    // Level Number 
}

// List of List example
/*
list = [ 1, 
  2,
  3,
]

list2d = [
    [1, 2, 3, 4],
    [5, 6, 7, 8],
    [9, 10, 11, 12],
]

list[2] == 3
     y  x
list2d[1][1] == 6

list2d[2][3] == 12 



*/