using System;

namespace GradeCalculatorApp
{
    public class GradeEvaluator
    {
        public int Grade { get; private set; }

        public GradeEvaluator(int grade)
        {
            Grade = grade;
        }

        public string GetLetterGrade()
        {
            if (Grade >= 90)
                return "A";
            else if (Grade >= 80)
                return "B";
            else if (Grade >= 70)
                return "C";
            else if (Grade >= 60)
                return "D";
            else
                return "F";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        EvaluateGrade();
                        break;
                    case "2":
                        Console.WriteLine("Exiting GradeCalculatorApp. Goodbye!");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine(); // spacing
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("==== Grade Calculator App ====");
            Console.WriteLine("1. Evaluate a Grade");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");
        }

        static void EvaluateGrade()
        {
            int grade = PromptForGrade();
            GradeEvaluator evaluator = new GradeEvaluator(grade);
            string result = evaluator.GetLetterGrade();

            Console.WriteLine($"Numeric Grade: {grade} | Letter Grade: {result}");
        }

        static int PromptForGrade()
        {
            int grade;
            while (true)
            {
                Console.Write("Enter a grade between 0 and 100: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out grade) && grade >= 0 && grade <= 100)
                    return grade;

                Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
            }
        }
    }
}
