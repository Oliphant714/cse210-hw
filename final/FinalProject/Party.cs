public class Party
{
    public string PartyName { get; set; }
    public List<PlayerCharacter> Members { get; set; } = new();
}