public class Character
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
    public int ArmorClass { get; set; }
    public int ProficiencyBonus { get; set; }
    public string WeaponDamageType { get; set; }
    public AbilityScores Abilities { get; set; }

    public Character(string name, int level, int hitPoints, int armorClass,
                     AbilityScores abilities, int proficiencyBonus, string weaponDamageType)
    {
        Name = name;
        Level = level;
        HitPoints = hitPoints;
        ArmorClass = armorClass;
        Abilities = abilities ?? new AbilityScores();
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

    public int GetAbilityModifier(int abilityScore)
    {
        return (abilityScore - 10) / 2;
    }

   public void TakeDamage(int damage)
{
    HitPoints -= damage;
    if (HitPoints < 0) HitPoints = 0;
    Console.WriteLine($"{Name} took {damage} damage! Remaining HP: {HitPoints}");
}


}
