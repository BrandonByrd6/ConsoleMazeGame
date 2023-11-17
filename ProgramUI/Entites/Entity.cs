namespace ProgramUI.Entites;

public abstract class Entity
{
    //Name 
    public string Name { get; protected set; }
    //Health   
    public int Health { get; protected set; }
    //base Damage
    public int BaseDamage { get; protected set; }

    public Entity(string name, int health, int baseDamage) {
        Name = name;
        Health = health;
        BaseDamage = baseDamage;
    }
}
