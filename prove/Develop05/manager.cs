class GoalManager
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1) Simple 2) Eternal 3) Checklist");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                goals.Add(new SimpleGoal(name, points));
                break;
            case 2:
                goals.Add(new EternalGoal(name, points));
                break;
            case 3:
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, points, target, bonus));
                break;
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        int index = int.Parse(Console.ReadLine()) - 1;
        score += goals[index].RecordEvent();
    }

    public void ShowGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
        Console.WriteLine($"Current Score: {score}");
    }
}
