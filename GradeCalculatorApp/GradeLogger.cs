using System;
using System.IO;

namespace GradeCalculatorApp
{
    public static class GradeLogger
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
