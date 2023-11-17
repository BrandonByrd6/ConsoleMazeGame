using ProgramUI.Entites.Enemies;

namespace ProgramUI.Levels.Rooms;

public class Room
{
    // Opening Max 4

    // Know which walls have opennings ENUM, 16 possiblities
    public RoomType RoomType {get; private set;}

    // Falvor text -> Ex. what room looks like?
    private string _descriptiveText;

    // List of Enemies 
    public List<Enemy> Enemies {get; private set;}

    public Room(RoomType roomType, string descriptiveText, List<Enemy> enemies){
        RoomType = roomType;
        _descriptiveText = descriptiveText;
        Enemies = enemies;
    }

    //Need Render Function -> display Falvor Text to the Screen/The the Player know if there are enemies.
    //   => Wait for Input
    public void Render() {
        if(Enemies.Count == 0){
            System.Console.WriteLine(_descriptiveText+'\n');
            
        } else {
            System.Console.WriteLine(_descriptiveText+"\n");
            System.Console.WriteLine($"There is {Enemies.Count} enemy in the room");
        }
    }

    private void ShowMovementOptions() {
        switch(RoomType){
                case RoomType.Up:
                    System.Console.WriteLine("1. Up\n");
                    break;

                case RoomType.UpDownLeft:
                    System.Console.WriteLine("1. Up, 2. Down, 3. Left\n");
            }
    }
}
