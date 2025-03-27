// GameManager class to manage the saving and loading of parties and encounters
public class GameManager
{
    public List<Party> SavedParties { get; set; }
    public List<Encounter> SavedEncounters { get; set; }

    public GameManager()
    {
        SavedParties = new List<Party>();
        SavedEncounters = new List<Encounter>();
    }

    // Save a party
    public void SaveParty(Party party)
    {
        SavedParties.Add(party);
        Console.WriteLine($"Party {party.PartyName} saved!");
    }

    // Load a party by name
    public Party LoadParty(string partyName)
    {
        var party = SavedParties.Find(p => p.PartyName == partyName);
        if (party != null)
        {
            Console.WriteLine($"Loaded party: {party.PartyName}");
        }
        else
        {
            Console.WriteLine("Party not found.");
        }
        return party;
    }

    // Save an encounter
    public void SaveEncounter(Encounter encounter)
    {
        SavedEncounters.Add(encounter);
        Console.WriteLine("Encounter saved!");
    }

    // Load an encounter by index
    public Encounter LoadEncounter(int encounterIndex)
    {
        if (encounterIndex >= 0 && encounterIndex < SavedEncounters.Count)
        {
            Console.WriteLine("Loaded encounter.");
            return SavedEncounters[encounterIndex];
        }
        Console.WriteLine("Encounter not found.");
        return null;
    }
}