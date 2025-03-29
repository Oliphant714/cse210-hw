public class Party
{
    private List<PlayerCharacter> _members;

    public List<PlayerCharacter> Members => _members;

    public Party()
    {
        _members = new List<PlayerCharacter>();
    }

    public void AddMember(PlayerCharacter character)
    {
        _members.Add(character);
        Console.WriteLine($"{character.Name} has joined the party.");
    }

    public void RemoveMember(PlayerCharacter character)
    {
        if (_members.Remove(character))
        {
            Console.WriteLine($"{character.Name} has left the party.");
        }
        else
        {
            Console.WriteLine($"{character.Name} is not in the party.");
        }
    }

    public void DisplayParty()
    {
        Console.WriteLine("Party Members:");
        foreach (var member in _members)
        {
            Console.WriteLine($"{member.Name} (Level {member.Level}, {member.ClassType}, HP: {member.HitPoints})");
        }
    }
}
