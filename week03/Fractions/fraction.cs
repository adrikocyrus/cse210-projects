using System;

namespace Fractions
{
    public class Fraction
    {
        // Private attributes (Encapsulation)
        private int _numerator;
        private int _denominator;

        // 1. Constructor with no parameters (Defaults to 1/1)
        public Fraction()
        {
            _numerator = 1;
            _denominator = 1;
        }

        // 2. Constructor with one parameter for the top (Defaults bottom to 1)
        public Fraction(int top)
        {
            _numerator = top;
            _denominator = 1;
        }

        // 3. Constructor with two parameters for top and bottom
        public Fraction(int top, int bottom)
        {
            _numerator = top;
            _denominator = bottom;
        }

        // Getters and Setters for Numerator
        public int GetNumerator()
        {
            return _numerator;
        }

        public void SetNumerator(int numerator)
        {
            _numerator = numerator;
        }

        // Getters and Setters for Denominator
        public int GetDenominator()
        {
            return _denominator;
        }

        public void SetDenominator(int denominator)
        {
            // Simple validation to prevent division by zero
            if (denominator == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            _denominator = denominator;
        }

        // Method to return fractional representation (e.g., "3/4")
        public string GetFractionString()
        {
            return $"{_numerator}/{_denominator}";
        }

        // Method to return decimal representation (e.g., 0.75)
        // Note: Casting one integer to (double) forces a decimal division instead of integer division
        public double GetDecimalValue()
        {
            return (double)_numerator / _denominator;
        }
    }
}