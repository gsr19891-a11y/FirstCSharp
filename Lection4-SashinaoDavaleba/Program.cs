namespace Lection4_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //davaleba 1

            /*
            Console.WriteLine("Enter Number");
            bool isNumValid = int.TryParse(Console.ReadLine(), out int num1);


            if (isNumValid)
            {
                for (int i = 1; i < 11; i++)
                {
                    Console.WriteLine($"{num1}*{i}={num1 * i}");
                }

            }
            */

            //davaleba 2
            /*
                Console.WriteLine("Enter Number");
                bool isNumValid = int.TryParse(Console.ReadLine(), out int num);

                if (isNumValid)
                {
                    for (int i = 0; i < num; i++)
                    {
                        for (int j = 0; j < num - i - 1; j++)
                        {
                            Console.Write(" ");
                        }
                        for (int k = 0; k <= i; k++)
                        {
                            Console.Write("* ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Error input");
                }
           



            //davaleba 3
            int count = 0;
            Console.WriteLine("Enter number:");
            bool isNumValid = int.TryParse(Console.ReadLine(), out int num);

            for (int i = 2; i <= num; i++)
            {

                if (i % 2 == 0)
                {

                    count += i;

                } 
            }Console.WriteLine($"Sum: {count}");

 */

            //davaleba 4

  

            bool isNumValid = int.TryParse(Console.ReadLine(), out int num);















            //davaleba 5

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("*");

                }
                Console.WriteLine("*");

            }

            //davaleba 6

            /*

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");

                }
                Console.WriteLine("*");
            }

            //davlaeba 7

            for (int i = 5 - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    Console.Write("*");

                }
                Console.WriteLine("*");
            }


            //davaleba 8

            for (int i = 0; i < 10; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    Console.Write(j);   
                }
                Console.WriteLine();
            }
            */




        }
    }
}
