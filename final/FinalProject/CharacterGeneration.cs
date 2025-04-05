public static class CharacterGeneration
{
    public static Party CreateNewParty()
    {
        Console.Write("Enter party name: ");
        string name = Console.ReadLine();
        Party party = new() { PartyName = name };

        Console.Write("How many players in the party? ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nEnter info for Player {i + 1}:");
            Console.Write("Name: "); string charName = Console.ReadLine();
            Console.Write("Class: "); string classType = Console.ReadLine();
            Console.Write("HP: "); int hp = int.Parse(Console.ReadLine());
            Console.Write("AC: "); int ac = int.Parse(Console.ReadLine());
            Console.Write("Passive Perception: "); int pp = int.Parse(Console.ReadLine());

            party.Members.Add(new PlayerCharacter {
                CharacterName = charName, ClassType = classType, HitPoints = hp, ArmorClass = ac, PassivePerception = pp
            });
        }

        SaveLoad.SaveParty(party);
        return party;
    }

    public static EnemyCharacter CreateEnemy()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Creature Type: "); string type = Console.ReadLine();
        Console.Write("HP: "); int hp = int.Parse(Console.ReadLine());
        Console.Write("AC: "); int ac = int.Parse(Console.ReadLine());
        Console.Write("Passive Perception: "); int pp = int.Parse(Console.ReadLine());
        Console.Write("Attack Modifier: "); int atkMod = int.Parse(Console.ReadLine());
        Console.Write("Spell Save DC: "); int saveDC = int.Parse(Console.ReadLine());
        Console.Write("Proficiency Bonus: "); int pb = int.Parse(Console.ReadLine());

        EnemyCharacter enemy = new()
        {
            CharacterName = name, CreatureType = type, HitPoints = hp, ArmorClass = ac,
            PassivePerception = pp, AttackModifier = atkMod, SpellSaveDC = saveDC, ProficiencyBonus = pb
        };

        SaveLoad.AddEnemy(enemy);
        return enemy;
    }
}