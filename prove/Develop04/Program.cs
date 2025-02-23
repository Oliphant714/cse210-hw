using System;

class Program
{
    static void Main()
    {  
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Random Activity");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            if (choice == "5")
                Console.WriteLine("Thank you for enhancing your mental health. Goodbye!");
                break;

            List<Action> activities = new List<Action>
            {
                () => new BreathingActivity().Start(),
                () => new ReflectionActivity().Start(),
                () => new ListingActivity().Start()
            };

            Random random = new Random();

            switch (choice)
            {
                case "1":
                    activities[0]();
                    break;
                case "2":
                    activities[1]();
                    break;
                case "3":
                    activities[2]();
                    break;
                case "4":
                    int randomIndex = random.Next(activities.Count);
                    activities[randomIndex]();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }

            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}
