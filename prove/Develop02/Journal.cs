using System;
using System.Collections.Generic;
using System.IO;

class Journal {
    public List<Entry> entries = new List<Entry>();
    public Random random = new Random();
    public List<string> prompts = new List<string>() {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry(string response) {
        Entry entry = new Entry() {
            Prompt = prompts[random.Next(prompts.Count)],
            Response = response,
            Date = DateTime.Now
        };
        entries.Add(entry);
    }

    public void ShowEntries() {
        foreach (Entry entry in entries) {
            Console.WriteLine($"[{entry.Date}] {entry.Prompt}: {entry.Response}");
        }
    }

    public void SaveToFile(string fileName) {
        //in this part use streamWiter to be able to create a csv or txt file
        using (StreamWriter writer = new StreamWriter(fileName)) {
            foreach (Entry entry in entries) {
                writer.WriteLine($"{entry.Prompt},{entry.Response},{entry.Date}");
            }
        }
    }

    public void LoadFromFile(string fileName) {
        entries.Clear();
        // in this part of loading the program also streamreader help to load csv files as txt
        using (StreamReader reader = new StreamReader(fileName)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                string[] parts = line.Split(',');
                Entry entry = new Entry() {
                    Prompt = parts[0],
                    Response = parts[1],
                    Date = DateTime.Parse(parts[2])
                };
                entries.Add(entry);
            }
        }
    }

    public string RandomPrompt() {
        return prompts[random.Next(prompts.Count)];
    }
}
