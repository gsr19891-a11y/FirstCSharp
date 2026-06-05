namespace SashinaoDavaleba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //leqcia2

            //davaleba 1
            /*
            Console.WriteLine("Welcome to the online elections! Enter your age to participate in the elections:");

            byte age;

            bool isAgeValid = byte.TryParse(Console.ReadLine(), out age);
  
            if(age > 110 && age < 1)
            {
                Console.WriteLine("Error! That age can't exist.");
            }
            else if(age >=18 && isAgeValid)
            {
                Console.WriteLine("Expected result: Congratulations! You have the right to vote.");
            }
            else if(age <18 && isAgeValid)
            {
                Console.WriteLine("Expected result: Unfortunately, you are not yet eligible to vote.");
            }
            else
            {
                Console.WriteLine("Error! Incorrect age!");
            }
            */


            //davaleba 2
            /*
            Console.WriteLine("Enter First Number:");
            bool isFirstNumberValid = int.TryParse(Console.ReadLine(), out int firstNumber);


            Console.WriteLine("Enter Second Number:");
            bool isSecondNumberValid = int.TryParse(Console.ReadLine(), out int secondNumber);


            Console.WriteLine("Enter Third Number:");
            bool isThirdNumberValid = int.TryParse(Console.ReadLine(), out int thirdNumber);



            if (isFirstNumberValid && isSecondNumberValid && isThirdNumberValid){

                int max = Math.Max(firstNumber, Math.Max(secondNumber,thirdNumber));

                Console.WriteLine($"The maximum number is:{max}");
            }
            else
            {
                Console.WriteLine("Error! Invalid input. Please enter valid integers.");
            }

            */

            //davaleba 3


            /*

            Console.WriteLine("Enter First Number");
            bool firstNumValid = int.TryParse(Console.ReadLine(), out int firstNum);

            Console.WriteLine("Enter Second Number");
            bool secondNumValid = int.TryParse(Console.ReadLine(), out int secondNum);

            int result;


            if (firstNumValid && secondNumValid && firstNum != secondNum)
            {
                Console.WriteLine($"Result:{result = firstNum + secondNum}");

            }
            else if (firstNum == secondNum)
            {
                Console.WriteLine($"Result:{result = firstNum * secondNum * 3}");
            }
            else
            {
                Console.WriteLine("Error! Invalid input. Please enter valid integers.");
            }

            */

            //davaleba 4

            /*
            Console.WriteLine("Запшите вашу температуру:");
            bool isTemperatureValid = double.TryParse(Console.ReadLine(), out double temperature);

            if (isTemperatureValid && temperature >= 36.0 && temperature <= 37.0)
            {
                Console.WriteLine("У вас нормальная температура!");
            }else if(isTemperatureValid && temperature > 37.0)
            {
                Console.WriteLine("У вас повышенная температура!");
            }else if(isTemperatureValid && temperature < 36.0)
            {
                Console.WriteLine("У вас пониженная температура!");
            }
            else
            {
                Console.WriteLine("Error!");
            }

            */



            //davaleba 5
            /*

            Console.WriteLine("Введите первое число:");
            bool isFirstValid = int.TryParse(Console.ReadLine(),out int firstNum);

            Console.WriteLine("Введите второе число:");
            bool isSecondValid = int.TryParse(Console.ReadLine(), out int secondNum);

            Console.WriteLine("Введите третье число:");
            bool isThirdValid = int.TryParse(Console.ReadLine(), out int thirdNum);

            int min;


            if(isFirstValid && isSecondValid && isThirdValid)
            {
                min = Math.Min(firstNum, Math.Min(secondNum, thirdNum));
                Console.WriteLine($"Минимальное число:{min}");
            }
            else
            {
                Console.WriteLine("error nums!");
                return;
            }

            */







        }
    }
}
