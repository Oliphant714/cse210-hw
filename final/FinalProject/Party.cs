// Party class holding multiple PlayerCharacters
public class Party
{
    public List<PlayerCharacter> Members { get; set; }
    public string PartyName { get; set; }

    public Party(string partyName)
    {
        PartyName = partyName;
        Members = new List<PlayerCharacter>();
    }

    // Add a new member to the party
    public void AddCharacter(PlayerCharacter character)
    {
        Members.Add(character);
        Console.WriteLine($"{character.Name} added to the party {PartyName}.");
    }

    // Remove a character by name
    public void RemoveCharacter(string name)
    {
        var character = Members.Find(c => c.Name == name);
        if (character != null)
        {
            Members.Remove(character);
            Console.WriteLine($"{name} removed from the party {PartyName}.");
        }
        else
        {
            Console.WriteLine($"{name} is not in the party.");
        }
    }

    // Display the party's details
    public void ShowPartyDetails()
    {
        Console.WriteLine($"Party: {PartyName}");
        foreach (var member in Members)
        {
            Console.WriteLine($"- {member.Name} ({member.ClassType})");
        }
    }
}