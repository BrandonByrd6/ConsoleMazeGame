using ProgramUI.Entites.Enemies;

namespace ProgramUI.Levels.Rooms;

public class Room
{
    // Opening Max 4

    // Know which walls have opennings ENUM, 16 possiblities
    public RoomType RoomType {get; private set;}
    public GoalType GoalType {get; private set;}

    // Falvor text -> Ex. what room looks like?
    private string _descriptiveText;

    // List of Enemies 
    public List<Enemy> Enemies {get; private set;}

    public Room(RoomType roomType, string descriptiveText, List<Enemy> enemies){
        RoomType = roomType;
        _descriptiveText = descriptiveText;
        Enemies = enemies;
        GoalType = GoalType.None; 
    }

    public Room(RoomType roomType, string descriptiveText){
        RoomType = roomType;
        _descriptiveText = descriptiveText;
        GoalType = GoalType.None;
    }

    public void setEnemyList(List<Enemy> enemies) {
        Enemies = enemies;
    }

    public void setGoalType(GoalType goalType) {
        GoalType = goalType;
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
        ShowMovementOptions();
    }

    private void ShowMovementOptions() {
        switch(RoomType){
                case RoomType.Up:
                    System.Console.WriteLine("Up\n");
                    break;

                case RoomType.UpDownLeft:
                    System.Console.WriteLine("Up,  Down,  Left\n");
                    break;

                case RoomType.UpDown:
                    System.Console.WriteLine("Up,  Down\n");
                    break;

                case RoomType.UpRight:
                    System.Console.WriteLine("Up,  Right\n");
                    break;

                case RoomType.UpLeft:
                    System.Console.WriteLine("Up,  Left\n");
                    break;

                case RoomType.UpDownRight:
                    System.Console.WriteLine("Up,  Down,  Right\n");
                    break;

                case RoomType.Down:
                    System.Console.WriteLine("Down\n");
                    break;

                case RoomType.DownRight:
                    System.Console.WriteLine("Down,  Right\n");
                    break;

                case RoomType.DownLeft:
                    System.Console.WriteLine("Down,  Left\n");
                    break;

                case RoomType.Left:
                    System.Console.WriteLine("Left\n");
                    break;

                case RoomType.Right:
                    System.Console.WriteLine("Right\n");
                    break;

                case RoomType.LeftRightDown:
                    System.Console.WriteLine("Left,  Right,  Down\n");
                    break;

                case RoomType.LeftRight:
                    System.Console.WriteLine("Left, Right\n");
                    break;

                case RoomType.LeftRightUp:
                    System.Console.WriteLine("Left,  Right,  Up\n");
                    break;

                case RoomType.All:
                    System.Console.WriteLine("Up, Down, Left, Right\n");
                    break;
        }

        if(Enemies.Count > 0) {
            System.Console.WriteLine("Or Attack\n");
        }
    }
}
