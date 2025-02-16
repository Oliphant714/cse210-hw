public class Refer
{
    // Public properties to access the fields
    public string Book { get; private set; }

    public int StartVerse { get; private set; }

    public int EndVerse { get; private set; }

    public Refer() { }

    // Constructor for a single verse
    public Refer(string book, int startVerse)
    {
        Book = book;
        StartVerse = startVerse;
        EndVerse = startVerse;  // For single verse
    }

    // Constructor for a verse range
    public Refer(string book, int startVerse, int endVerse)
    {
        Book = book;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }
}