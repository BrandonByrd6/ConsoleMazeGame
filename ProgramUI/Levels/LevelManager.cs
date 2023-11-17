using ProgramUI.Levels.Rooms;

namespace ProgramUI.Levels;

public class LevelManager
{
    // Hold a List of levels
    public List<Level> Levels {get; private set; }

    public Level CurrentLevel {get; private set; }

    public LevelManager(List<Level> levels){
        Levels = levels;
         int newLevelNumber = 1;
        foreach (Level level in Levels)
        {
            if (level.LevelNumber == newLevelNumber)
            {
                CurrentLevel = level;
                break;
            }
        }
    }

    //Currently Level
    
    //Method to Change Level
    public void ChangeLevel(){
        int newLevelNumber = CurrentLevel.LevelNumber + 1;
        foreach (Level level in Levels)
        {
            if (level.LevelNumber == newLevelNumber)
            {
                CurrentLevel = level;
                break;
            }
        }
    }

    //Method to get current level list of rooms
    public List<List<Room>> GetRooms(){
        return CurrentLevel.Rooms;
    }

    // TODO: A way to Programtically Build Levels from a file. 
}
