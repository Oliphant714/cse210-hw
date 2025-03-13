class Program
{
    static void Main()
    {
        GameManager game = new GameManager();

        game.CreateGoal(new SimpleGoal("Run a marathon", 1000));
        game.CreateGoal(new EternalGoal("Read scriptures", 100));
        game.CreateGoal(new ChecklistGoal("Attend temple", 50, 10, 500));

        while (true)
        {
            Console.Clear();
            game.ShowStatus();
            Console.WriteLine("\nGoals:");
            game.ShowGoals();
            
            Console.WriteLine("\n1. Complete a Goal");
            Console.WriteLine("2. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            
            if (choice == "2") break;
            if (choice == "1")
            {
                Console.Write("Enter goal number: ");
                if (int.TryParse(Console.ReadLine(), out int goalIndex))
                {
                    game.CompleteGoal(goalIndex - 1);
                }
            }
        }
    }
}
