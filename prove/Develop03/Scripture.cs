public class Scripture
{
    public Refer Reference { get; private set; }
    private List<Word> Words { get; set; }  // Store words individually
    private List<Word> OriginalWords { get; set; }  // Store original words for reset

    public Scripture()
    {
        Words = new List<Word>();
        OriginalWords = new List<Word>();
    }

    public Scripture(Refer reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
        OriginalWords = [.. Words];  // Save a copy of the original words
    }

    public void DisplayScripture(bool hideLetters = false)
    {
        Console.WriteLine($"\nScripture Reference: {Reference}");
        if (hideLetters)
        {
            Console.WriteLine(string.Join(" ", Words.Select(w => w.ToString())));  // Show words with some hidden
        }
        else
        {
            Console.WriteLine(string.Join(" ", Words));  // Show all words normally
        }
    }

    public void HideWords(int count)
    {
        Random random = new Random();
        List<Word> visibleWords = Words.Where(w => !w.IsHidden).ToList();

        if (visibleWords.Count == 0) return;  // Stop if all words are hidden

        int hideCount = Math.Min(count, visibleWords.Count);
        foreach (Word word in visibleWords.OrderBy(_ => random.Next()).Take(hideCount))
        {
            word.Hide();
        }
    }

    public void ResetWords()
    {
        foreach (Word word in Words)
        {
            word.ResetVisibility();
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(w => w.IsHidden);
    }
}
