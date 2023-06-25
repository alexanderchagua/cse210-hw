public abstract class Goal
{
    protected string _name;
    protected internal int _value;
    public string Description { get; protected set; }

    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

    public Goal(string name)
    {
        _name = name;
        _value = 0;
    }

    public abstract void MarkComplete();

    public virtual void Display()
    {
        Console.WriteLine($"[{_name}] ({Description})");
        
    }

    public virtual void Display(bool isCompleted)
    {
        string completionMark = isCompleted ? "[x]" : "[]";
        Console.WriteLine($"{completionMark} {_name} ({Description})");
       
    }

    public virtual string GetSaveString()
    {
        return $"{GetType().Name.ToLower()}: {_name}, {Description}, {_value}";
    }
}