using System.Text.Json;

public class ScriptureManager
{
    private readonly string _filePath;
    private List<Scripture> _scriptures;

    public ScriptureManager(string filePath)
    {
        _filePath = filePath;
        _scriptures = LoadScriptures();
    }

    private List<Scripture> LoadScriptures()
    {
        if (File.Exists(_filePath))
        {
            string jsonContent = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Scripture>>(jsonContent) ?? new List<Scripture>();
        }
        return new List<Scripture>();
    }

    private void SaveScriptures()
    {
        string jsonContent = JsonSerializer.Serialize(_scriptures, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, jsonContent);
    }

    public void ViewScriptures()
    {
        if (_scriptures.Count == 0)
        {
            Console.WriteLine("\nNo scriptures available.\n");
            return;
        }

        Console.WriteLine("\nAvailable Scriptures:");
        for (int i = 0; i < _scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_scriptures[i].Reference}");
        }

        Console.Write("Enter the number of the scripture you want to view: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _scriptures.Count)
        {
            _scriptures[index - 1].DisplayScripture();
        }
        else
        {
            Console.WriteLine("\nInvalid selection.\n");
        }
    }

    public void AddScripture()
    {
        Console.Write("Enter the book name: ");
        string book = Console.ReadLine();

        Console.Write("Enter the chapter number: ");
    if (!int.TryParse(Console.ReadLine(), out int chapter) || chapter <= 0)
    {
        Console.WriteLine("\nInvalid input. Chapter must be a positive number.\n");
        return;
    }

        Console.Write("Enter the starting verse: ");
        if (!int.TryParse(Console.ReadLine(), out int startVerse))
        {
            Console.WriteLine("\nInvalid input. Scripture not added.\n");
            return;
        }

        Console.Write("Enter the ending verse (or press Enter for single verse): ");
        string endInput = Console.ReadLine();
        int endVerse = string.IsNullOrWhiteSpace(endInput) ? startVerse : int.Parse(endInput);

        Console.Write("Enter the scripture text: ");
        string text = Console.ReadLine();

        _scriptures.Add(new Scripture(new Refer(book, chapter, startVerse, endVerse), text));
        SaveScriptures();

        Console.WriteLine("\nScripture added successfully!\n");
    }
    public void MemorizeScripture()
    {
        if (_scriptures.Count == 0)
        {
            Console.WriteLine("\nNo scriptures available.\n");
            return;
        }

        Console.WriteLine("\nAvailable Scriptures for Memorization:");
        for (int i = 0; i < _scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_scriptures[i].Reference}");
        }

        Console.Write("Enter the number of the scripture to practice memorizing: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _scriptures.Count)
        {
            Scripture selected = _scriptures[index - 1];

            Console.Clear();
            Console.WriteLine("\nMemorization Mode - Try to Recall the Verse:");
            while (true)
            {
                selected.DisplayScripture(hideLetters: true);
                Console.Write("\nPress Enter to reveal the full verse or type 'exit' to return to menu: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    break;
                Console.Clear();
                selected.DisplayScripture();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                break;
            }
        }
        else
        {
            Console.WriteLine("\nInvalid selection.\n");
        }
    }
}