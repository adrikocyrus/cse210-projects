using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts;
    private readonly Random _random;

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
        )
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();

        string prompt = _prompts[_random.Next(_prompts.Count)];

        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();

        Console.WriteLine("You will have a few seconds to think about the prompt.");
        Console.WriteLine();

        ShowCountdown(5);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Start listing items.");
        Console.WriteLine("Press Enter after each item.");
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        int itemCount = 0;

        while (GetElapsedSeconds(startTime) < Duration)
        {
            Console.Write($"{itemCount + 1}: ");

            string answer = Console.ReadLine();

            if (GetElapsedSeconds(startTime) >= Duration)
            {
                break;
            }

            if (!string.IsNullOrWhiteSpace(answer))
            {
                itemCount++;
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {itemCount} item(s).");

        DisplayEndingMessage();
    }
}