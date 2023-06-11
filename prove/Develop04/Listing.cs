class ListingActivity : Activity
{
    private static int activityCount = 0;

    private readonly string[] _prompts = {
        "Who are the people you appreciate?",
        "What are your personal strengths?",
        "Who are the people you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
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
        Console.WriteLine("Welcome to the Listing Activity.");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        int _duration = GetDuration();
        PerformActivity();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        Random random = new Random();
        int itemCount = 0;

        while (DateTime.Now < endTime)
        {
            string randomPrompt = _prompts[random.Next(_prompts.Length)];
            Console.WriteLine($"\nList as many responses as you can to the following prompt:\n---{randomPrompt}---");
            Console.WriteLine("You may begin in:");

            for (int i = 5; i >= 1; i--)
            {
                Console.Write("* ");
                Thread.Sleep(1000);
                Console.Write(" ");
            }

            Console.WriteLine();

            Console.WriteLine("Start typing your responses (press enter after each response):");

            while (DateTime.Now < endTime)
            {
                string response = Console.ReadLine();
                if (string.IsNullOrEmpty(response))
                    break;

                itemCount++;
            }
        }

        Console.WriteLine($"\nYou listed {itemCount} items!");

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
        Console.WriteLine($"\nYou have completed another {activityCount} sessions of the Listing Activity.");

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