class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points) { }

    public override int Complete()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return Points;
        }
        return 0;
    }

    public override string Status()
    {
        return IsComplete ? "[X] " + Name : "[ ] " + Name;
    }
}