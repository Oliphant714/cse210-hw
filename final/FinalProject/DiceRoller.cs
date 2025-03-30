public static class DiceRoller
{
    private static Random _rng = new Random();

    public static int Roll(int numberOfDice, int sides)
    {
        int total = 0;
        for (int i = 0; i < numberOfDice; i++)
        {
            total += _rng.Next(1, sides + 1);
        }
        return total;
    }

    public static int RollWithAdvantage(int sides)
    {
        int roll1 = Roll(1, sides);
        int roll2 = Roll(1, sides);
        return Math.Max(roll1, roll2);
    }

    public static int RollWithDisadvantage(int sides)
    {
        int roll1 = Roll(1, sides);
        int roll2 = Roll(1, sides);
        return Math.Min(roll1, roll2);
    }
}
