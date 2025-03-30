public class PlayerCharacter : Character
{
    private string _classType;
    private int _hitDie;

    public string ClassType => _classType;

    public PlayerCharacter(string name, int level, int hitPoints, int armorClass,
                           AbilityScores abilities, int proficiencyBonus, 
                           string weaponDamageType, string classType)
        : base(name, level, hitPoints, armorClass, abilities, proficiencyBonus, weaponDamageType)
    {
        _classType = classType;
        _hitDie = GetHitDie(classType);
    }

    int modifier = GetAbilityModifier(_strength);
    private int GetHitDie(string classType)
    {
        return classType switch
        {
            "Fighter" => 10,
            "Rogue" => 8,
            "Wizard" => 6,
            _ => 6
        };
    }

    public void Attack(Character target)
    {
        int attackRoll = DiceRoller.Roll(1, 20) + GetAbilityModifier("Strength") + ProficiencyBonus;
        Console.WriteLine($"{Name} attacks {target.Name} with a roll of {attackRoll}!");

        if (attackRoll >= target.ArmorClass)
        {
            int damage = DiceRoller.Roll(1, 8) + GetAbilityModifier("Strength"); 
            target.TakeDamage(damage);
            Console.WriteLine($"{Name} hits {target.Name} for {damage} damage!");
        }
        else
        {
            Console.WriteLine($"{Name} misses {target.Name}!");
        }
    }

    private void ApplyAbilityScoreImprovement()
{
    Console.WriteLine("You gain an Ability Score Improvement!");
}


    public void LevelUp()
    {
        _level++;
        _proficiencyBonus = GetProficiencyBonus(_level);
        int hitPointsGained = DiceRoller.Roll(1, _hitDie) + GetAbilityModifier("Constitution");
        _hitPoints += hitPointsGained;

        if (_level == 4 || _level == 8 || _level == 12 || _level == 16 || _level == 19)
        {
            ApplyAbilityScoreImprovement();
        }

        Console.WriteLine($"{Name} has leveled up to level {_level}!");
        Console.WriteLine($"New Proficiency Bonus: {_proficiencyBonus}");
        Console.WriteLine($"Hit Points increased by {hitPointsGained}. Total HP: {_hitPoints}");
    }
}
