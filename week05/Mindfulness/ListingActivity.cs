using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts;
    private readonly List<string> _remainingPrompts;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _remainingPrompts = new List<string>(_prompts);
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = GetRandomItem(_remainingPrompts, _prompts);

        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each one.");
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        List<string> items = new List<string>();

        while (GetRemainingSeconds(startTime) > 0)
        {
            Console.Write($"{items.Count + 1}: ");

            string answer;

            if (!TryReadLine(startTime, out answer))
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(answer))
            {
                items.Add(answer.Trim());
            }
        }

        Console.WriteLine();
        Console.WriteLine("Time's up!");
        Console.WriteLine($"You listed {items.Count} item(s):");

        foreach (string item in items)
        {
            Console.WriteLine($"  - {item}");
        }

        DisplayEndingMessage();
    }
}