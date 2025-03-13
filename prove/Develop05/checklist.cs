class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;
    
    public ChecklistGoal(string name, int points, int targetCount, int bonus) : base(name, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonus = bonus;
    }
    
    public override int Complete()
    {
        if (!IsComplete)
        {
            _currentCount++;
            if (_currentCount >= _targetCount)
            {
                IsComplete = true;
                return Points + _bonus;
            }
            return Points;
        }
        return 0;
    }
    
    public override string Status()
    {
        return (IsComplete ? "[X] " : "[ ] ") + Name + $" (Completed {_currentCount}/{_targetCount})";
    }
}