using System.Text.Json.Serialization;

public abstract class Goal
{
    [JsonIgnore]
    public string Type => GetType().Name; // Use class name as the type

    public string Name { get; protected set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }

    public abstract int Complete();
    public abstract string Status();
}
