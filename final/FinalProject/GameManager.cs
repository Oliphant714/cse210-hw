namespace FinalProject;
public class GameManager
{
    private Party _party;
    private List<Enemy> _enemies;

    public GameManager()
    {
        _party = new Party();
        _enemies = new List<Enemy>();
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to the D&D Combat Simulator!");
        
        // Create player characters
        AbilityScores warriorAbilities = new AbilityScores(16, 12, 14, 10, 10, 8);
        PlayerCharacter warrior = new PlayerCharacter("Aric", 3, 30, 16, warriorAbilities, 2, "Slashing", "Fighter");
        
        AbilityScores wizardAbilities = new AbilityScores(8, 14, 12, 16, 12, 10);
        PlayerCharacter wizard = new PlayerCharacter("Elara", 3, 18, 12, wizardAbilities, 2, "Fire", "Wizard");

        _party.AddMember(warrior);
        _party.AddMember(wizard);

        // Create enemies
        AbilityScores goblinAbilities = new AbilityScores(10, 14, 12, 8, 10, 8);
        Enemy goblin = new Enemy("Goblin", 1, 15, 13, goblinAbilities, 2, "Piercing", "Goblin", 1);
        
        AbilityScores orcAbilities = new AbilityScores(16, 12, 14, 8, 10, 8);
        Enemy orc = new Enemy("Orc", 2, 20, 14, orcAbilities, 2, "Slashing", "Orc", 2);

        _enemies.Add(goblin);
        _enemies.Add(orc);

        StartEncounter();
    }

  
        public void StartEncounter()
{
    EncounterManager encounter = new EncounterManager();
        encounter.StartEncounter();
}

    
}
