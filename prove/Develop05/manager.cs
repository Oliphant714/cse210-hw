class GameManager
{
    private List<Goal> _goals = new List<Goal>();
    private BossMonster _boss;
    private int _score;
    private int _bossLevel;
    
    public GameManager()
    {
        _score = 0;
        _bossLevel = 1;
        GenerateNewBoss();
    }
    
    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }
    
    private void GenerateNewBoss()
    {
        _boss = new BossMonster($"Boss Monster Lv. {_bossLevel}", _bossLevel * 100);
    }
    
    public void CompleteGoal(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].Complete();
            _score += pointsEarned;
            _boss.TakeDamage(pointsEarned);
            
            Console.WriteLine($"You earned {pointsEarned} points!");
            if (_boss.IsDefeated())
            {
                Console.WriteLine($"You defeated {_boss.Name}!");
                _bossLevel++;
                GenerateNewBoss();
            }
        }
    }
    
    public void ShowGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Status()}");
        }
    }
    
    public void ShowStatus()
    {
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine(_boss.Status());
    }
}