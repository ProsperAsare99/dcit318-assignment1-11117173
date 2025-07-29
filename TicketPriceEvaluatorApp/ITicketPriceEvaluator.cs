namespace TicketPriceCalculatorApp
{
    public interface ITicketPriceEvaluator
    {
        double CalculatePrice(int age);
        string GetCustomerCategory(int age);
        string GenerateReceipt(int age);
    }
}