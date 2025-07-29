using System;

namespace TriangleTypeIdentifierApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Triangle Type Identifier ===");

            double sideA = PromptForSide("A");
            double sideB = PromptForSide("B");
            double sideC = PromptForSide("C");

            if (IsValidTriangle(sideA, sideB, sideC))
            {
                string type = IdentifyTriangleType(sideA, sideB, sideC);
                Console.WriteLine($"\nThis is a(n): {type} triangle.");
            }
            else
            {
                Console.WriteLine("\nThe provided sides do not form a valid triangle.");
            }
        }

        static double PromptForSide(string name)
        {
            while (true)
            {
                Console.Write($"Enter length of side {name}: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double side) && side > 0)
                    return side;

                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }

        static bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        static string IdentifyTriangleType(double a, double b, double c)
        {
            if (a == b && b == c) return "Equilateral";
            else if (a == b || b == c || a == c) return "Isosceles";
            else return "Scalene";
        }
    }
}