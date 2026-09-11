using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    // Adds an entry to the journal.
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Displays every entry in the journal.
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves all journal entries to a file.
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(
                    $"{entry._date}~|~{entry._promptText}~|~{entry._entryText}~|~{entry._mood}"
                );
            }
        }

        Console.WriteLine($"Journal saved to {filename}\n");
    }

    // Loads journal entries from a file.
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.\n");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split(
                new string[] { "~|~" },
                StringSplitOptions.None
            );

            if (parts.Length == 4)
            {
                Entry entry = new Entry();

                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                entry._mood = parts[3];

                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Journal loaded from {filename}\n");
    }
}