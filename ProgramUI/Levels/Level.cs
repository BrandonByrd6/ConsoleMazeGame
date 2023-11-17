using System.Dynamic;
using ProgramUI.Levels.Rooms;

namespace ProgramUI.Levels;

public class Level
{
    // Way to Easily Load Levels

    // Hold some Number of Rooms
    public List<Room> Rooms { get; private set; }

    public int LevelNumber { get; private set; }

    public Level(int levelNumber, List<Room> rooms){
        LevelNumber = levelNumber;
        Rooms = rooms;
    }

    // Level Number 
}
