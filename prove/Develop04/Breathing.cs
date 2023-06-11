class BreathingActivity : Activity
{
    private static int activityCount = 0;

    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by focusing on slow, deep breathing. Clear your mind and concentrate on your breath.";
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int duration = GetDuration();

        PerformActivity();

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int breathCount = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in... ");
            PerformBreathingAnimation(duration / 4, true);
            Console.WriteLine();
            Thread.Sleep(2000);

            Console.Write("Breathe out... ");
            PerformBreathingAnimation(duration / 4, false);
            Console.WriteLine();
            Thread.Sleep(2000);

            breathCount++;
        }

        DisplayEndingMessage(duration);
        activityCount++;
        Console.WriteLine($"\nYou have completed another {activityCount} sessions of the Breathing Activity.");
    }
     // Performs the breathing animation
    private void PerformBreathingAnimation(int animationDuration, bool increasing)
    {
        if (animationDuration <= 0)
        {
            Console.WriteLine("Invalid animation duration.");
            return;
        }

        int _startNumber = increasing ? animationDuration : 1;
        int _endNumber = increasing ? 1 : animationDuration;
        int _numCount = Math.Abs(_endNumber - _startNumber) + 1;
        int _sleepTime = animationDuration * 1000 / (_numCount * 2);

        for (int i = _startNumber; increasing ? i >= _endNumber : i <= _endNumber; i += increasing ? -1 : 1)
        {
            Thread.Sleep(_sleepTime);
            Console.Write(i);
            Thread.Sleep(_sleepTime);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }
}