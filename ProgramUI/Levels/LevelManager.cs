using ProgramUI.Levels.Rooms;

namespace ProgramUI.Levels;

public class LevelManager
{
    // Hold a List of levels
    public List<Level> Levels { get; private set; }

    public Level CurrentLevel { get; private set; }

    public LevelManager(List<Level> levels)
    {
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
    public void ChangeToNextLevel()
    {
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
    public List<List<Room>> GetRooms()
    {
        return CurrentLevel.Rooms;
    }

    // TODO: A way to Programtically Build Levels from a file. \
    public void GenerateLevelFromFile(string Path)
    {
        bool map = false;

        int lNumber = 0;
        int width = 0;
        int height = 0;

        var lines = File.ReadAllLines(Path);
        for (int i = 0; i < lines.Count(); i++)
        {
            if (map == true)
            {
                int maxMap = i + height;
                string[][] map_array = new string[height][];
                int x = 0;
                for (int y = i; y < maxMap; y++)
                { 
                    string [] temp = lines[y].Split(',');
                    map_array[x] = temp;
                    x++;
                }
                map = false;
                foreach(string[] mline in map_array) {
                   foreach(string mitem in mline) {
                        System.Console.WriteLine(mitem+",");
                   }
                   System.Console.WriteLine("\n");
                }
            }

            string[] tokens = lines[i].Split(":");
            if (tokens[0] == "Level Number")
            {
                lNumber = int.Parse(tokens[1]);
            }
            else if (tokens[0] == "Width")
            {
                width = int.Parse(tokens[1]);
            }
            else if (tokens[0] == "Height")
            {
                height = int.Parse(tokens[1]);
            }
            else if (tokens[0] == "Map" && map == false)
            {
                map = true;
            }
        }
        System.Console.WriteLine(lNumber);
        System.Console.WriteLine(width);
        System.Console.WriteLine(height);
    }
}
