using System;
using System.Threading;

public abstract class Activity
{
    protected string Name { get; }
    protected string Description { get; }
    protected int Duration { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"--- {Name} ---\n");
        Console.WriteLine($"{Description}\n");
        Console.Write("Enter the duration (seconds): ");
        
        if (!int.TryParse(Console.ReadLine(), out int duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Using default duration of 10 seconds.");
            duration = 10;
        }
        
        Duration = duration;

        Console.WriteLine("\nPrepare to begin...");
        PauseWithAnimation(3);
        RunActivity();
        End();
    }

    protected void PauseWithAnimation(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\rStarting in {i}...");
            Thread.Sleep(1000);
        }
        Console.Clear();
    }

    protected void End()
    {
        Console.WriteLine("\nGood job! You have completed the activity.");
        Console.WriteLine($"Activity: {Name} | Duration: {Duration} seconds");
        PauseWithAnimation(3);
    }

    protected abstract void RunActivity();
}
