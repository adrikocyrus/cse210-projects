using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                {
                    CreateGoal();
                    break;
                }
                case "2":
                {
                    ListGoals();
                    break;
                }
                case "3":
                {
                    SaveGoals();
                    break;
                }
                case "4":
                {
                    LoadGoals();
                    break;
                }
                case "5":
                {
                    RecordEvent();
                    break;
                }
                case "6":
                {
                    Console.WriteLine("Keep questing!");
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid choice.");
                    break;
                }
            }

            Console.WriteLine();
        }
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. Level {GetLevel()}: {GetTitle()}");
        Console.WriteLine();
    }

    // Gamification: the player levels up every 1000 points.
    private int GetLevel()
    {
        return Math.Max(1, _score / 1000 + 1);
    }

    private string GetTitle()
    {
        string[] titles =
        {
            "Novice Adventurer",
            "Faithful Seeker",
            "Steadfast Knight",
            "Valiant Champion",
            "Ninja Unicorn"
        };

        int titleIndex = Math.Min(GetLevel() - 1, titles.Length - 1);
        return titles[titleIndex];
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = CleanText(Console.ReadLine());
        Console.Write("What is a short description of it? ");
        string description = CleanText(Console.ReadLine());
        int points = AskForNumber("What is the amount of points associated with this goal? ");

        switch (type)
        {
            case "1":
            {
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("Goal created!");
                break;
            }
            case "2":
            {
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("Goal created!");
                break;
            }
            case "3":
            {
                int target = AskForNumber("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = AskForNumber("What is the bonus for accomplishing it that many times? ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("Goal created!");
                break;
            }
            case "4":
            {
                _goals.Add(new NegativeGoal(name, description, points));
                Console.WriteLine("Goal created!");
                break;
            }
            default:
            {
                Console.WriteLine("Invalid goal type.");
                break;
            }
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal first.");
            return;
        }

        ListGoals();
        int index = AskForNumber("Which goal did you accomplish? ") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int levelBefore = GetLevel();

        // Polymorphism: each goal type decides how many points to award.
        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
        else if (pointsEarned < 0)
        {
            Console.WriteLine($"Ouch! You lost {-pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("That goal is already complete. No points earned.");
        }

        Console.WriteLine($"You now have {_score} points.");

        if (GetLevel() > levelBefore)
        {
            Console.WriteLine($"*** LEVEL UP! You are now a {GetTitle()}! ***");
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("The file is empty.");
            return;
        }

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string goalType = parts[0];

            switch (goalType)
            {
                case "SimpleGoal":
                {
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                }
                case "EternalGoal":
                {
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                }
                case "ChecklistGoal":
                {
                    _goals.Add(new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6])));
                    break;
                }
                case "NegativeGoal":
                {
                    _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                }
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    private int AskForNumber(string prompt)
    {
        int value;
        Console.Write(prompt);

        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Please enter a number: ");
        }

        return value;
    }

    // The save file uses "|" as a separator, so remove it from user text.
    private string CleanText(string text)
    {
        return text.Replace("|", "/");
    }
}