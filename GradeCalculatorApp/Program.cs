using System;
using System.IO;

namespace GradeCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Grade Calculator (OOP - Single File)";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== GRADE CALCULATOR ===\n");

            bool keepRunning = true;
            while (keepRunning)
            {
                try
                {
                    string studentName = PromptForName();
                    int numericGrade = PromptForGrade();

                    Student student = new Student(studentName, numericGrade);

                    DisplayReport(student);
                    GradeLogger.LogGrade(student);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Input Error: {ex.Message}\n");
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid Input: {ex.Message}\n");
                }

                keepRunning = PromptToContinue();
            }

            Console.ResetColor();
            Console.WriteLine("\nApplication terminated. Press any key to exit.");
            Console.ReadKey();
        }

        static string PromptForName()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter student name: ");
            return Console.ReadLine().Trim();
        }

        static int PromptForGrade()
        {
            Console.Write("Enter numerical grade (0-100): ");
            if (int.TryParse(Console.ReadLine(), out int grade))
            {
                return GradeValidator.ValidateGrade(grade);
            }
            throw new ArgumentException("Grade must be a valid integer.");
        }

        static void DisplayReport(Student student)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--- Grade Report ---");
            Console.WriteLine($"Student Name   : {student.Name}");
            Console.WriteLine($"Numerical Grade: {student.NumericGrade}");
            Console.WriteLine($"Letter Grade   : {student.LetterGrade}\n");
        }

        static bool PromptToContinue()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Would you like to enter another grade? (Y/N): ");
            string response = Console.ReadLine().Trim().ToLower();
            return response == "y" || response == "yes";
        }
    }

    class Student
    {
        public string Name { get; private set; }
        public int NumericGrade { get; private set; }
        public string LetterGrade { get; private set; }

        public Student(string name, int numericGrade)
        {
            Name = name;
            NumericGrade = numericGrade;
            LetterGrade = GradeCalculator.CalculateLetterGrade(numericGrade);
        }
    }

    static class GradeCalculator
    {
        public static string CalculateLetterGrade(int grade)
        {
            if (grade >= 90) return "A";
            if (grade >= 80) return "B";
            if (grade >= 70) return "C";
            if (grade >= 60) return "D";
            return "F";
        }
    }

    static class GradeValidator
    {
        public static int ValidateGrade(int grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 100.");
            return grade;
        }
    }

    static class GradeLogger
    {
        private const string FilePath = "grades.txt";

        public static void LogGrade(Student student)
        {
            string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {student.Name} | {student.NumericGrade} | {student.LetterGrade}";
            try
            {
                File.AppendAllText(FilePath, entry + Environment.NewLine);
            }
            catch (IOException ioEx)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error writing to log file: {ioEx.Message}");
                Console.ResetColor();
            }
        }
    }
}
