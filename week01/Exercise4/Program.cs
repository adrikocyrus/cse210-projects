using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store numbers
        List<int> numbers = new List<int>();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        // Core Requirement: Ask for numbers until user enters 0
        int number = -1;
        while (number != 0)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);
            
            // Only add non-zero numbers to the list
            if (number != 0)
            {
                numbers.Add(number);
            }
        }
        
        // Core Requirement 1: Compute the sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");
        
        // Core Requirement 2: Compute the average
        // Need to use double for decimal division
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");
        
        // Core Requirement 3: Find the maximum
        int max = numbers[0]; // Start with first element
        foreach (int num in numbers)
        {
            if (num > max)
            {
                max = num;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}