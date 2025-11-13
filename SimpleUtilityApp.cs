using CIS207.Input;

namespace CIS207.Project10SimpleUtilityApp
{
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
        {
            string name = GetInput.AsString("Enter your name");
            Console.WriteLine($"{RandomGreeting()} {name}");
        }

        private string RandomGreeting()
        {
            Random rand = new Random();
            int randomNum = rand.Next(0, 3);
            switch (randomNum)
            {
                case 0: return "Hi";
                case 1: return "Hello";
                case 2: return "Hey";
            }
            return "What do you want";
        }

        private void PrintMenu()
        {
            Console.WriteLine("0) Exit");
            Console.WriteLine("1) Add Numbers");
            Console.WriteLine("2) Square Numbers");
            Console.WriteLine("3) Calculate a Discount");
            Console.WriteLine("4) Even Check");
            Console.WriteLine("5) Prime Check");

            menuSelection = GetInput.AsInt("Enter Selection: ", 0, 5);
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
                case 4:
                    GoEven();
                    break;
                case 5:
                    GoPrime();
                    break;
                default:
                    break;
            }
        }

        private void GoPrime()
        {
            int num = GetInput.AsInt("Enter the number");
            Console.WriteLine($"{num} is {(IsPrime(num) ? "" : "not")} prime");
        }

        private bool IsPrime(int num)
        {
            if (num <= 1) { return false; }
            if (num == 2) { return true; }
            if (num % 2 == 0) { return false; }

            int limit = (int)Math.Sqrt(num);

            for (int i = 3; i <= limit; i += 2)
            {
                if (num % i == 0)
                { return false; }
            }

            return true;
        }

        private void GoEven()
        {
            int num = GetInput.AsInt("Enter number");
            Console.WriteLine($"{num} is {(IsEven(num) ? "even" : "odd")}");
        }

        bool IsEven(int num)
        { return num % 2 == 0; }

        private void GoCalculateDiscount()
        {
            double price = GetInput.AsDouble("Enter the price");
            double discountRate = GetInput.AsDouble("Enter the discount rate", 0, 100);
            Console.WriteLine($"${price} - {discountRate}% = ${CalculateDiscount(price, discountRate):F2}");
        }

        private double CalculateDiscount(double price, double discountRate)
        { return price * (1 - (discountRate * .01)); }

        private void GoSquareNumbers()
        {
            int num = GetInput.AsInt("Enter the number to square");
            Console.WriteLine($"{num} squared = {SquareNumber(num)}");
        }

        private int SquareNumber(int num)
        { return num * num; }

        private void GoAddNumbers()
        {
            int num1 = GetInput.AsInt("Enter First Number");
            int num2 = GetInput.AsInt("Enter Second Number");
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