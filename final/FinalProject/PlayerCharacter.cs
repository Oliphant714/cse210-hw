namespace FinalProject;
using System;
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

    public int GetStrengthModifier()  
{
    return GetAbilityModifier(Abilities.Strength);
}
    public int GetConstitutionModifier()
    {
        return GetAbilityModifier(Abilities.Constitution);
    }
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
    public int GetProficiencyBonus(int level)
{
    return level switch
    {
        <= 4 => 2,
        <= 8 => 3,
        <= 12 => 4,
        <= 16 => 5,
        _ => 6
    };
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

    private void ApplyAbilityScoreImprovement()
{
    Console.WriteLine("You gain an Ability Score Improvement!");
}


    public void LevelUp()
    {
        Level++;
        ProficiencyBonus = GetProficiencyBonus(Level);
        int hitPointsGained = DiceRoller.Roll(1, _hitDie) + GetConstitutionModifier();
        HitPoints += hitPointsGained;

        if (Level == 4 || Level == 8 || Level == 12 || Level == 16 || Level == 19)
        {
            ApplyAbilityScoreImprovement();
        }

        Console.WriteLine($"{Name} has leveled up to level {Level}!");
        Console.WriteLine($"New Proficiency Bonus: {ProficiencyBonus}");
        Console.WriteLine($"Hit Points increased by {hitPointsGained}. Total HP: {HitPoints}");
    }
}
