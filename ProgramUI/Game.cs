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
    }


    public void Run() {
        //Get the Room the Player
        // Level.Rooms[player.Y][player.X].Render();

    }
}
