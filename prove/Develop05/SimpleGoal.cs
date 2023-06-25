public class SimpleGoal : Goal
{
    public int Points { get; set; } 

    public SimpleGoal(string name, int points, string description) : base(name)
    {
        Points = points;
        Description = description;
    }

    public override void MarkComplete()
    {
        _value += Points;
    }

    public override string GetSaveString()
    {
        return $"{base.GetSaveString()}, False";
    }
}
