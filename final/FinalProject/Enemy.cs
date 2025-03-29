public class Enemy : Character
{
    private string _enemyType;
    private int _challengeRating;

    public string EnemyType => _enemyType;
    public int ChallengeRating => _challengeRating;

    public Enemy(string name, int level, int hitPoints, int armorClass,
                 AbilityScores abilities, int proficiencyBonus, 
                 string weaponDamageType, string enemyType, int challengeRating)
        : base(name, level, hitPoints, armorClass, abilities, proficiencyBonus, weaponDamageType)
    {
        _enemyType = enemyType;
        _challengeRating = challengeRating;
    }

    public void Attack(Character target)
    {
        int attackRoll = Dice.Roll(20) + ProficiencyBonus + Abilities.StrengthModifier;
        Console.WriteLine($"{Name} attacks {target.Name} with a roll of {attackRoll}!");

        if (attackRoll >= target.ArmorClass)
        {
            int damage = Dice.Roll(8) + Abilities.StrengthModifier;
            target.TakeDamage(damage);
            Console.WriteLine($"{Name} hits {target.Name} for {damage} damage!");
        }
        else
        {
            Console.WriteLine($"{Name} misses {target.Name}!");
        }
    }

    public void TakeDamage(int damage)
    {
        HitPoints -= damage;
        Console.WriteLine($"{Name} now has {HitPoints} HP remaining.");
        if (HitPoints <= 0)
        {
            Console.WriteLine($"{Name} has been defeated!");
        }
    }
}
