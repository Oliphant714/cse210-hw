using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
}

class Program
{
    static List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "If I were to write a letter to your future self, what would I want to say?",
        "Imagine my ideal day. What does it look like and how did I try to achieve it?",
        "What was the most challenging thing I did today?",
        "What is something that scares me?  Did I face it today?",
        "Three things I'm grateful for:"
    };

    static List<JournalEntry> journalEntries = new List<JournalEntry>();

    static void Main(string[] args)
    {
        string userChoice;
        do
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display the Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (userChoice != "5");
    }

    static void WriteNewEntry()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your Response: ");
        string response = Console.ReadLine();

        journalEntries.Add(new JournalEntry
        {
            Date = DateTime.Now,
            Prompt = prompt,
            Response = response
        });

        Console.WriteLine("Entry saved!");
    }

    static void DisplayJournal()
    {
        if (journalEntries.Count == 0)
        {
            Console.WriteLine("\nNo entries found.");
        }
        else
        {
            Console.WriteLine("\nJournal Entries:");
            foreach (var entry in journalEntries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine("---");
            }
        }
    }

    static void SaveJournal()
{
    string journalJson = @"C:\Users\Isaac\OneDrive\Documents\Semester 5\cse210\cse210-hw\prepare\Learning03\journal.json";
    Console.Write($"Enter the filename to save to (default: {journalJson}): ");
    string filename = Console.ReadLine();


    if (!Path.IsPathRooted(filename))
    {
        filename = Path.Combine(journalJson, filename);
    }

    try
    {
        string jsonString = JsonSerializer.Serialize(journalEntries, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, jsonString);
        Console.WriteLine($"Journal saved successfully at {filename}.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error saving journal: {ex.Message}");
    }
}


    static void LoadJournal()
{
    string defaultDirectory = @"C:\Users\Isaac\OneDrive\Documents\Semester 5\cse210\cse210-hw\prepare\Learning03\journal.json";
    Console.Write($"Enter the filename to load from (default: {defaultDirectory}): ");
    string filename = Console.ReadLine();

   
    if (!Path.IsPathRooted(filename))
    {
        filename = Path.Combine(defaultDirectory, filename);
    }

    try
    {
        if (File.Exists(filename))
        {
            string jsonString = File.ReadAllText(filename);
            journalEntries = JsonSerializer.Deserialize<List<JournalEntry>>(jsonString) ?? new List<JournalEntry>();
            Console.WriteLine($"Journal loaded successfully from {filename}.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading journal: {ex.Message}");
    }
}

}
