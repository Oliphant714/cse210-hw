using System.Text.Json;

public static class SaveLoad
{
    private static string BasePath => "./data";
    private static string PartyPath => Path.Combine(BasePath, "parties");
    private static string EnemyFile => Path.Combine(BasePath, "enemies.json");
    private static string WeaponFile => Path.Combine(BasePath, "weapons.json");

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
        List<EnemyCharacter> enemies = LoadEnemies();
        enemies.Add(enemy);
        File.WriteAllText(EnemyFile, JsonSerializer.Serialize(enemies, new JsonSerializerOptions { WriteIndented = true }));
    }

    public static List<EnemyCharacter> LoadEnemies()
    {
        if (!File.Exists(EnemyFile)) return new();
        return JsonSerializer.Deserialize<List<EnemyCharacter>>(File.ReadAllText(EnemyFile));
    }

    public static void AddWeapon(Weapon weapon)
    {
        List<Weapon> weapons = LoadWeapons();
        weapons.Add(weapon);
        File.WriteAllText(WeaponFile, JsonSerializer.Serialize(weapons, new JsonSerializerOptions { WriteIndented = true }));
    }

    public static List<Weapon> LoadWeapons()
    {
        if (!File.Exists(WeaponFile)) return new();
        return JsonSerializer.Deserialize<List<Weapon>>(File.ReadAllText(WeaponFile));
    }

    public static List<string> GetPartyNames()
    {
        Directory.CreateDirectory(PartyPath);
        return Directory.GetFiles(PartyPath, "*.json").Select(Path.GetFileNameWithoutExtension).ToList();
    }
}