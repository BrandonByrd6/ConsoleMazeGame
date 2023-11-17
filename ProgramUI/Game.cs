using ProgramUI.Levels.Rooms;
using ProgramUI.Entites.Enemies;
using ProgramUI.Levels;
using ProgramUI.Entites;
using System.IO.Compression;
namespace ProgramUI;


public class Game
{
    // List of Levels
    private LevelManager _levelManager;

    // Player
    private Player _player;

    // Handle Input -> from the User in some way.

    // Welcome(Start) Screen
    public void RunGame()
    {
        RunApp();
    }


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
        // _levelManager.GenerateLevelFromFile("./ProgramUI/Assets/Test_1.Txt");
    }

    private void RunApp()
    {
        bool isRunning = true;
        while(isRunning)
        {
            System.Console.WriteLine("welcome to our game!\n" +
            "please enter the option you would like to select:\n"+
            "1. Start Game\n");
            // todo: leaderboard? select player/item/attacks?

            string userInput = Console.ReadLine()!.ToLower();

            switch (userInput)
            {
                case "1":
                case "start":
                    Run();
                    break;
                default:
                    System.Console.WriteLine("invalid selection. please try again.");
                    break;
            }

        }
    }

    private void Leaderboard()
    {
        System.Console.WriteLine("Leaderboard:\n" +
        "1. Jon\n" +
        "2. Jill\n" +
        "3. Steve\n");
    }

    private void YouWin()
    {
        System.Console.WriteLine("Congratulations! You have made it out of the maze!");
        Options();
    }

    private void YouLose()
    {
        // if(health = 0)   //todo ?
        System.Console.WriteLine("You died...");
        Options();
    }

    private void Options()
    {
        System.Console.WriteLine("Please select an option:\n" +
        "1. Start New Game\n" +
        "2. Exit");

        string selectedOption = Console.ReadLine()!.ToLower();

        switch (selectedOption)
        {
            case "1":
            case "start new game":
                PlayAgain();
                break;
            case "2":
            case "exit":
                Exit();
                break;
            default:
                System.Console.WriteLine("invalid selection. please try again.");
                break;
        }
    }

    private void PlayAgain()
    {
        RunApp();
    }

    private void Exit()
    {
        CloseApp();
    }

    private bool CloseApp()
    {
        System.Console.WriteLine("Thanks for playing");
        PressAnyKey();
        return false;
    }

    private void PressAnyKey()
    {
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
