using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * Creativity and Exceeding Requirements:
         *
         * 1. No repeated prompts or questions within a session: the Reflection
         *    prompts, Reflection questions, and Listing prompts are drawn at
         *    random without repeats until every item has been used, then the
         *    list is refilled. This means a long Reflection session cycles
         *    through all nine questions before any question appears again.
         *
         * 2. Strict timers: the Listing activity uses a non-blocking input reader
         *    (Console.KeyAvailable), so the session ends exactly when time is up
         *    instead of waiting for the user to press Enter. Reflection and
         *    Breathing shorten their final step so they never run past the
         *    requested duration.
         *
         * 3. Summaries: Listing prints every item the user entered, and
         *    Reflection reports how many questions were considered.
         *
         * 4. Animations: spinner and countdown use backspaces, and the countdown
         *    correctly erases multi-digit numbers.
         *
         * 5. Shared code lives in the Activity base class (start/end messages,
         *    spinner, countdown, timing, random selection, timed input) so the
         *    derived classes contain no duplicated logic.
         */

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? "";
            Activity activity;

            switch (choice.Trim())
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
                    running = false;
                    continue;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please select 1, 2, 3, or 4.");
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();

            Console.WriteLine();
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}