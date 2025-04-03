namespace FinalProject;
using System;
public class EncounterManager
{
    private Party _party;
    private List<Enemy> _enemyList;

    public EncounterManager()
    {
        _party = new Party();
        _enemyList = new List<Enemy>();
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to the D&D Encounter Simulator!");
        MainMenu();
    }

    private void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Create Party");
            Console.WriteLine("2. Load Party");
            Console.WriteLine("3. Start Encounter");
            Console.WriteLine("4. Save Party");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine() ?? "5";
            switch (choice)
            {
                case "1":
                    CreateParty();
                    break;
                case "2":
                    _party.LoadParty("saved_party.json");
                    break;
                case "3":
                    StartEncounter();
                    break;
                case "4":
                    _party.SaveParty("saved_party.json");
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void CreateParty()
    {
        Console.WriteLine("Enter the number of players in the party:");
        if (int.TryParse(Console.ReadLine(), out int numPlayers) && numPlayers > 0)
        {
            for (int i = 0; i < numPlayers; i++)
            {
                Console.WriteLine($"Enter name for Player {i + 1}:");
                string name = Console.ReadLine() ?? $"Player{i + 1}";

                Console.WriteLine("Choose a class (Fighter, Rogue, Wizard):");
                string classType = Console.ReadLine() ?? "Fighter";

                AbilityScores abilities = AbilityScores.GenerateRandom();
                int level = 1;
                int hp = DiceRoller.Roll(1, 10) + abilities.ConstitutionModifier;
                int ac = 10 + abilities.DexterityModifier;
                int proficiencyBonus = 2;
                string weaponDamageType = "Slashing";

                var player = new PlayerCharacter(name, level, hp, ac, abilities, proficiencyBonus, weaponDamageType, classType);
                _party.AddMember(player);
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Returning to main menu.");
        }
    }

    public void StartEncounter()
    {
        Console.WriteLine("Starting a new encounter...");

        _enemyList.Clear();
        Console.WriteLine("How many enemies?");
        if (int.TryParse(Console.ReadLine(), out int numEnemies) && numEnemies > 0)
        {
            for (int i = 0; i < numEnemies; i++)
            {
                string name = $"Enemy {i + 1}";
                int level = 1;
                int hp = DiceRoller.Roll(1, 8) + 2;
                int ac = 12;
                AbilityScores abilities = AbilityScores.GenerateRandom();
                int proficiencyBonus = 2;
                string damageType = "Piercing";

                string enemyType = "Goblin";
                int challengeRating = 1;

                var enemy = new Enemy(name, level, hp, ac, abilities, proficiencyBonus, damageType, enemyType, challengeRating);
                _enemyList.Add(enemy);
            }
        }

        EncounterManager encounter = new EncounterManager();
        encounter.StartEncounter();
    }
}
