using CIS207.Input;

namespace CIS207.Project10SimpleUtilityApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            SimpleUtilityApp simpleUtilityApp = new SimpleUtilityApp();
            simpleUtilityApp.Run();
        }
    }

    public class SimpleUtilityApp
    {
        bool isExitInput = false;
        int menuSelection = 0;

        public void Run()
        {
            GreetUser();

            while (!isExitInput)
            {
                PrintMenu();
                HandleMenuSelection();
            }
        }

        private void GreetUser()
        { Console.WriteLine("Hello User"); }

        private void PrintMenu()
        {
            Console.WriteLine("0) Exit");
            Console.WriteLine("1) Add Numbers");
            Console.WriteLine("2) Square Numbers");
            Console.WriteLine("3) Calculate a Discount");
            menuSelection = GetInput.AsInt("Enter Selection: ", 0, 3);
        }

        private void HandleMenuSelection()
        {
            switch (menuSelection)
            {
                case 0:
                    Exit();
                    break;
                case 1:
                    GoAddNumbers();
                    break;
                case 2:
                    GoSquareNumbers();
                    break;
                case 3:
                    GoCalculateDiscount();
                    break;
                default:
                    break;
            }
        }

        private void GoCalculateDiscount()
        {
            double price = GetInput.AsDouble("Enter the price: ");
            double discountRate = GetInput.AsDouble("Enter the discount rate: ");
            Console.WriteLine($"${price} - {discountRate}% = ${CalculateDiscount(price, discountRate)}");
        }

        private double CalculateDiscount(double price, double discountRate)
        { return price * (1 - (discountRate * .01)); }

        private void GoSquareNumbers()
        {
            int num = GetInput.AsInt("Enter the number to square: ");
            Console.WriteLine($"{num} squared = {SquareNumber(num)}");
        }

        private int SquareNumber(int num)
        { return num * num; }

        private void GoAddNumbers()
        {
            int num1 = GetInput.AsInt("Enter First Number: ");
            int num2 = GetInput.AsInt("Enter Second Number: ");
            AddNumbers(num1, num2);
        }

        private void AddNumbers(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine($"{num1} + {num2} = {sum}");
        }

        private void Exit()
        { isExitInput = true; }
    }
}