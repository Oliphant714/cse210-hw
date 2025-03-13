class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals & Score");
            Console.WriteLine("4. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.RecordEvent();
                    break;
                case "3":
                    manager.ShowGoals();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
                case "4":
                    return;
            }
        }
    }
}
