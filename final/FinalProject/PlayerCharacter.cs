public class PlayerCharacter : Character
{
    private string _classType;
    private int _hitDie;

    // Properties
    public string ClassType => _classType;

    // Constructor
    public PlayerCharacter(string name, int level, int hitPoints, int armorClass,
                           int strength, int dexterity, int constitution,
                           int intelligence, int wisdom, int charisma,
                           int proficiencyBonus, string weaponDamageType, string classType)
        : base(name, level, hitPoints, armorClass, strength, dexterity, constitution,
               intelligence, wisdom, charisma, proficiencyBonus, weaponDamageType)
    {
        _classType = classType;
        _hitDie = (classType == "Fighter") ? 10 : 6; // Example: Fighters use 1d10, Wizards use 1d6
    }

    // Level up logic for PlayerCharacter
    public void LevelUp()
    {
        _level++; // Now this is allowed because _level is protected

        // Update Proficiency Bonus based on level brackets (5, 9, 13, 17)
        _proficiencyBonus = GetProficiencyBonus(_level);

        // Increase Hit Points based on class and Constitution modifier
        int hitPointsGained = _hitDie + GetConstitutionModifier();
        _hitPoints += hitPointsGained;

        // Apply ability score improvements at level 4, 8, 12, 16, 19 (this can be expanded later)
        if (_level == 4 || _level == 8 || _level == 12 || _level == 16 || _level == 19)
        {
            ApplyAbilityScoreImprovement();
        }

        Console.WriteLine($"{Name} has leveled up to level {_level}!");
        Console.WriteLine($"New Proficiency Bonus: {_proficiencyBonus}");
        Console.WriteLine($"Hit Points increased by {hitPointsGained}. Total HP: {_hitPoints}");
    }

    // Calculate Proficiency Bonus based on level
    private int GetProficiencyBonus(int level)
    {
        if (level >= 1 && level <= 4)
            return 2;
        if (level >= 5 && level <= 8)
            return 3;
        if (level >= 9 && level <= 12)
            return 4;
        if (level >= 13 && level <= 16)
            return 5;
        if (level >= 17)
            return 6;
        return 2; // Default
    }

    // Calculate Constitution Modifier
    private int GetConstitutionModifier()
    {
        return (_constitution - 10) / 2; // Standard formula for calculating Constitution modifier
    }

    // Apply Ability Score Improvement (available at certain levels)
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
        switch (choice)
        {
            case 1: _strength++; break;
            case 2: _dexterity++; break;
            case 3: _constitution++; break;
            case 4: _intelligence++; break;
            case 5: _wisdom++; break;
            case 6: _charisma++; break;
            default: _strength++; break;
        }

        Console.WriteLine($"Your {GetAbilityName(choice)} increased by 1!");
    }

    // Get Ability Name as a string
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

    // D&D 5e Modifiers for different abilities
    public int GetStrengthModifier() => (Strength - 10) / 2;
    public int GetDexterityModifier() => (Dexterity - 10) / 2;
    public int GetConstitutionModifier() => (Constitution - 10) / 2;
    public int GetIntelligenceModifier() => (Intelligence - 10) / 2;
    public int GetWisdomModifier() => (Wisdom - 10) / 2;
    public int GetCharismaModifier() => (Charisma - 10) / 2;
}
