using ProgramUI.Entites.Enemies;
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
    public Level GenerateLevelFromFile(string Path)
    {
        bool map = false;
        bool enemy = false;

        int lNumber = 0;
        int width = 0;
        int height = 0;
        List<List<Room>> rooms = new List<List<Room>>();

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
                    string[] temp = lines[y].Split(',');
                    map_array[x] = temp;
                    x++;
                }
                map = false;
                // foreach(string[] mline in map_array) {
                //    foreach(string mitem in mline) {
                //         System.Console.WriteLine(mitem+",");
                //    }
                //    System.Console.WriteLine("\n");
                // }
                rooms = GenerateRooms(map_array);
                i = i + height-1;
            }

            if(enemy == true) {
                int maxMap = i + height;
                string[][] enemy_array = new string[height][];
                int x = 0;
                for (int y = i; y < maxMap; y++)
                {
                    string[] temp = lines[y].Split(',');
                    enemy_array[x] = temp;
                    x++;
                }
                enemy = false;
                GenerateEnemies(rooms, enemy_array);
                i = i + height-1;
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
            } else if (tokens[0] == "Enemies") {
                enemy = true;
            }
        }

        return new Level(lNumber, rooms);
    }

    private void GenerateEnemies(List<List<Room>> rooms, string[][] enemy_array)
    {
        for (int y = 0; y < enemy_array.Length; y++)
        {
            for (int x = 0; x < enemy_array[y].Length; x++)
            {
                List<Enemy> enemies = ParseEnemies(enemy_array[y][x]);
                rooms[y][x].setEnemyList(enemies);
            }
        }
    }

    private List<Enemy> ParseEnemies(string v)
    {
        string [] enemiesString = v.Split(';');
        List<Enemy> enemies = new List<Enemy>();
        foreach (string e in enemiesString){
            if(e != "0") {
                string [] enemyString = e.Split(':');
                enemies.Add(new Enemy(enemyString[0], int.Parse(enemyString[1]), int.Parse(enemyString[2])));
            }
        }
        return enemies;
    }

    private List<List<Room>> GenerateRooms(string[][] map)
    {
        List<List<Room>> rooms = new List<List<Room>>();
        for (int y = 0; y < map.Length; y++)
        {
            List<Room> roomLine = new List<Room>();
            for (int x = 0; x < map[y].Length; x++)
            {
                string descriptiveText = "";
                if(GetRoomNumber(map[y][x]) != 0){
                    string[] roomSplit = map[y][x].Split(':');
                    if(roomSplit.Length > 1) {
                        descriptiveText = roomSplit[1];
                    }
                }
                RoomType roomType = GetRoomType(x, y, map);
                roomLine.Add(new Room(roomType, descriptiveText));
            }
            rooms.Add(roomLine);
        }
        return rooms;
    }

    private int GetRoomNumber(string room)
    {
        return int.Parse(room.Split(':')[0]);
    }
    private RoomType GetRoomType(int x, int y, string[][] map)
    {
        int currentRoom = GetRoomNumber(map[y][x]);
        int roomRight = 0;
        if(x + 1 < map[y].Length) {
            roomRight = GetRoomNumber(map[y][x+1]);
        }

        int roomLeft = 0;
        if(x - 1 > 0) {
            roomLeft =  GetRoomNumber(map[y][x-1]);
        }

        int roomBelow = 0;
        if(y + 1 < map.Length) {
            roomBelow = GetRoomNumber(map[y+1][x]);
        }

        int roomAbove = 0;
        if(y - 1 > 0) {
            roomAbove =  GetRoomNumber(map[y-1][x]);
        }


        if (currentRoom == 0)
        {
            return RoomType.None;
        }

        if (roomAbove == 1 && roomBelow == 1 && roomLeft == 1 && roomRight == 1)
        {
            return RoomType.All;
        }
        else if (roomAbove == 1 && roomBelow == 1 && roomLeft == 1)
        {
            return RoomType.UpDownLeft;
        }
        else if (roomAbove == 1 && roomBelow == 1 && roomRight == 1)
        {
            return RoomType.UpDownRight;
        }
        else if (roomAbove == 1 && roomLeft == 1 && roomRight == 1)
        {
            return RoomType.LeftRightUp;
        }
        else if (roomBelow == 1 && roomLeft == 1 && roomRight == 1)
        {
            return RoomType.LeftRightDown;
        }
        else if (roomAbove == 1 && roomLeft == 1)
        {
            return RoomType.UpLeft;
        }
        else if (roomAbove == 1 && roomBelow == 1)
        {
            return RoomType.UpDown;
        }
        else if (roomAbove == 1 && roomRight == 1)
        {
            return RoomType.UpRight;
        }
        else if (roomBelow == 1 && roomLeft == 1)
        {
            return RoomType.DownLeft;
        }
        else if (roomBelow == 1 && roomRight == 1)
        {
            return RoomType.DownRight;
        }
        else if (roomLeft == 1 && roomRight == 1)
        {
            return RoomType.LeftRight;
        }
        else if (roomRight == 1)
        {
            return RoomType.Right;
        }
        else if (roomLeft == 1)
        {
            return RoomType.Left;
        }
        else if (roomBelow == 1)
        {
            return RoomType.Down;
        }
        else if (roomAbove == 1)
        {
            return RoomType.Up;
        }
        else
        {
            return RoomType.None;
        }
    }
}
