using System;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _activityCount;

    public abstract void Run();

    protected int GetDuration()
    {
        Console.Write("Enter the duration in seconds: ");
        int duration = Convert.ToInt32(Console.ReadLine());
        return duration;
    }

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine(_description);
    }

    protected void DisplayEndingMessage(int duration)
    {
        Console.WriteLine("\nGreat job! You have completed the activity.");
        Console.WriteLine($"You spent {duration} seconds on the {_name} Activity.");
        Console.WriteLine("Take a moment to reflect and relax.");
        Thread.Sleep(3000);
    }

    protected virtual void PerformActivity()
    {
        Console.WriteLine("\nGet ready...");
        Thread.Sleep(2000);

        Console.Write("/");
        for (int i = 0; i < 4; i++)
        {
            Thread.Sleep(250);
            Console.Write("\b\\");
            Thread.Sleep(250);
            Console.Write("\b/");
            Thread.Sleep(250);
            Console.Write("\b ");
        }
        Console.WriteLine(" ");
    }
}