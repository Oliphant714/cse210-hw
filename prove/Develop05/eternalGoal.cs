class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override int RecordEvent()
    {
        return points; // Always earns points
    }

    public override string GetStatus()
    {
        return "[∞] " + name; // Always open
    }
}
