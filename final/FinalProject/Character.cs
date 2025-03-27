// Base class for all characters
public class Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Defense { get; set; }

    public Character(string name, int health, int attackPower, int defense)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        Defense = defense;
    }

    // Method to reduce health when character takes damage
    public void TakeDamage(int damage)
    {
        int actualDamage = Math.Max(0, damage - Defense);
        Health -= actualDamage;
        Console.WriteLine($"{Name} takes {actualDamage} damage! Health: {Health}");
    }

    // Attack method returns attack power
    public int Attack()
    {
        return AttackPower;
    }

    // Check if the character is defeated
    public bool IsDefeated()
    {
        return Health <= 0;
    }
}