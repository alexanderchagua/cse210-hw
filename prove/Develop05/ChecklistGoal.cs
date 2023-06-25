public class ChecklistGoal : Goal
{
     protected internal int TargetTimes { get; set; }
    protected internal int CompletedTimes { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, int targetTimes, int bonusPoints, string description) : base(name)
    {
        TargetTimes = targetTimes;
        CompletedTimes = 0;
        BonusPoints = bonusPoints;
        Description = description;
    }
    public override void MarkComplete()
    {
        CompletedTimes++;
        if (CompletedTimes >= TargetTimes)
        {
            _value += BonusPoints;
        }
    }

    public override void Display()
    {
        bool isCompleted = CompletedTimes >= TargetTimes;
        base.Display(isCompleted);
        Console.WriteLine($"Completed Times: {CompletedTimes}/{TargetTimes}");
    }

    public override string GetSaveString()
    {
        return $"{base.GetSaveString()}, {BonusPoints}, {CompletedTimes}, 0";
    }
    public override void Display(bool isCompleted)
{
    string completionMark = isCompleted ? "[x]" : "[]";
    string completionStatus = $"{CompletedTimes}/{TargetTimes}";
    Console.WriteLine($"{completionMark} {_name} ({Description}) -- currently completed: {completionStatus}");
    
}
}