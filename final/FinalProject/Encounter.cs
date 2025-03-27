public class Encounter
{
    private List<Character> _combatants;

    public Encounter()
    {
        _combatants = new List<Character>();
    }

    public void AddCombatant(Character character)
    {
        _combatants.Add(character);
    }

    public void Start()
    {
        Console.WriteLine("The encounter begins!");
        
        // Start combat round
        while (!IsEncounterOver())
        {
            foreach (var combatant in _combatants)
            {
                // For each combatant, run their turn (e.g., attack, move, etc.)
                Console.WriteLine($"{combatant.Name}'s turn:");

                // Example of an attack turn
                if (combatant is PlayerCharacter player)
                {
                    // Player attack logic
                    Attack(player);
                }
                else if (combatant is Enemy enemy)
                {
                    // Enemy attack logic
                    Attack(enemy);
                }
            }
            Console.WriteLine("\nEnd of round.\n");
        }

        Console.WriteLine("The encounter is over.");
    }

    private bool IsEncounterOver()
    {
        // Simple check: if all enemies or players are dead, the encounter is over
        bool allEnemiesDead = !_combatants.OfType<Enemy>().Any(e => e.HitPoints > 0);
        bool allPlayersDead = !_combatants.OfType<PlayerCharacter>().Any(p => p.HitPoints > 0);

        return allEnemiesDead || allPlayersDead;
    }

    private void Attack(Character attacker)
    {
        if (attacker is PlayerCharacter player)
        {
            // Player attack logic
            int attackRoll = new Random().Next(1, 21); // Simulating a d20 roll
            int totalToHit = attackRoll + player.ProficiencyBonus + player.GetStrengthModifier();  // Example for a melee attack
            Console.WriteLine($"{player.Name} attacks with a total of {totalToHit} to hit!");

            // Simulate damage (e.g., d8 for a sword)
            if (totalToHit >= player.ArmorClass)
            {
                int damage = new Random().Next(1, 9); // Simulate damage for a d8 weapon
                Console.WriteLine($"{player.Name} hits! Damage: {damage}");
                // Apply damage to enemy
            }
            else
            {
                Console.WriteLine($"{player.Name} misses!");
            }
        }
        else if (attacker is Enemy enemy)
        {
            // Enemy attack logic
            int attackRoll = new Random().Next(1, 21); // Simulating a d20 roll
            int totalToHit = attackRoll + enemy.ProficiencyBonus + enemy.GetStrengthModifier();  // Example for a melee attack
            Console.WriteLine($"{enemy.Name} attacks with a total of {totalToHit} to hit!");

            // Simulate damage (e.g., d8 for a sword)
            if (totalToHit >= enemy.ArmorClass)
            {
                int damage = new Random().Next(1, 9); // Simulate damage for a d8 weapon
                Console.WriteLine($"{enemy.Name} hits! Damage: {damage}");
                // Apply damage to player
            }
            else
            {
                Console.WriteLine($"{enemy.Name} misses!");
            }
        }
    }
}
