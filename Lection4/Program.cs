using System.Reflection.Metadata;
using System.Text;

namespace Lection4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;//ქართული ასოები

            //Console.ForegroundColor = ConsoleColor.Yellow;//ფერის შეცვლა




            //for===============================================================
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);

            //}
            /*
           for (int i = 26; i < 50; i+=2)
           {
               //Console.WriteLine(i%2==0 ? i : "");
               Console.WriteLine(i);

           }*/



            //forr- incremnt fast code------------------



            //for (int i =99 ; i >= 80; i-=3)
            //{
            //    Console.WriteLine(i);

            //}
            /*

            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " Hello ");

                for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine(" " + j + " ");
                }
            }
            */

            //saklaso davaleba 1--------------------------------------------------------------

            /*
            for (int i = 2; i < 10; i++)
            { int count = 0;

                for (int j = 2; j < i; j++)
                {
                   
                   if(i % j == 0)
                    {
                        count ++;
                    }
                    
                }
                Console.WriteLine(count >0 ? i + " rtulia" : i + " martivia");

            }
            */


            /*
            for (int i = 0; i < 10; i++)
            {

                if(i == 5)
                {
                    break;//ლუპის გათიშვა
                }
                
            }
            */


            /*
            for (int i = 0; i < 10; i++)
            {

                if (i == 5)
                {

                    continue;//skip იტერაციის გამოტოვება ლუპში
                    
                }Console.WriteLine(i);

            }

            */


            //While=======================================================================================================


            /*
            int x = 0;
            while (x<10) {
                Console.WriteLine(x +" hi");
                x++;
            }

            //admin       guest

            string role = "admin";
            string userRole = Console.ReadLine();

            while(role != userRole)
            {
                Console.WriteLine("try again");
                userRole = Console.ReadLine();

            }
            Console.WriteLine("welcome");

            */


            //Do While=====================================================================================================

            /*
            string role = "admin";
            string userRole;

            do
            {
                Console.WriteLine("Enter yout role");
                userRole = Console.ReadLine();
            }
            while (role !=userRole);
            */


            // foreach - კოლექციებზე მუშაობს -მასივი


            //for in

            int[] arr = [20, 60, 30];


            foreach (var item in arr)
            {
                Console.WriteLine(item);
                
            }
























            //while, do while, foreach















        }
    }
}
