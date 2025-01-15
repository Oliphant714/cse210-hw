using System;

class Program
{
    static void Main(string[] args)
    {
        
    
    Console.WriteLine(@"This is the 'Guess a number' game. 
    You try to guess a number between 1-100 in the smallest number of attempts.");

    
    
    string keepPlaying;
    do
    {
        Random randomGenerator = new Random();
        int randoNumber = randomGenerator.Next(1, 101);
        int attempts = 0;
        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        while ( guess != randoNumber)
        {
            if (guess > randoNumber)
            {
                Console.Write("Too high!  Try again! ");
                guess = int.Parse(Console.ReadLine());
            }
            else if (guess < randoNumber)
            {
                Console.Write("Too low!  Try again! ");
                guess = int.Parse(Console.ReadLine());
            }
            
            attempts++;
        };
        Console.WriteLine($"That is correct!  The number was {randoNumber}!");
        if (attempts > 1)
        {
            Console.WriteLine($"It took you {attempts} tries!");
        }

        Console.Write("Do you want to play again? Y/N ");
        keepPlaying = Console.ReadLine().ToUpper();
    } while (keepPlaying == "Y");
    
if (keepPlaying == "N")
{
    Console.WriteLine("Thank you for playing!");
}
else 
{
    Console.WriteLine("That is an invalid response.  The game will now end.  We hope you're happy for messing up a simple Y/N question.");
}
    }
}