namespace ProgramUI;
class Program {
    static int Main(string[] args) {
        // Entry Point of our Application 
        // We need class to hold and Manage our Game
        //    => Defines the initalization of items
        //    => Starts the Game

        Game game = new Game();
        game.RunGame();

        return 0;
    }
}