using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 1: Ask user for magic number
        Console.Write("What is the magic number? ");
        string input = Console.ReadLine();
        int magicNumber = int.Parse(input);
        
        // Core Requirement 2: Ask user for a guess
        Console.Write("What is your guess? ");
        string guessInput = Console.ReadLine();
        int guess = int.Parse(guessInput);
        
        // Core Requirement 3: Determine higher/lower/correct
        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
    }
}