using System;

class Program
{
    static void Main(string[] args)
    {
        // Call each function in order
        DisplayWelcome();
        
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquareNumber(userNumber);
        
        DisplayResult(userName, squaredNumber);
    }
    
    // Function 1: Display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    
    // Function 2: Prompt for and return user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    
    // Function 3: Prompt for and return user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }
    
    // Function 4: Square a number
    static int SquareNumber(int number)
    {
        return number * number;
    }
    
    // Function 5: Display the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}