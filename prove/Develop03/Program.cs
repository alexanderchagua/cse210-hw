using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of writes
        List<Scripture> scriptures = new List<Scripture>();
        
        // Add three writes to the list with their respective details
        scriptures.Add(new Scripture("Moroni", 10, 3, 4, "Behold, I would exhort you that when ye shall read these things, if it be wisdom in God that ye should read them, that ye would remember how amerciful the Lord hath been unto the children of men, from the creation of Adam even down until the time that ye shall receive these things, and bponder it in your chearts. And when ye shall receive these things, I would exhort you that ye would aask God, the Eternal Father, in the name of Christ, if these things are not btrue; and if ye shall ask with a csincere heart, with dreal intent, having efaith in Christ, he will fmanifest the gtruth of it unto you, by the power of the Holy Ghost."));
        scriptures.Add(new Scripture("Ether", 12, 27, "And if men come unto me I will show unto them their aweakness. I bgive unto men weakness that they may be humble; and my cgrace is sufficient for all men that dhumble themselves before me; for if they humble themselves before me, and have faith in me, then will I make eweak things become strong unto them."));
        scriptures.Add(new Scripture("DyC", 38, 27, "Desead, como niños recién nacidos."));

        // Create a library of scripts and pass the list of scripts to the constructor
        ScriptureLibrary library = new ScriptureLibrary(scriptures);

        Console.WriteLine("Press enter to start the program.");
        Console.ReadLine();

        Console.Clear();

        // Get a random write from the library
        Scripture randomScripture = library.GetRandomScripture();

        // Display the reference and the text of the selected script
        Console.WriteLine(randomScripture.ToString());

        Console.WriteLine("Press enter to hide a random word or type 'quit' to exit.");

        string input = Console.ReadLine();
        while (input != "quit")
        {
            Console.Clear();

            // Hide a random word in the script
            randomScripture.HideRandomWord();

            // Show the updated spelling with the hidden word
            Console.WriteLine(randomScripture.ToString());

           // Check if all words are hidden
            if (randomScripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden! Press any key to exit.");

                // Wait for the user to press any key to exit
                Console.ReadKey();
                return;
            }

            input = Console.ReadLine();
        }
    }
}