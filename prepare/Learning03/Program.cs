using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.WrittenFraction());
        Console.WriteLine(f1.FractionDecimal());

        Fraction f2 = new Fraction(6);
        Console.WriteLine(f2.WrittenFraction());
        Console.WriteLine(f2.FractionDecimal());

        Fraction f3 = new Fraction(6,7);
        Console.WriteLine(f3.WrittenFraction());
        Console.WriteLine(f3.FractionDecimal());

    }









}