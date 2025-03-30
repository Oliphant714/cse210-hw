public class AbilityScores
{
    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }

    public AbilityScores(int strength, int dexterity, int constitution, 
                         int intelligence, int wisdom, int charisma)
    {
        Strength = strength;
        Dexterity = dexterity;
        Constitution = constitution;
        Intelligence = intelligence;
        Wisdom = wisdom;
        Charisma = charisma;
    }

    public int GetModifier(int score) => (score - 10) / 2;

    public int StrengthModifier => GetModifier(Strength);
    public int DexterityModifier => GetModifier(Dexterity);
    public int ConstitutionModifier => GetModifier(Constitution);
    public int IntelligenceModifier => GetModifier(Intelligence);
    public int WisdomModifier => GetModifier(Wisdom);
    public int CharismaModifier => GetModifier(Charisma);

    public void IncreaseAbility(int choice)
    {
        switch (choice)
        {
            case 1: Strength++; break;
            case 2: Dexterity++; break;
            case 3: Constitution++; break;
            case 4: Intelligence++; break;
            case 5: Wisdom++; break;
            case 6: Charisma++; break;
            default: Strength++; break;
        }
    }

    public static int GenerateRandom()
{
    Random random = new Random();
    return random.Next(8, 18); // D&D Ability Score Range
}

}
