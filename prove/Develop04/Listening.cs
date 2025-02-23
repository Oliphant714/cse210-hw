using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class ListingActivity : Activity
{
    private static readonly string[] Prompts = 
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() 
        : base("Listing Exercise", "This activity helps you focus on positive aspects of life.") { }

    protected override void RunActivity()
    {
        Random rand = new Random();
        Console.WriteLine($"\n{Prompts[rand.Next(Prompts.Length)]}\n");
        PauseWithAnimation(3);

        Console.WriteLine("Start listing your answers. Press Enter after each one:");
        List<string> responses = new List<string>();

        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                responses.Add(input);

            elapsed += 3;  // Assuming user takes ~3 seconds per input
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
    }
}
