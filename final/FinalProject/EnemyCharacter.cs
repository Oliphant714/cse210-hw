public class EnemyCharacter : Character
{
    public string CreatureType { get; set; }
    public int AttackModifier { get; set; }
    public int SpellSaveDC { get; set; }
    public int ProficiencyBonus { get; set; }
    public List<Weapon> Weapons { get; set; } = new();
    public List<Ability> Abilities { get; set; } = new();
    public List<Spellcasting> Spellcasting { get; set; }
}