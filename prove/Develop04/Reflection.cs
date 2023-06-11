class ReflectionActivity : Activity
{
    private static int activityCount = 0;

    private readonly string[] _prompts = {
        "Think of a moment when you stood up for someone else.",
        "Think of a moment when you did something really challenging.",
        "Think of a moment when you helped someone in need.",
        "Think of a moment when you did something truly selfless."
    };

    private readonly string[] _questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you start?",
        "What made this time different from other times when you weren't as successful?",
        "What is your favorite thing about this experience?",
        "What can you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind for the future?"
    };

    protected override void PerformActivity()
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

    public override void Run()
    {
        Console.WriteLine($"Welcome to the Reflecting Activity.");
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
        Console.WriteLine("It will help you recognize the power you have and how you can use it in other aspects of your life.");

        int _duration = GetDuration();
        PerformActivity();

        DateTime _endTime = DateTime.Now.AddSeconds(_duration);
        Random random = new Random();
        int reflectionCount = 0;

        while (DateTime.Now < _endTime)
        {
            Console.WriteLine("\nConsider the following prompt:");
            Console.WriteLine("---Think of a time when you did something really difficult.---");
            Console.WriteLine("When you have something in mind, press enter to continue.");

            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.WriteLine("You may begin in:");

            for (int i = 5; i >= 1; i--)
            {
                Console.Write("* ");
                Thread.Sleep(1000);
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.Write("How did you feel when it was complete? /");

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

            string randomQuestion = _questions[random.Next(_questions.Length)];
            Console.Write($"{randomQuestion} /");

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

            reflectionCount++;
        }

        Console.WriteLine("\nWell done!");

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

        activityCount++;
        Console.WriteLine($"\nYou have completed another {activityCount} sessions of the Reflecting Activity.");

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