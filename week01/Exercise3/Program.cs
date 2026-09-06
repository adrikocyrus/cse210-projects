using System;

class Program
{
    static void Main(string[] args)
    {
        // REQUIREMENT 1: Generate random number from 1 to 100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);
        
        int guess = -1;
        
        // REQUIREMENT 2: Loop until user guesses correctly
        while (guess != magicNumber)
        {
            // Ask user for a guess
            Console.Write("What is your guess? ");
            string guessInput = Console.ReadLine();
            guess = int.Parse(guessInput);
            
            // REQUIREMENT 3: If statement for higher/lower/correct
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
}