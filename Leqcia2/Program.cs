using System.Runtime.CompilerServices;
using System.Text;

namespace Leqcia2
{
    internal class Program
    {
        static void Main(string[] args)
        {
  
            //Console.WriteLine("Hello, World!");
            //Console.ReadLine();


            //Console.WriteLine("my age is " + 20);

            //byte age = 20;
            //string name = "John";

            //string str = Console.ReadLine();

            string name;
            name = "Saxeli";

            byte age = 50;

            //Pare=================================================================

            //int x = int.Parse(Console.ReadLine());// "asfwq" -error, "50"- no error
            //int z = int.Parse("5");


            //TryParse (უფრო გამოიყენება)===========================================
            //bool isValid = int.TryParse(Console.ReadLine(), out int num);


            //Console.WriteLine("Enter age");

            //string ageStr = Console.ReadLine();

            //int ageNum;

            //bool isAgeValid = int.TryParse(ageStr, out ageNum);




            //Convert class=========================================================

            //int num5 = Convert.ToInt32(ageStr);











            //-----------------------------------------------------------------------------------
            //byte x = 50;
            //int z = x;      //implicit conversion არაცხადი                                                                                    

            //int y = 50;

            //byte z2 = (byte)y;  //explicit conversion ვაიძლეფთ რომ გადავიდეს


            int z5 = 257;
            byte x1 = (byte)z5;
            //Console.WriteLine(x1);



            //Opperators=====================================================================

            #region opperators

            //მინიჭების ოპერატორი
            //+ - *. %

            // += -= *= %=


            int x5 = 5;
            //x5 *= 5;
            //Console.WriteLine(x5);


            //++ --

            //Console.WriteLine(x5++); // = 5
            //Console.WriteLine(++x5); // = 7


            //Console.WriteLine(x5--); // = 5
            //Console.WriteLine(--x5); // = 3

            // == != > < >= <=

            //&& || !

          
            //?: ternary opperator

           //Console.WriteLine( 5>4 ? "true" : "false");



            //??
            string namez = null;
            //Console.WriteLine(namez ?? "unknown");



            //+ 

            //Console.WriteLine("hola"+"janezz");


            //სტრინგის ინტერპოლაცია

            string word1 = "Hello";
            string word2 = "World!";

            //Console.WriteLine($"{word1} {word2}");











            #endregion

            #region statments


            if (5 > 3)
            {
                if (5>4) { 
                
                }
                //Console.WriteLine("metia");
            }
            else if (5 > 2)
            {
                //Console.WriteLine("metia orze");

            }
            else
            {
                //Console.WriteLine("false");
            }
                  
              
            #endregion


            //davaleba 1:

            //Console.WriteLine("Enter your sallary");

            decimal sallary;

            //bool isValid = decimal.TryParse(Console.ReadLine(), out sallary);


            //    if (sallary > 1000 && sallary <=1500 && isValid)
            //    {
            //        sallary += sallary * 20 / 100;
            //        //sallary *=1.2m;
            //    }
            //    else if (sallary > 1500 && isValid)
            //    {
            //        sallary += sallary * 15 / 100;
            //        //sallary *=1.15m;
            //    }
            //    else
            //    {
            //        Console.WriteLine("you dont have bonus or invalid input");
            //    }


            //Console.WriteLine($"Your sallary is {sallary}");



            //davaleba 2:


            Console.InputEncoding = UTF8Encoding.UTF8;


            Console.WriteLine("Enter Your age:");
            byte userAge;
            bool isAgeValid = byte.TryParse(Console.ReadLine(), out userAge);

            Console.WriteLine("Enter Your Citizenship(GEO or other)");
            string citizenship = Console.ReadLine();

            if (userAge <=18 && citizenship == "GEO" && isAgeValid)
            {
                Console.WriteLine("თქვენ მიიღეთ უფასო ბილეთი");
            }
            else if(userAge > 18 && citizenship == "GEO" && isAgeValid)
            {
                Console.WriteLine("თქვენ მიიღეთ ბილეთი ბახევარ ფასად");
            }
            else if(isAgeValid)
            {
                Console.WriteLine("გადაიხადეთ სრული თანხა ");
            }
            else
            {
                Console.WriteLine("invalid input");
            }






        }
    }
}
