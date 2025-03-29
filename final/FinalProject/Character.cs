public class Character
{
    protected string Name { get; set; }
    protected int Level { get; set; }
    protected int HitPoints { get; set; }
    protected int ArmorClass { get; set; }
    protected int ProficiencyBonus { get; set; }
    protected string WeaponDamageType { get; set; }
    protected AbilityScores Abilities { get; set; }

    public Character(string name, int level, int hitPoints, int armorClass,
                     AbilityScores abilities, int proficiencyBonus, string weaponDamageType)
    {
        Name = name;
        Level = level;
        HitPoints = hitPoints;
        ArmorClass = armorClass;
        Abilities = abilities;
        ProficiencyBonus = proficiencyBonus;
        WeaponDamageType = weaponDamageType;
    }

    public int GetProficiencyBonus()
    {
        return Level switch
        {
            <= 4 => 2,
            <= 8 => 3,
            <= 12 => 4,
            <= 16 => 5,
            _ => 6
        };
    }
}
