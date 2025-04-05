public class Spellcasting
{
    public int SpellcasterLevel { get; set; }
    public string SpellcasterClass { get; set; }
    public int SpellSlots { get; set; }
    public List<string> KnownSpells { get; set; } = new();
}