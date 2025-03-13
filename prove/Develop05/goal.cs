abstract class Goal
{
    protected string name;
    protected int points;
    
    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
    }

    public abstract int RecordEvent(); // Polymorphism: Different goals override this
    public abstract string GetStatus(); // Polymorphism: Different goals display status differently
}
