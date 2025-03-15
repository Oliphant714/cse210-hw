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

    public void CreateGoal()
    {
        Console.Clear();
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter choice: ");
        
        string choice = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter point value: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (choice)
        {
            case "1": 
                newGoal = new SimpleGoal(name, points);
                break;
            case "2": 
                newGoal = new EternalGoal(name, points);
                break;
            case "3":
                Console.Write("Enter required completions: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, points, targetCount, bonusPoints);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal added successfully!");
    }

    private void GenerateNewBoss()
    {
        int bossHealth = _bossLevel * 100;
        _boss = new BossMonster($"Boss Monster Lv. {_bossLevel}", bossHealth);
        Console.WriteLine($"\nA new boss appears: {_boss.Name} with {bossHealth} HP!\n");
    }
    
    public void CompleteGoal(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].Complete();
            _score += pointsEarned;
            _boss.TakeDamage(pointsEarned);
            
            Console.WriteLine($"\nYou earned {pointsEarned} points!");
            Console.WriteLine($"{_boss.Name} took {pointsEarned} damage!");
            Console.WriteLine(_boss.Status());

            if (_boss.IsDefeated())
            {
                Console.WriteLine($"You defeated {_boss.Name}!");
                _bossLevel++;
                GenerateNewBoss();
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
    
    public void ShowGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals set yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Status()}");
        }
    }
    
    public void ShowStatus()
    {
        Console.WriteLine($"\nScore: {_score}");
        Console.WriteLine(_boss.Status());
    }
}
