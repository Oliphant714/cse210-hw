// Derived class for Enemies
public class Enemy : Character
{
    public string EnemyType { get; set; }
    public int AggressionLevel { get; set; }

    public Enemy(string name, int health, int attackPower, int defense, string enemyType, int aggressionLevel)
        : base(name, health, attackPower, defense)
    {
        EnemyType = enemyType;
        AggressionLevel = aggressionLevel;
    }

    // Taunt method to provoke player
    public void Taunt()
    {
        Console.WriteLine($"{Name} taunts with aggression level {AggressionLevel}!");
    }
}