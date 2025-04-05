public class EncounterManager
{
    private List<(string Name, int Initiative)> turnOrder = new();
    private Dictionary<string, Character> encounterCharacters = new();

    public void StartEncounter(Party party)
    {
        Console.Write("How many enemies are in this encounter? ");
        int enemyCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < enemyCount; i++)
        {
            Console.Write("Enter enemy name: ");
            string name = Console.ReadLine();
            var enemy = SaveLoad.LoadEnemy(name);
            Console.Write($"Enter initiative for {name}: ");
            int init = int.Parse(Console.ReadLine());
            turnOrder.Add((name, init));
            encounterCharacters[name] = enemy;
        }

        foreach (var pc in party.Members)
        {
            Console.Write($"Enter initiative for {pc.CharacterName}: ");
            int init = int.Parse(Console.ReadLine());
            turnOrder.Add((pc.CharacterName, init));
            encounterCharacters[pc.CharacterName] = pc;
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
        encounterCharacters[name].HitPoints += change;

        var maxHP = SaveLoad.GetMaxHP(name);
        if (encounterCharacters[name].HitPoints > maxHP)
            encounterCharacters[name].HitPoints = maxHP;
        if (encounterCharacters[name].HitPoints < 0)
            encounterCharacters[name].HitPoints = 0;

        Console.WriteLine($"{name} HP is now {encounterCharacters[name].HitPoints}.");
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

        if (encounterCharacters.Values.All(c => c is EnemyCharacter && c.HitPoints == 0))
        {
            Console.Write("All enemies defeated. End encounter? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
                turnOrder.Clear();
        }
    }
}