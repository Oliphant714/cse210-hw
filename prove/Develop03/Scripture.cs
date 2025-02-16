using System.Text.Json.Serialization;

public class Scripture
{
    // Public properties to access the fields
    public Refer Reference { get; private set; }

    public string Text { get; private set; }

    public Scripture() {}

    // Constructor for initializing Scripture
    public Scripture(Refer reference, string text)
    {
        Reference = reference;
        Text = text;
    }

    // Public method to display scripture in the correct format
    public void DisplayScripture()
    {
        Console.WriteLine($"Scripture Reference: {Reference.Book} {Reference.StartVerse}-{Reference.EndVerse}");
        Console.WriteLine($"Text: {Text}");
    }
}