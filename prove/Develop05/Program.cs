class Program
{
    static void Main()
    {
        GameManager gameManager = new GameManager();

        while (true)
        {
            Console.Clear();
            gameManager.ShowStatus();
            Console.WriteLine("\n===== Eternal Quest Menu =====");
            Console.WriteLine("1. Record Goal Completion");
            Console.WriteLine("2. Show Goals");
            Console.WriteLine("3. Create New Goal");
            Console.WriteLine("4. Save Game");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    gameManager.ShowGoals();
                    Console.Write("Enter goal number to complete: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        gameManager.CompleteGoal(index - 1);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;
                case "2":
                    gameManager.ShowGoals();
                    break;
                case "3":
                    gameManager.CreateGoal();
                    break;
                case "4":
                    gameManager.SaveGame();
                    break;
                case "5":
                    Console.Write("Would you like to save before exiting? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        gameManager.SaveGame();
                    }
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}