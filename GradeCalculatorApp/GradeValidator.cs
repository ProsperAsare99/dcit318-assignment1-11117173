using System;

namespace GradeCalculatorApp
{
    public static class GradeValidator
    {
        public static int ValidateGrade(int grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentOutOfRangeException(nameof(grade), "Grade must be between 0 and 100.");
            return grade;
        }
    }
}
