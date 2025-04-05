public static class GameManager
{
    private static Party currentParty;

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
                    SaveLoad.SaveEnemy(enemy);
                    break;
                case "2":
                    Console.Write("Enter enemy name to update: ");
                    var oldEnemy = SaveLoad.LoadEnemy(Console.ReadLine());
                    if (oldEnemy != null)
                    {
                        var updated = CharacterGeneration.UpdateEnemy(oldEnemy);
                        SaveLoad.SaveEnemy(updated);
                    }
                    break;
                case "3":
                    var weapon = CharacterGeneration.CreateWeapon();
                    SaveLoad.SaveWeapon(weapon);
                    break;
                case "4":
                    var em = new EncounterManager();
                    em.StartEncounter(currentParty);
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