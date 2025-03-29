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
        _hitDie = (classType == "Fighter") ? 10 : 6;
    }

    public void LevelUp()
    {
        Level++;
        ProficiencyBonus = GetProficiencyBonus();
        int hitPointsGained = _hitDie + Abilities.ConstitutionModifier;
        HitPoints += hitPointsGained;

        if (Level == 4 || Level == 8 || Level == 12 || Level == 16 || Level == 19)
        {
            ApplyAbilityScoreImprovement();
        }

        Console.WriteLine($"{Name} has leveled up to level {Level}!");
        Console.WriteLine($"New Proficiency Bonus: {ProficiencyBonus}");
        Console.WriteLine($"Hit Points increased by {hitPointsGained}. Total HP: {HitPoints}");
    }

    private void ApplyAbilityScoreImprovement()
    {
        Console.WriteLine("You gain an Ability Score Improvement!");
        Console.WriteLine("Which ability would you like to improve?");
        Console.WriteLine("1. Strength");
        Console.WriteLine("2. Dexterity");
        Console.WriteLine("3. Constitution");
        Console.WriteLine("4. Intelligence");
        Console.WriteLine("5. Wisdom");
        Console.WriteLine("6. Charisma");

        int choice = int.Parse(Console.ReadLine() ?? "1");
        Abilities.IncreaseAbility(choice);
        Console.WriteLine($"Your {GetAbilityName(choice)} increased by 1!");
    }

    private string GetAbilityName(int abilityIndex)
    {
        return abilityIndex switch
        {
            1 => "Strength",
            2 => "Dexterity",
            3 => "Constitution",
            4 => "Intelligence",
            5 => "Wisdom",
            6 => "Charisma",
            _ => "Strength"
        };
    }
}
