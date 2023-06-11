using System;
using System.Threading;


class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Self-Care App!");

        while (true)
        {
            Console.WriteLine("\nPlease select an activity to start:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            Console.WriteLine();

            Activity activity;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Self-Care App. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            activity.Run();

            Console.WriteLine("\nWould you like to continue using the Self-Care App? (Y/N): ");
            string continueChoice = Console.ReadLine();

            if (continueChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thank you for using the Self-Care App. Goodbye!");
                break;
            }
        }
    }
}