using System;
using System.Collections.Generic;

/*
====================================================================================
CREATIVITY AND EXCEEDING REQUIREMENTS REPORT:
1. Smart Hiding Logic: The script tracks which words are already hidden and strictly 
   selects from remaining visible words (instead of blindly picking indexes that 
   might already be underscores).
2. Scripture Library: Rather than hardcoding a single scripture, the program maintains
   a repository of multiple scriptures (both single and multi-verse) and selects 
   one at random when the game starts to challenge the user continuously.
====================================================================================
*/

class Program
{
    static void Main(string[] args)
    {
        // Set up a library of scriptures to pick from randomly
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only Son"),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the LORD with all your heart and lean not on your own understanding in all your ways submit to him and he will make your paths straight"),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ who strengthens me"),
            new Scripture(new Reference("Joshua", 1, 9), "Have I not commanded you Be strong and courageous Do not be afraid do not be discouraged for the LORD your God will be with you wherever you go")
        };

        // Pick a random scripture from our library
        Random random = new Random();
        Scripture selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        // Main game loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();

            // End game conditions
            if (selectedScripture.IsCompletelyHidden())
            {
                Console.WriteLine("Great job! You have fully memorized the text.");
                break;
            }

            Console.WriteLine("Press Enter to continue hiding words, or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            // Hide 3 words at a time
            selectedScripture.HideRandomWords(3);
        }
    }
}