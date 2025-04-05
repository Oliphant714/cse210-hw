public static class GameManager
{
    private static Party currentParty;
    private static List<EnemyCharacter> loadedEnemies;
    private static List<Weapon> loadedWeapons;

    public static void Run()
    {
        Console.Write("Load existing party? (y/n): ");
        if (Console.ReadLine().ToLower() == "y")
        {
            Console.Write("Enter party name to load: ");
            currentParty = SaveLoad.LoadParty(Console.ReadLine());
        }
        else
        {
            currentParty = CharacterGeneration.CreateNewParty();
            SaveLoad.SaveParty(currentParty);
        }

        // Load all enemies and weapons into memory
        loadedEnemies = SaveLoad.LoadEnemies();
        loadedWeapons = SaveLoad.LoadWeapons();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an action:");
            Console.WriteLine("1. Create an Enemy");
            Console.WriteLine("2. Update an Enemy");
            Console.WriteLine("3. Create a Weapon");
            Console.WriteLine("4. Create an Encounter");
            Console.WriteLine("5. Quit");
            Console.Write("Option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    var enemy = CharacterGeneration.CreateEnemy();
                    SaveLoad.AddEnemy(enemy); // Add to file
                    loadedEnemies.Add(enemy); // Add to local list
                    break;

                case "2":
                    Console.Write("Enter enemy name to update: ");
                    string name = Console.ReadLine();
                    var oldEnemy = loadedEnemies.FirstOrDefault(e => e.CharacterName == name);
                    if (oldEnemy != null)
                    {
                        var updated = CharacterGeneration.UpdateEnemy(oldEnemy);
                        loadedEnemies.Remove(oldEnemy);
                        loadedEnemies.Add(updated);
                        SaveLoad.OverwriteEnemies(loadedEnemies); // You’ll need this new method
                    }
                    else
                    {
                        Console.WriteLine("Enemy not found.");
                    }
                    break;

                case "3":
                    var weapon = CharacterGeneration.CreateWeapon();
                    SaveLoad.AddWeapon(weapon);
                    loadedWeapons.Add(weapon);
                    break;

                case "4":
                    var em = new EncounterManager();
                    em.StartEncounter(currentParty, loadedEnemies); // Pass loaded enemies
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
