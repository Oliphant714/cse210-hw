using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment firstStudent = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(firstStudent.GetSummary());

        MathAssignment secondStudent = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(secondStudent.GetSummary());
        Console.WriteLine(secondStudent.GetHomeworkList());

        WritingAssignment thirdStudent = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(thirdStudent.GetSummary());
        Console.WriteLine(thirdStudent.GetWritingInformation());
    }
}