using CIS207.Input;                                                             // import input handling class

namespace CIS207.Project10SimpleUtilityApp
{
    public class SimpleUtilityApp
    {
        bool isExitInput = false;                                               // initialize exit input variable
        int menuSelection = 0;                                                  // initialize menu selection variable

        public void Run()                                                       // the main method
        {
            GreetUser();                                                        // call method to greet user

            while (!isExitInput)                                                // enter main loop
            {
                PrintMenu();                                                    // call method to print menu
                HandleMenuSelection();                                          // call method to handle menu selection
            }
        }

        private void GreetUser()                                                // method to greet user
        {
            string name = GetInput.AsString("Enter your name");                 // prompt for name
            Console.WriteLine($"{RandomGreeting()} {name}");                    // call method for random greeting; print response
        }

        private string RandomGreeting()                                         // method for random greeting
        {
            Random rand = new Random();                                         // create random number genertor
            int randomNum = rand.Next(0, 5);                                    // get random int in range 0-5 (ending exclusive)
            switch (randomNum)                                                  // switch on that random number
            {
                case 0: return "Hi";
                case 1: return "Hello";
                case 2: return "Hey";
                case 3: return "What";
                case 4: return "What do you want";
                default: return "Hello";
            }
        }

        private void PrintMenu()                                                // method to print the menu
        {
            Console.WriteLine("0) Exit");
            Console.WriteLine("1) Add Numbers");
            Console.WriteLine("2) Square Numbers");
            Console.WriteLine("3) Calculate a Discount");
            Console.WriteLine("4) Even Check");
            Console.WriteLine("5) Prime Check");

            menuSelection = GetInput.AsInt("Enter Selection: ", 0, 5);          // get int for menu selection
        }

        private void HandleMenuSelection()                                      // method to handle menu selection 
        {
            switch (menuSelection)                                              // switch on menu selection int
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

        private void GoPrime()                                                  // method to handle prime check menu selection
        {
            int num = GetInput.AsInt("Enter the number");                       // get input int to check
            Console.WriteLine($"{num} is {(IsPrime(num) ? "" : "not")} prime"); // call method to check prime-ness; print output with ternary operator
        }

        private bool IsPrime(int num)                                           // method to check prime-ness of given number
        {
            if (num <= 1) { return false; }                                     // if 1 or less, not prime
            if (num == 2) { return true; }                                      // if 2, not prime
            if (num % 2 == 0) { return false; }                                 // if divisible by 2, not prime

            int limit = (int)Math.Sqrt(num);                                    // set limit of check; uses square root of given number to avoid redundant checks

            for (int i = 3; i <= limit; i += 2)                                 // for loop starts on 3, and skips all even numbers
            {
                if (num % i == 0)                                               // check for divisibility
                { return false; }                                               // return not prime
            }

            return true;                                                        // if all checks passed, return prime
        }

        private void GoEven()                                                   // method to handle even check menu selection
        {
            int num = GetInput.AsInt("Enter number");                           // get input int to check even-ness
            Console.WriteLine($"{num} is {(IsEven(num) ? "even" : "odd")}");    // call method to check even-ness; print output with ternary operator
        }

        private bool IsEven(int num)                                            // method to check even-ness of given number
        { return num % 2 == 0; }                                                // return even-ness result

        private void GoCalculateDiscount()                                      // method to handle discount calculation menu selection
        {
            double price = GetInput.AsDouble("Enter the price");                                                // get input double for price
            double discountRate = GetInput.AsDouble("Enter the discount rate", 0, 100);                         // get input double for discout rate; using whole percentage
            Console.WriteLine($"${price} - {discountRate}% = ${CalculateDiscount(price, discountRate):F2}");    // call method to calculate discount total; print result with formatting
        }

        private double CalculateDiscount(double price, double discountRate)     // method to calculate total given price and discount
        { return price * (1 - (discountRate * .01)); }                          // return calculated total

        private void GoSquareNumbers()                                          // method to handle square number menu selection
        {
            int num = GetInput.AsInt("Enter the number to square");             // get input int to square
            Console.WriteLine($"{num} squared = {SquareNumber(num)}");          // call method to square given number; print results
        }

        private int SquareNumber(int num)                                       // method to square given number
        { return num * num; }                                                   // return squared number

        private void GoAddNumbers()                                             // method to handle adding numbers menu selection
        {
            int num1 = GetInput.AsInt("Enter First Number");                    // get input number 1
            int num2 = GetInput.AsInt("Enter Second Number");                   // get input number 2
            AddNumbers(num1, num2);                                             // call method to add numbers and print result
        }

        private void AddNumbers(int num1, int num2)                             // method to add 2 given numbers
        {
            int sum = num1 + num2;                                              // calculate sum (to keep the next line clean)
            Console.WriteLine($"{num1} + {num2} = {sum}");                      // print results
        }

        private void Exit()                                                     // method to handle exit menu selection
        { isExitInput = true; }                                                 // set exit input variable to true
    }

}