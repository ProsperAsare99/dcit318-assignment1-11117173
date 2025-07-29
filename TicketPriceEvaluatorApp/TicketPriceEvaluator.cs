namespace TicketPriceCalculatorApp
{
    public class TicketPriceEvaluator : ITicketPriceEvaluator
    {
        private const double RegularPrice = 10.0;
        private const double DiscountedPrice = 7.0;

        public double CalculatePrice(int age)
        {
            return (age <= 12 || age >= 65) ? DiscountedPrice : RegularPrice;
        }

        public string GetCustomerCategory(int age)
        {
            if (age <= 12) return "Child";
            else if (age >= 65) return "Senior Citizen";
            else return "General";
        }

        public string GenerateReceipt(int age)
        {
            string category = GetCustomerCategory(age);
            double price = CalculatePrice(age);

            return $"Category: {category} | Age: {age} → Ticket Price: GHC{price:F2}";
        }
    }
}