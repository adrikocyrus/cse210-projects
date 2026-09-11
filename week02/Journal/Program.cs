using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");

                    string response = Console.ReadLine() ?? "";

                    Console.Write("How would you describe your mood? ");
                    string mood = Console.ReadLine() ?? "";

                    Entry newEntry = new Entry();

                    newEntry._date = DateTime.Now.ToString("yyyy-MM-dd");
                    newEntry._promptText = prompt;
                    newEntry._entryText = response;
                    newEntry._mood = mood;

                    journal.AddEntry(newEntry);

                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine();
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");

                    string loadFile = Console.ReadLine() ?? "";

                    journal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");

                    string saveFile = Console.ReadLine() ?? "";

                    journal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.\n");
                    break;
            }
        }
    }
}