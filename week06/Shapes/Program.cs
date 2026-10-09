using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Quick test of a single shape
        Square testSquare = new Square("Red", 3);
        Console.WriteLine($"Test: {testSquare.GetColor()} square, area {testSquare.GetArea()}");
        Console.WriteLine();

        // Build the list of shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Red", 3));
        shapes.Add(new Rectangle("Blue", 4, 5));
        shapes.Add(new Circle("Green", 2.5));
        shapes.Add(new Square("Yellow", 6));
        shapes.Add(new Rectangle("Purple", 2, 7.5));

        // Polymorphism in action: the same call runs different code per shape
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area:F2}");
        }
    }
}