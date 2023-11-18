using ProgramUI.Levels.Rooms;
using ProgramUI.Entites.Enemies;
using ProgramUI.Levels;
using ProgramUI.Entites;
using System.IO.Compression;
using System.Reflection.Metadata;
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
        // List<List<Room>> rooms = new List<List<Room>>{
        //     new List<Room>{
        //         new Room(RoomType.Down, "Foggy and empty Forset", new List<Enemy>()),
        //         new Room(RoomType.None, "", new List<Enemy>()),
        //         new Room(RoomType.None, "Foggy and empty Forset", new List<Enemy>()),
        //     },
        //     new List<Room>{
        //         new Room(RoomType.UpDownLeft, "You See a Branching Path ahead", new List<Enemy>()),
        //         new Room(RoomType.LeftRight, "Contining Straight", new List<Enemy>()),
        //         new Room(RoomType.LeftRight, "Contining Straight", new List<Enemy>()),
        //     },
        //     new List<Room>{
        //         new Room(RoomType.UpDown, "You See a Branching Path ahead", new List<Enemy>()),
        //         new Room(RoomType.None, "Contining Straight", new List<Enemy>()),
        //         new Room(RoomType.None, "Contining Straight", new List<Enemy>()),
        //     }
        // };

        //TODO: Load Levels from files 

        _levelManager = new LevelManager();

        List<Level> levels = new List<Level>{
            _levelManager.GenerateLevelFromFile("./ProgramUI/Assets/Test_1.Txt")
        };

        _levelManager.SetLevels(levels);
        int[] cords = _levelManager.findStart();
        if(cords != null) {
            _player.setCords(cords[1], cords[0]);
        }
    }


    public void Run() {
        Console.Clear();
        List<List<Room>> rooms = _levelManager.GetRooms();
        bool isRunning = true;
        while(isRunning) {
            if(_player.Health <= 0){
                YouLose();
            }
            System.Console.WriteLine($"{_player.Health} health, {_player.BaseDamage} damage \n" );
            Room currentRoom = rooms[_player.Y][_player.X];
            if(currentRoom.GoalType == GoalType.End) {
                YouWinLevel();
                PressAnyKey();
                if(_levelManager.ChangeToNextLevel() == false) {
                    YouWin();
                }
                int[] cords = _levelManager.findStart();
                if(cords != null) {
                    _player.setCords(cords[1], cords[0]);
                }
            }
            currentRoom.Render();
            //TODO: Function to handle input
            string userInput = Console.ReadLine();
            HandleInput(userInput);
            Console.Clear();
        }
    }

    public void HandleInput(string userInput) {
        switch(userInput.ToLower()) {
            case "up":
                ProposedMove(0, -1);
                break;
            case "down":
                ProposedMove(0, 1);
                break;
            case "left":
                ProposedMove(-1, 0);
                break;
            case "right":
                ProposedMove(+1, 0);
                break;
            case "attack":
                Attack();
                break;
            default:
                System.Console.WriteLine("invalid selection. please try again.");
                break;
        }
    }

    public void ProposedMove(int x_offset, int y_offset){
        if(_player.X + x_offset >= _levelManager.GetRooms()[1].Count-1 || _player.X + x_offset < 0) {
            return;
        }
        if(_player.Y + y_offset >= _levelManager.GetRooms().Count-1 || _player.Y + y_offset < 0) {
            return;
        }

        Room pRoom = _levelManager.GetRooms()[_player.Y + y_offset][_player.X + x_offset];
        if(pRoom.RoomType != RoomType.None) {
            _player.move(x_offset, y_offset);   
        }
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

    private void YouWinLevel()
    {
        System.Console.WriteLine("Congratulations! You have made it to the End of the Level\n\n Moving to the Next Level");
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

    private void Attack()
    {
        Room tempRoom = _levelManager.CurrentLevel.Rooms[_player.Y][_player.X];
        Enemy enemy = tempRoom.Enemies[0];
        _player.Health = _player.Health - enemy.BaseDamage;
        enemy.Health = enemy.Health - _player.BaseDamage;
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
