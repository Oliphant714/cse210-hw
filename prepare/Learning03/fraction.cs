using System;
public class Fraction
{
    private int _topNum;
    private int _botNum;

    public Fraction() //Constructing the default values
    {
        _topNum = 1;
        _botNum = 1;
    }

    public Fraction(int topInput) //Setting the default denominator to 0 if there is no denominator input
    {
        _topNum = topInput;
        _botNum = 1;
    }

    public Fraction(int topInput, int botInput) //Gives the ability to change both numerator and denominator
    {
        _topNum = topInput;
        _botNum = botInput;
    }

    public string WrittenFraction() //Writes the fraction: 3/4
    {
        string ftext = $"{_topNum}/{_botNum}";
        return ftext;
    }

    public double FractionDecimal() //Checks for a zero possibility and computes the decimal: 0.75
    {
        return (double)_topNum/(double)_botNum;
    }
}