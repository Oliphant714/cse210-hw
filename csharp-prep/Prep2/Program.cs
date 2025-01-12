using System;
class Program {
    static void Main(string[] args)
    {
        Console.Write("What is your final percentage? ");
        int gradeNumber = int.Parse(Console.ReadLine());
        
        
        string gradeLetter = "Balderdash";

        if (gradeNumber >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradeNumber >= 80 && gradeNumber < 90)
        {
            gradeLetter = "B";
        }
        else if (gradeNumber >= 70 && gradeNumber < 80)
        {
            gradeLetter = "C";
        }
        else if (gradeNumber >= 60 && gradeNumber < 70)
        {
            gradeLetter = "D";
        }
        else
        {
            gradeLetter = "F";
        }

        Console.WriteLine($"Your final grade is {gradeLetter}");

        if (gradeNumber >= 70)
        {
            Console.Write("You passed.");
        }
        else{
            Console.Write("You failed.");
        }



    }

}