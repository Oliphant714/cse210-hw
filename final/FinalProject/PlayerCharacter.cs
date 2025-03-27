// Derived class for Player Characters
public class PlayerCharacter : Character
{
    public string ClassType { get; set; }
    public List<string> Abilities { get; set; }

    public PlayerCharacter(string name, int health, int attackPower, int defense, string classType)
        : base(name, health, attackPower, defense)
    {
        ClassType = classType;
        Abilities = new List<string>();
    }

    // Use ability in combat
    public void UseAbility(string ability)
    {
        Console.WriteLine($"{Name} uses ability: {ability}");
    }
}