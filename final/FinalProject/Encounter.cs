// Encounter class for managing the battle between players and enemies
public class Encounter
{
    public List<PlayerCharacter> Players { get; set; }
    public List<Enemy> Enemies { get; set; }
    public bool IsActive { get; set; }

    public Encounter()
    {
        Players = new List<PlayerCharacter>();
        Enemies = new List<Enemy>();
        IsActive = true;
    }

    // Start the encounter
    public void StartEncounter()
    {
        Console.WriteLine("Encounter started!");
    }

    // Process each turn of the encounter
    public void ProcessTurn()
    {
        if (!IsActive) return;

        // Example logic: Players attack enemies, then enemies attack players
        foreach (var player in Players)
        {
            if (Enemies.Count > 0)
            {
                int damage = player.Attack();
                Enemies[0].TakeDamage(damage); // First enemy takes damage
                if (Enemies[0].IsDefeated())
                {
                    Console.WriteLine($"{Enemies[0].Name} is defeated!");
                    Enemies.RemoveAt(0); // Remove defeated enemy
                }
            }
        }

        foreach (var enemy in Enemies)
        {
            if (Players.Count > 0)
            {
                int damage = enemy.Attack();
                Players[0].TakeDamage(damage); // First player takes damage
                if (Players[0].IsDefeated())
                {
                    Console.WriteLine($"{Players[0].Name} is defeated!");
                    Players.RemoveAt(0); // Remove defeated player
                }
            }
        }

        if (Players.Count == 0 || Enemies.Count == 0)
        {
            EndEncounter();
        }
    }

    // End the encounter
    public void EndEncounter()
    {
        IsActive = false;
        Console.WriteLine("Encounter ended!");
    }
}