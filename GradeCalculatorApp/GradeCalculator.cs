namespace GradeCalculatorApp
{
    public static class GradeCalculator
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
}
