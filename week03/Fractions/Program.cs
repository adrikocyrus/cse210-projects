using System;

namespace Fractions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test 1: Using the no-parameter constructor (1/1)
            Fraction f1 = new Fraction();
            Console.WriteLine(f1.GetFractionString());
            Console.WriteLine(f1.GetDecimalValue());

            // Test 2: Using the single-parameter constructor (5/1)
            Fraction f2 = new Fraction(5);
            Console.WriteLine(f2.GetFractionString());
            Console.WriteLine(f2.GetDecimalValue());

            // Test 3: Using the two-parameter constructor (3/4)
            Fraction f3 = new Fraction(3, 4);
            Console.WriteLine(f3.GetFractionString());
            Console.WriteLine(f3.GetDecimalValue());

            // Test 4: Using the two-parameter constructor (1/3)
            Fraction f4 = new Fraction(1, 3);
            Console.WriteLine(f4.GetFractionString());
            Console.WriteLine(f4.GetDecimalValue());

            // Bonus Test: Verifying Getters and Setters work dynamically
            Console.WriteLine("\n--- Testing Getters and Setters ---");
            Fraction testFraction = new Fraction();
            testFraction.SetNumerator(6);
            testFraction.SetDenominator(7);
            Console.WriteLine($"New Numerator: {testFraction.GetNumerator()}");
            Console.WriteLine($"New Denominator: {testFraction.GetDenominator()}");
            Console.WriteLine($"New Fraction View: {testFraction.GetFractionString()}");
        }
    }
}