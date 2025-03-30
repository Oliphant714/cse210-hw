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
        Console.WriteLine($"{character.Name} has joined the party!");
    }

    public void RemoveMember(string name)
    {
        var character = _members.FirstOrDefault(c => c.Name == name);
        if (character != null)
        {
            _members.Remove(character);
            Console.WriteLine($"{character.Name} has left the party.");
        }
        else
        {
            Console.WriteLine($"No character named {name} found in the party.");
        }
    }

    public void DisplayParty()
    {
        Console.WriteLine("Current Party Members:");
        foreach (var member in _members)
        {
            Console.WriteLine($"- {member.Name} (Level {member.Level}, {member.ClassType})");
        }
    }

    public void SaveParty(string filename)
    {
        var json = JsonSerializer.Serialize(_members);
        File.WriteAllText(filename, json);
        Console.WriteLine("Party saved successfully.");
    }

    public void LoadParty(string filename)
    {
        if (File.Exists(filename))
        {
            var json = File.ReadAllText(filename);
            _members = JsonSerializer.Deserialize<List<PlayerCharacter>>(json) ?? new List<PlayerCharacter>();
            Console.WriteLine("Party loaded successfully.");
        }
        else
        {
            Console.WriteLine("No saved party found.");
        }
    }
}
