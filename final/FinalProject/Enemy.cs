public class Enemy : Character
{
    private string _enemyType;
    private int _challengeRating;

    public string EnemyType => _enemyType;
    public int ChallengeRating => _challengeRating;

    public int GetStrengthModifier()  
{
    return GetAbilityModifier(Abilities.Strength);
}
    public Enemy(string name, int level, int hitPoints, int armorClass,
                 AbilityScores abilities, int proficiencyBonus, string weaponDamageType, 
                 string enemyType, int challengeRating)
        : base(name, level, hitPoints, armorClass, abilities, proficiencyBonus, weaponDamageType)
    {
        _enemyType = enemyType;
        _challengeRating = challengeRating;
    }

    public void Attack(Character target)
    {
        int attackRoll = DiceRoller.Roll(1, 20) + GetStrengthModifier() + ProficiencyBonus;
        Console.WriteLine($"{Name} attacks {target.Name} with a roll of {attackRoll}!");

        if (attackRoll >= target.ArmorClass)
        {
            int damage = DiceRoller.Roll(1, 8) + GetStrengthModifier(); 
            target.TakeDamage(damage);
            Console.WriteLine($"{Name} hits {target.Name} for {damage} damage!");
        }
        else
        {
            Console.WriteLine($"{Name} misses {target.Name}!");
        }
    }
}
