using System;

namespace ScriptureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the JSON file containing scripture data
            string filePath = "scripture.json";

            // Load the scripture from the JSON file
            Scripture scripture = Scripture.LoadFromJson(filePath);

            Console.WriteLine("Press Enter to begin or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") return;

            // Display scripture with hidden words
            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");
                input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                scripture.HideRandomWord();
            }

            Console.Clear();
            Console.WriteLine("All words are hidden!");
            Console.WriteLine("Final scripture: ");
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}
