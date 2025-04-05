public class EncounterManager
{
    private List<(string Name, int Initiative)> turnOrder = new();
    private Dictionary<string, Character> encounterCharacters = new();
    private Dictionary<string, int> maxHPs = new(); // Stores max HP at start

    public void StartEncounter(Party party, List<EnemyCharacter> loadedEnemies)
    {
        Console.Write("How many enemies are in this encounter? ");
        int enemyCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < enemyCount; i++)
        {
            Console.Write("Enter enemy name: ");
            string name = Console.ReadLine();

            var enemy = loadedEnemies.FirstOrDefault(e => e.CharacterName == name);
            if (enemy == null)
            {
                Console.WriteLine($"Enemy '{name}' not found in loaded list.");
                i--; // Try again
                continue;
            }

            Console.Write($"Enter initiative for {name}: ");
            int init = int.Parse(Console.ReadLine());
            turnOrder.Add((name, init));
            encounterCharacters[name] = enemy;
            maxHPs[name] = enemy.HitPoints; // Store original HP
        }

        foreach (var pc in party.Members)
        {
            Console.Write($"Enter initiative for {pc.CharacterName}: ");
            int init = int.Parse(Console.ReadLine());
            turnOrder.Add((pc.CharacterName, init));
            encounterCharacters[pc.CharacterName] = pc;
            maxHPs[pc.CharacterName] = pc.HitPoints; // Store original HP
        }

        turnOrder = turnOrder.OrderByDescending(t => t.Initiative).ToList();
        DisplayEncounter();
    }

    public void UpdateHP()
    {
        Console.Write("Enter character name to update HP: ");
        string name = Console.ReadLine();

        if (!encounterCharacters.ContainsKey(name))
        {
            Console.WriteLine("Character not found in encounter.");
            return;
        }

        Console.Write("Enter HP change (negative for damage, positive for healing): ");
        int change = int.Parse(Console.ReadLine());
        var character = encounterCharacters[name];
        character.HitPoints += change;

        if (character.HitPoints > maxHPs[name])
            character.HitPoints = maxHPs[name];
        if (character.HitPoints < 0)
            character.HitPoints = 0;

        Console.WriteLine($"{name} HP is now {character.HitPoints}.");
    }

    public void DisplayEncounter()
    {
        Console.WriteLine("\n--- Encounter Turn Order ---");
        foreach (var (name, _) in turnOrder)
        {
            var c = encounterCharacters[name];
            Console.WriteLine($"{c.CharacterName}, {c.GetType().Name}, HP: {c.HitPoints}, AC: {c.ArmorClass}, PP: {c.PassivePerception}");
            if (c is EnemyCharacter enemy)
            {
                Console.WriteLine("  Weapons:");
                foreach (var w in enemy.Weapons)
                    Console.WriteLine($"    {w.WeaponName}");
                Console.WriteLine("  Abilities:");
                foreach (var a in enemy.Abilities)
                    Console.WriteLine($"    {a.AbilityName}");
                if (enemy.Spellcasting != null)
                    Console.WriteLine($"  Spell Slots: {enemy.Spellcasting.SpellSlots}");
            }
        }

        // Check if all enemies are defeated
        bool allEnemiesDown = encounterCharacters.Values
            .Where(c => c is EnemyCharacter)
            .All(e => e.HitPoints == 0);

        if (allEnemiesDown)
        {
            Console.Write("All enemies defeated. End encounter? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
                turnOrder.Clear();
        }
    }
}
