using System;

namespace GradeCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Grade Calculator (OOP)";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== GRADE CALCULATOR ===\n");

            bool keepRunning = true;
            while (keepRunning)
            {
                try
                {
                    string studentName = PromptForName();
                    int numericGrade = PromptForGrade();

                    var student = new Student(studentName, numericGrade);

                    DisplayReport(student);
                    GradeLogger.LogGrade(student);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Input Error: {ex.Message}\n");
                }

                keepRunning = PromptToContinue();
            }

            Console.ResetColor();
            Console.WriteLine("\nApplication terminated. Press any key to exit.");
            Console.ReadKey();
        }

        private static string PromptForName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter student name: ");
            return Console.ReadLine().Trim();
        }

        private static int PromptForGrade()
        {
            Console.Write("Enter numerical grade (0-100): ");
            if (int.TryParse(Console.ReadLine(), out int grade))
            {
                return grade;
            }
            throw new ArgumentException("Grade must be a valid integer.");
        }

        private static void DisplayReport(Student student)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- Grade Report ---");
            Console.WriteLine($"Student Name   : {student.Name}");
            Console.WriteLine($"Numerical Grade: {student.NumericGrade}");
            Console.WriteLine($"Letter Grade   : {student.LetterGrade}\n");
        }

        private static bool PromptToContinue()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Would you like to enter another grade? (Y/N): ");
            string response = Console.ReadLine().Trim().ToLower();
            return response == "y" || response == "yes";
        }
    }
}
