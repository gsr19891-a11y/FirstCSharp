namespace Lection7_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //davaleba1 

            int num1 = 5;
            int num2 = 3;


            double Pow(int num1, int num2) { 

                double result = Math.Pow(num1, num2);
            
            return result;
            }

           Console.WriteLine( Pow(num1, num2));

           

            //davaleba2

            int num1 = 31;

            bool SimpleNum(int num)
            {
                if (num <= 1)
                {
                    return false;
                }
                for (int i = 2; i < Math.Sqrt(num); i++)
                {
                    if (num % 2 == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            Console.WriteLine(SimpleNum(num1));




            //davaleba 3

            Console.WriteLine("Enter text:");
            string input = Console.ReadLine();
            
            string cleanedInput = input.ToLower().Replace(" ", "");

            Console.WriteLine(Palindrome(cleanedInput) ? "true" : "false");

            bool Palindrome(string text)
            {
           
                if (text.Length <= 1)
                    return true;  
                if (text[0] == text[text.Length - 1])
                {             
                    return Palindrome(text.Substring(1, text.Length - 2));
                }
                return false;
            }
 

            //davaleba 4

            Console.WriteLine("Enter Number:");
            int userNum = int.Parse(Console.ReadLine());

            Console.WriteLine(Binary(userNum));
*/

            //davaleba 5

            Console.WriteLine("Enter Number 1");
            bool isNum1Valid = int.TryParse(Console.ReadLine(), out int num1);

            Console.WriteLine("Enter Number 2");
            bool isNum2Valid = int.TryParse(Console.ReadLine(), out int num2);

          
            double Pow(int num1, int num2)
            {
                double result = Math.Pow(num1, num2);
                Console.WriteLine(result);
                return result;
            }

            Pow(num1, num2);





        }



        //davlaeba 4
        static string Binary(int num) {

            if (num == 0) {
                return "";
            }

            return Binary(num / 2) + (num % 2).ToString();
        }


    }
}
