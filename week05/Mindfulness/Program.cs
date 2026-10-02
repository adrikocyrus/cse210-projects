using System;

class Program
{
    static void Main(string [] args)
    {
        bool running = true;

        /*
         * Creativity and Exceeding Requirements:
         *
         * In addition to the required breathing, reflection, and listing
         * activities, this program improves the experience by making sure
         * reflection questions are not repeated until all questions have
         * been used during the session.
         *
         * The program also includes animated spinners and countdown timers
         * to make the waiting periods more meaningful. The reflection
         * activity displays a summary of how many questions were considered,
         * and the listing activity counts the number of responses entered.
         *
         * Common functionality is placed in the Activity base class so that
         * the individual activity classes do not duplicate code.
         */

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

            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
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
                    Console.WriteLine(
                        "Invalid choice. Please select 1, 2, 3, or 4."
                    );

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

        Console.WriteLine(
            "Thank you for using the Mindfulness Program!"
        );
    }
}