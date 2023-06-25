using System;
using System.Collections.Generic;
using System.IO;

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

public class EternalGoal : Goal
{
    public int Points { get; set; }

    public EternalGoal(string name, int points, string description) : base(name)
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
        return $"{base.GetSaveString()}, 10";
    }
}

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

public class Program
{
    public static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int points = 0;

        while (true)
        {
            Console.WriteLine($"You have {points} points.");
            Console.WriteLine();
            Console.WriteLine("MENU OPTIONS:");
            Console.WriteLine("1. Create new goal");
            Console.WriteLine("2. List goals");
            Console.WriteLine("3. Save goals to file");
            Console.WriteLine("4. Load goals from file");
            Console.WriteLine("5. Record event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine("1. Simple Goal");
                Console.WriteLine("2. Eternal Goal");
                Console.WriteLine("3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");

                string goalType = Console.ReadLine();

                Console.Write("What is the name of your goal? ");
                string goalName = Console.ReadLine();

                if (goalType == "1")
                {
                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();

                    Console.Write("What is the amount of points associated with this goal? ");
                    int goalPoints = Convert.ToInt32(Console.ReadLine());

                    SimpleGoal simpleGoal = new SimpleGoal(goalName, goalPoints, description);
                    goals.Add(simpleGoal);
                }
                else if (goalType == "2")
                {
                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();

                    Console.Write("What is the amount of points associated with this goal? ");
                    int goalPoints = Convert.ToInt32(Console.ReadLine());

                    EternalGoal eternalGoal = new EternalGoal(goalName, goalPoints, description);
                    goals.Add(eternalGoal);
                }
                else if (goalType == "3")
                {
                    Console.Write("What is a short description of it? ");
                    string description = Console.ReadLine();

                    Console.Write("What is the target times for the goal? ");
                    int targetTimes = Convert.ToInt32(Console.ReadLine());

                    Console.Write("What is the bonus points for the goal? ");
                    int bonusPoints = Convert.ToInt32(Console.ReadLine());

                    ChecklistGoal checklistGoal = new ChecklistGoal(goalName, targetTimes, bonusPoints, description);
                    goals.Add(checklistGoal);
                }

                Console.WriteLine("Goal created successfully.");
                Console.WriteLine();
            }
            else if (choice == "2")
            {
                Console.WriteLine("The goals are:");

                for (int i = 0; i < goals.Count; i++)
                {
                    bool isCompleted = goals[i]._value > 0;
                    Console.Write($"{i + 1}. ");
                    goals[i].Display(isCompleted);
                    Console.WriteLine();
                }
            }
            else if (choice == "3")
            {
                Console.Write("Enter file name to save goals: ");
                string fileName = Console.ReadLine();
                SaveGoalsToFile(goals, fileName);
                Console.WriteLine("Goals saved to file.");
                Console.WriteLine();
            }
            else if (choice == "4")
            {
                Console.Write("Enter file name to load goals from: ");
                string fileName = Console.ReadLine();
                goals = LoadGoalsFromFile(fileName);
                Console.WriteLine("Goals loaded from file.");
                Console.WriteLine();
            }
            else if (choice == "5")
            {
                Console.WriteLine("The goals are:");

                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. [{goals[i].Name}]");
                }

                Console.Write("Which goal did you accomplish? Enter goal number: ");
                int goalNumber = Convert.ToInt32(Console.ReadLine()) - 1;

                if (goalNumber >= 0 && goalNumber < goals.Count)
                {
                    Goal accomplishedGoal = goals[goalNumber];
                    accomplishedGoal.MarkComplete();

                    Console.WriteLine($"Congratulations! You have earned {accomplishedGoal._value} points!");
                    points += accomplishedGoal._value;

                    Console.WriteLine($"You now have {points} points.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid goal number.");
                    Console.WriteLine();
                }
            }
            else if (choice == "6")
            {
                Console.WriteLine("Exiting program...");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option from the menu.");
                Console.WriteLine();
            }
        }
    }

    public static void SaveGoalsToFile(List<Goal> goals, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Goal goal in goals)
            {
                if (goal is SimpleGoal simpleGoal)
                {
                    writer.WriteLine($"simple goal:{simpleGoal.Name},{simpleGoal.Description},{simpleGoal.Points},{simpleGoal._value}");
                }
                else if (goal is EternalGoal eternalGoal)
                {
                    writer.WriteLine($"eternal goal:{eternalGoal.Name},{eternalGoal.Description},{eternalGoal.Points},{eternalGoal._value}");
                }
                else if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"checklist goal:{checklistGoal.Name},{checklistGoal.Description},{checklistGoal.BonusPoints},{checklistGoal.TargetTimes},{checklistGoal.CompletedTimes},{checklistGoal._value}");
                }
            }
        }
    }

    public static List<Goal> LoadGoalsFromFile(string fileName)
    {
        List<Goal> loadedGoals = new List<Goal>();

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                string goalName = goalData[0];
                string description = goalData[1];

                if (goalType == "simple goal")
                {
                    int points = Convert.ToInt32(goalData[2]);
                    

                    SimpleGoal simpleGoal = new SimpleGoal(goalName, points, description);
                  
                    loadedGoals.Add(simpleGoal);
                }
                else if (goalType == "eternal goal")
                {
                    int points = Convert.ToInt32(goalData[2]);
                

                    EternalGoal eternalGoal = new EternalGoal(goalName, points, description);
                    loadedGoals.Add(eternalGoal);
                }
                else if (goalType == "checklist goal")
                {
                    int bonusPoints = Convert.ToInt32(goalData[2]);
                    int targetTimes = Convert.ToInt32(goalData[3]);
                    int completedTimes = Convert.ToInt32(goalData[4]);
                    

                    ChecklistGoal checklistGoal = new ChecklistGoal(goalName, targetTimes, bonusPoints, description);
                    checklistGoal.CompletedTimes = completedTimes;
                   
                    loadedGoals.Add(checklistGoal);
                }
            }
        }

        return loadedGoals;
    }
}