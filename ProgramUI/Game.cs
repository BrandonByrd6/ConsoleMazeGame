using ProgramUI.Levels.Rooms;
using ProgramUI.Entites.Enemies;
namespace ProgramUI;


public class Game
{
    // List of Levels
    // Player
    // Handle Input -> from the User in some way.

    // Welcome(Start) Screen
    // You Lose/Win Screens
    // Taken Damage Screen -> Player Specific?  

    Room testing = new Room(RoomType.Up, "Testing 101", new List<Enemy>());

    public Game() {
        
    }

    public void Run() {
        //Get the Room the Player
        // Level.Rooms[player.Y][player.X].Render();
        testing.Render();
        

        
    }
}
