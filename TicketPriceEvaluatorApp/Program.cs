using System;

namespace TicketPriceCalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int age = PromptForAge();

                ITicketPriceEvaluator evaluator = new TicketPriceEvaluator();
                string receipt = evaluator.GenerateReceipt(age);

                Console.WriteLine("\n=== Ticket Summary ===");
                Console.WriteLine(receipt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        static int PromptForAge()
        {
            while (true)
            {
                Console.Write("Enter your age: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int age) && age > 0)
                    return age;

                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }
    }
}