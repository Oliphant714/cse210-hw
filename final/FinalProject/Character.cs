public class Character
{
    // Now accessible to derived classes, but not to the outside world directly
    protected int _level;
    protected int _hitPoints;
    protected int _armorClass;
    protected int _strength;
    protected int _dexterity;
    protected int _constitution;
    protected int _intelligence;
    protected int _wisdom;
    protected int _charisma;
    protected int _proficiencyBonus;
    protected string _weaponDamageType;
    
    public string Name { get; set; }
    public int Level => _level;
    public int HitPoints => _hitPoints;
    public int ArmorClass => _armorClass;
    public int ProficiencyBonus => _proficiencyBonus;

    public Character(string name, int level, int hitPoints, int armorClass, 
                     int strength, int dexterity, int constitution, 
                     int intelligence, int wisdom, int charisma, 
                     int proficiencyBonus, string weaponDamageType)
    {
        Name = name;
        _level = level;
        _hitPoints = hitPoints;
        _armorClass = armorClass;
        _strength = strength;
        _dexterity = dexterity;
        _constitution = constitution;
        _intelligence = intelligence;
        _wisdom = wisdom;
        _charisma = charisma;
        _proficiencyBonus = proficiencyBonus;
        _weaponDamageType = weaponDamageType;
    }

    // Add common character behavior methods if needed (such as calculating saving throws, etc.)
}

