public class Enemy : Character
{
    private string _enemyType; // E.g., Goblin, Orc, Dragon, etc.

    public string EnemyType => _enemyType;

    public Enemy(string name, int level, int hitPoints, int armorClass,
                 int strength, int dexterity, int constitution,
                 int intelligence, int wisdom, int charisma,
                 int proficiencyBonus, string weaponDamageType, string enemyType)
        : base(name, level, hitPoints, armorClass, strength, dexterity, constitution,
               intelligence, wisdom, charisma, proficiencyBonus, weaponDamageType)
    {
        _enemyType = enemyType;
    }

    // Override to include enemy-specific abilities or traits (e.g., Breath Weapon for dragons)
    public void UseEnemyAbility()
    {
        if (_enemyType == "Dragon")
        {
            Console.WriteLine($"{Name} breathes fire!");
        }
        else if (_enemyType == "Goblin")
        {
            Console.WriteLine($"{Name} tries to ambush!");
        }
    }
}
