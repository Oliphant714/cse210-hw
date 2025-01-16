using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers; type 0 when finished.");
        
        int userNumber;
        List<int> numbers = new List<int>();
        int listSum = 0;
        int listAvg = 0;
        int listMax = 0;

    do {
        Console.Write("Enter a number: ");
        userNumber = int.Parse(Console.ReadLine());
        numbers.Add(userNumber);
    }   while (userNumber != 0); 

    foreach (int number in numbers)
    {
        listSum = listSum + number;
        if (number > listMax)
        {
            listMax = number;
        }
    }
    
    Console.WriteLine($"The sum is: {listSum}");
    listAvg = listSum / numbers.Count;
    Console.WriteLine($"The average is: {listAvg}");
    Console.WriteLine($"The largest number is: {listMax}");
    }
}