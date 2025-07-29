namespace GradeCalculatorApp
{
    public class Student
    {
        public string Name { get; private set; }
        public int NumericGrade { get; private set; }
        public string LetterGrade { get; private set; }

        public Student(string name, int numericGrade)
        {
            Name = name;
            NumericGrade = GradeValidator.ValidateGrade(numericGrade);
            LetterGrade = GradeCalculator.CalculateLetterGrade(NumericGrade);
        }
    }
}
