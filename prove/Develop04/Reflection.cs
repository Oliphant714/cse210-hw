using System;
using System.Linq;
using System.Threading;

public class ReflectionActivity : Activity
{
    private static readonly string[] Prompts = 
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions = 
    {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind for the future?"
    };

    public ReflectionActivity() 
        : base("Reflection Exercise", "This activity helps you reflect on your past experiences.") { }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine($"\n{Prompts[rand.Next(Prompts.Length)]}\n");
        PauseWithAnimation(3);

        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine($"{Questions[rand.Next(Questions.Length)]}");
            PauseWithAnimation(5);
            elapsed += 5;
        }
    }
}
