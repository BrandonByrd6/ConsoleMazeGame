using ProgramUI.Levels.Rooms;
using ProgramUI.Entites.Enemies;
using ProgramUI.Levels;
using ProgramUI.Entites;
namespace ProgramUI;


public class Game
{
    // List of Levels
    private LevelManager _levelManager;

    // Player
    private Player _player;

    // Handle Input -> from the User in some way.

    // Welcome(Start) Screen
    // You Lose/Win Screens
    // Taken Damage Screen -> Player Specific?  

    // Room testing = new Room(RoomType.Up, "Testing 101", new List<Enemy>());

    public Game() {
        _player = new Player("Player", 10, 2, 0, 0);

        /*
            . 0 0
            . . .
            . 0 0
        */
        List<List<Room>> rooms = new List<List<Room>>{
            new List<Room>{
                new Room(RoomType.Down, "Foggy and empty Forset", new List<Enemy>()),
                new Room(RoomType.None, "", new List<Enemy>()),
                new Room(RoomType.None, "Foggy and empty Forset", new List<Enemy>()),
            },
            new List<Room>{
                new Room(RoomType.UpDownLeft, "You See a Branching Path ahead", new List<Enemy>()),
                new Room(RoomType.LeftRight, "Contining Straight", new List<Enemy>()),
                new Room(RoomType.LeftRight, "Contining Straight", new List<Enemy>()),
            },
            new List<Room>{
                new Room(RoomType.UpDown, "You See a Branching Path ahead", new List<Enemy>()),
                new Room(RoomType.None, "Contining Straight", new List<Enemy>()),
                new Room(RoomType.None, "Contining Straight", new List<Enemy>()),
            }
        };

        List<Level> levels = new List<Level>{
            new Level(1, rooms),
            new Level(2, rooms),
        };

        _levelManager = new LevelManager(levels);
    }


    public void Run() {
        List<List<Room>> rooms = _levelManager.GetRooms();

        // System.Console.WriteLine(_levelManager.CurrentLevel.LevelNumber);
        // rooms[0][0].Render();
        // rooms[1][0].Render();
        // rooms[1][1].Render();
        // rooms[1][2].Render();
        // rooms[2][0].Render();
        // _levelManager.ChangeToNextLevel();
        // System.Console.WriteLine(_levelManager.CurrentLevel.LevelNumber);
        // rooms[0][0].Render();
        // rooms[1][0].Render();
        // rooms[1][1].Render();
        // rooms[1][2].Render();
        // rooms[2][0].Render();
        _levelManager.GenerateLevelFromFile("./ProgramUI/Assets/Test_1.Txt");
    }
}
