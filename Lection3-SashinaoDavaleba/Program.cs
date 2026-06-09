namespace Lection3_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //davaleba1

            /*
            Console.WriteLine("Add your User Name:");
            string username = Console.ReadLine();

            Console.WriteLine("Add your Password");
            string password = Console.ReadLine();

            if(
                username == "admin" &&
                password == "1234")
            {
                Console.WriteLine("Welcome!");
            }
            else
            {
                Console.WriteLine("Access denied!");
            }
            */

            //-----------------------------------------------------------------------


            //davaleba 2


            /*
            Console.WriteLine("Add number 1:");
            bool isNum1 = double.TryParse(Console.ReadLine(), out double num1);


            Console.WriteLine("Add number operator");
            char op = Convert.ToChar(Console.ReadLine());


            Console.WriteLine("Add number 2:");
            bool isNum2 = double.TryParse(Console.ReadLine(), out double num2);

            double result = 0;


            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2;
                    break;

                case '/':

                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("error divide 0");
                    }
                    break;

                default:
                    Console.WriteLine("Error input");

                    break;
            }

            if(isNum1 && isNum2)
            {
                Console.WriteLine($"Result: {num1} {op} {num2} = {result}");
            }
            */


            //-----------------------------------------------------------------------

            //davaleba 3


            Console.WriteLine("Add your age:");
            bool isAgeValid = byte.TryParse(Console.ReadLine(), out byte age);


            switch (age)
            {
                case <= 12:
                    Console.WriteLine("Child");
                    break;

                case <= 19:
                    Console.WriteLine("Theenager");
                    break;

                case <= 64:
                    Console.WriteLine("Adult");
                    break;

                case >= 65:
                    Console.WriteLine("Pensioner");
                    break;

                default:
                    Console.WriteLine("Input error!");
                    break;

            }














        }
    }
}
