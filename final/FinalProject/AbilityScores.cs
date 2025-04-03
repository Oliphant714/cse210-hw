namespace FinalProject;
using System;
public class AbilityScores
{
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }

    public AbilityScores()
    {
        Strength = 10;
        Dexterity = 10;
        Constitution = 10;
        Intelligence = 10;
        Wisdom = 10;
        Charisma = 10;
    }
    public AbilityScores(int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma)
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

    public static AbilityScores GenerateRandom()
    {
        Random random = new Random();
        int strength = random.Next(8, 18);
        int dexterity = random.Next(8, 18);
        int constitution = random.Next(8, 18);
        int intelligence = random.Next(8, 18);
        int wisdom = random.Next(8, 18);
        int charisma = random.Next(8, 18);

        return new AbilityScores(strength, dexterity, constitution, intelligence, wisdom, charisma);
    }

}
