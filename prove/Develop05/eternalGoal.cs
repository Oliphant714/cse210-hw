class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }
    public override int Complete()
    {
        return Points;
    }
    public override string Status()
    {
        return "[∞] " + Name;
    }
}
