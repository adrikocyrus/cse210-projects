using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private readonly Random _random;

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
        _random = new Random();
    }

    protected string Name
    {
        get { return _name; }
    }

    protected string Description
    {
        get { return _description; }
    }

    protected int Duration
    {
        get { return _duration; }
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"--- {Name} ---");
        Console.WriteLine();
        Console.WriteLine(Description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");

        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a positive number of seconds: ");
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        Console.WriteLine();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed the {Name} for {Duration} seconds.");
        Console.WriteLine();
        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            index++;

            if (index >= spinner.Length)
            {
                index = 0;
            }
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string text = i.ToString();

            Console.Write(text);
            Thread.Sleep(1000);

            // Erase every digit so multi-digit numbers (10, 11...) clear correctly.
            Console.Write(new string('\b', text.Length));
            Console.Write(new string(' ', text.Length));
            Console.Write(new string('\b', text.Length));
        }
    }

    protected int GetElapsedSeconds(DateTime startTime)
    {
        return (int)(DateTime.Now - startTime).TotalSeconds;
    }

    protected int GetRemainingSeconds(DateTime startTime)
    {
        return Duration - GetElapsedSeconds(startTime);
    }

    // Returns a random item and removes it from "remaining".
    // When "remaining" is empty it is refilled from "source", so nothing
    // repeats until every item has been used once.
    protected string GetRandomItem(List<string> remaining, List<string> source)
    {
        if (remaining.Count == 0)
        {
            remaining.AddRange(source);
        }

        int index = _random.Next(remaining.Count);
        string item = remaining[index];
        remaining.RemoveAt(index);

        return item;
    }

    // Reads a line without blocking past the session deadline.
    // Returns false when time runs out before the user presses Enter.
    protected bool TryReadLine(DateTime startTime, out string text)
    {
        DateTime deadline = startTime.AddSeconds(Duration);
        StringBuilder buffer = new StringBuilder();
        text = "";

        while (DateTime.Now < deadline)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    text = buffer.ToString();
                    return true;
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (buffer.Length > 0)
                    {
                        buffer.Length--;
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    buffer.Append(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }
            else
            {
                Thread.Sleep(50);
            }
        }

        Console.WriteLine();
        return false;
    }

    public abstract void Run();
}