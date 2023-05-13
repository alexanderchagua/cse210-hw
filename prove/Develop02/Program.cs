using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true) {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1.Write");
            Console.WriteLine("2.Display");
            Console.WriteLine("3.Save");
            Console.WriteLine("4.Load");
            Console.WriteLine("5.Quit");

            string input = Console.ReadLine();

            switch (input) {
                case "1":
                    Console.WriteLine(journal.RandomPrompt());
                    string response = Console.ReadLine();
                    journal.AddEntry(response);
                    break;
                case "2":
                    journal.ShowEntries();
                    break;
                case "3":
                    Console.WriteLine("Enter the file name:");
                    string fileName = Console.ReadLine();
                    journal.SaveToFile(fileName);
                    break;
                case "4":
                    Console.WriteLine("Enter the file name:");
                    fileName = Console.ReadLine();
                    journal.LoadFromFile(fileName);
                    break;
                case "5":
                    return;
            }
        }
    }
}