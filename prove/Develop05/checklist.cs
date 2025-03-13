class ChecklistGoal : Goal
{
    private int target;
    private int completed;
    private int bonus;

    public ChecklistGoal(string name, int points, int target, int bonus) : base(name, points)
    {
        this.target = target;
        this.completed = 0;
        this.bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (completed < target)
        {
            completed++;
            return completed == target ? points + bonus : points; // Bonus at completion
        }
        return 0;
    }

    public override string GetStatus()
    {
        return completed >= target ? "[X] " + name + " (Completed)" : $"[ ] {name} ({completed}/{target})";
    }
}
