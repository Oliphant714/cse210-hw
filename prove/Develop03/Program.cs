using System.Text.Json;

class Program
{
    static void Main()
    {
        ScriptureManager manager = new ScriptureManager("C:/Users/Isaac/OneDrive/Documents/Semester 5/cse210/cse210-hw/prove/Develop03/scripture.json");
        bool running = true;

        while (running)
        while (running)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1. View Scripture");
    Console.WriteLine("2. Add Scripture");
    Console.WriteLine("3. Memorize Scripture");
    Console.WriteLine("4. Clear Screen");
    Console.WriteLine("5. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            manager.ViewScriptures();
            break;
        case "2":
            manager.AddScripture();
            break;
        case "3":
            manager.MemorizeScripture();
            break;
        case "4":
            Console.Clear();
            break;
        case "5":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
        }
    }
}
