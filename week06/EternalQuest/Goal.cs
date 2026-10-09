public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    protected string GetName()
    {
        return _name;
    }

    protected string GetDescription()
    {
        return _description;
    }

    protected int GetPoints()
    {
        return _points;
    }

    // Each derived class decides what recording an event does.
    // Returns the points earned (can be zero or negative).
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetStringRepresentation();

    // Default display. Only ChecklistGoal needs to change it.
    public virtual string GetDetailsString()
    {
        string box = " ";
        if (IsComplete())
        {
            box = "X";
        }

        return $"[{box}] {_name} ({_description})";
    }
}