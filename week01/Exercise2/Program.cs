using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for grade percentage
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);
        
        // Determine letter grade
        string letter = "";
        
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        // Stretch Challenge: Determine sign (+ or -)
        string sign = "";
        int lastDigit = grade % 10; // Gets the last digit (remainder when divided by 10)
        
        // Only add sign for grades that have signs
        if (letter != "F" && grade >= 60)
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
            // else no sign
        }
        
        // Handle exceptional cases: No A+, No F+ or F-
        if (letter == "A" && sign == "+")
        {
            sign = ""; // No A+ grade, just A
        }
        else if (letter == "F")
        {
            sign = ""; // No F+ or F- grades, just F
        }
        
        // Display the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        // Pass/Fail message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep trying for next time.");
        }
    }
}