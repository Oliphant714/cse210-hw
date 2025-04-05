using System.Text.Json;

public static class SaveLoad
{
    private static string BasePath => "./data";
    private static string PartyPath => Path.Combine(BasePath, "parties");
    private static string EnemyFile => Path.Combine(BasePath, "enemies.json");
    private static string WeaponFile => Path.Combine(BasePath, "weapons.json");

    public static List<EnemyCharacter> AllEnemies { get; private set; } = new();
    public static List<Weapon> AllWeapons { get; private set; } = new();

    public static void Initialize()
    {
        Directory.CreateDirectory(PartyPath);
        LoadAllEnemies();
        LoadAllWeapons();
    }

    public static void SaveParty(Party party)
    {
        Directory.CreateDirectory(PartyPath);
        string json = JsonSerializer.Serialize(party, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(Path.Combine(PartyPath, party.PartyName + ".json"), json);
    }

    public static Party LoadParty(string name)
    {
        string path = Path.Combine(PartyPath, name + ".json");
        if (!File.Exists(path)) return null;
        return JsonSerializer.Deserialize<Party>(File.ReadAllText(path));
    }

    public static void AddEnemy(EnemyCharacter enemy)
    {
        AllEnemies.Add(enemy);
        SaveAllEnemies();
    }

    public static void SaveAllEnemies()
    {
        File.WriteAllText(EnemyFile, JsonSerializer.Serialize(AllEnemies, new JsonSerializerOptions { WriteIndented = true }));
    }

    public static void LoadAllEnemies()
    {
        if (File.Exists(EnemyFile))
        {
            var enemies = JsonSerializer.Deserialize<List<EnemyCharacter>>(File.ReadAllText(EnemyFile));
            if (enemies != null) AllEnemies = enemies;
        }
    }
    public static void OverwriteEnemies(List<EnemyCharacter> enemies)
{
    File.WriteAllText(EnemyFile, JsonSerializer.Serialize(enemies, new JsonSerializerOptions { WriteIndented = true }));
}


    public static EnemyCharacter GetEnemyByName(string name)
    {
        return AllEnemies.FirstOrDefault(e => e.CharacterName.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public static void AddWeapon(Weapon weapon)
    {
        AllWeapons.Add(weapon);
        SaveAllWeapons();
    }

    public static void SaveAllWeapons()
    {
        File.WriteAllText(WeaponFile, JsonSerializer.Serialize(AllWeapons, new JsonSerializerOptions { WriteIndented = true }));
    }

    public static void LoadAllWeapons()
    {
        if (File.Exists(WeaponFile))
        {
            var weapons = JsonSerializer.Deserialize<List<Weapon>>(File.ReadAllText(WeaponFile));
            if (weapons != null) AllWeapons = weapons;
        }
    }

    public static List<string> GetPartyNames()
    {
        Directory.CreateDirectory(PartyPath);
        return Directory.GetFiles(PartyPath, "*.json").Select(Path.GetFileNameWithoutExtension).ToList();
    }
}
