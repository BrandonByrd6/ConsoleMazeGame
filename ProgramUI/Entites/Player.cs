using System.Security.Cryptography.X509Certificates;

namespace ProgramUI.Entites;

public class Player : Entity
{
    //x, y location
    public int X { get; private set; }
    public int Y { get; private set; }

    public Player(string name, int health, int baseDamage, int x, int y) :
        base(name, health, baseDamage)
    {
       X = x;
       Y = y;
    }

    public void move(int x_offset, int y_offset) {
        X = X + x_offset;
        Y = Y + y_offset;
    }

    public void setCords(int x, int y) {
        X = x;
        Y = y;
    }

    //TODO: Special Attack Functions
}
