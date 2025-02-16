public class Scripture
{
    public Refer Reference { get; private set; }
    public string Text { get; private set; }

    public Scripture(Refer reference, string text)
    {
        Reference = reference;
        Text = text;
    }

    public void DisplayScripture(bool hideLetters = false)
    {
    Console.WriteLine($"\nScripture Reference: {Reference}");
    Console.WriteLine(hideLetters ? HideLetters(Text) : Text);
    Console.WriteLine();
}

// Method to hide random letters
private string HideLetters(string text)
{
    Random rand = new Random();
    char[] chars = text.ToCharArray();

    for (int i = 0; i < chars.Length; i++)
    {
        if (char.IsLetter(chars[i]) && rand.Next(100) < 50) // 30% chance to hide a letter
        {
            chars[i] = '_';
        }
    }
    return new string(chars);
}
}