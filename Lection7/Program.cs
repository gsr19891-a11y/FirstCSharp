namespace Lection7
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region varjisi

            int[] arr = [12, -1, 22, -51, -9, 50, 60, 11, 23];

            Array.Sort(arr);//ალაგებს----------------------------------------------------------------
            Array.Reverse(arr);// რევერსი------------------------------------------------------------

            foreach (var item in arr)
            {
                //Console.WriteLine(item);
            }

            //--------------



            string[] texts = ["Hello", "World!"];

            foreach (var item in texts)
            {
                foreach (var symbol in item)
                {
                    //Console.WriteLine(symbol);
                }
            }

            char[] charebi = "Hello".ToCharArray();//------------------------------------------------------

            foreach (var item in charebi)
            {
                //Console.WriteLine(item);

            }



            string palindrome = "ai ia";

            char[] symbols = palindrome.ToCharArray();

            Array.Reverse(symbols);

            char[] reversed = symbols;

            string rame = new string(reversed);



            bool isReversing = true;


            for (int i = 0; i < symbols.Length; i++)
            {
                if (palindrome[i] != rame[i])
                {
                    isReversing = false;
                    break;
                }
            }

            if (isReversing)
            {
                //Console.WriteLine("true");
            }
            else
            {
                //Console.WriteLine("false");
            }



            #endregion





            int x = 5;
            int y = 5;

            //Console.WriteLine(x + y);
            //=================================================================================================================
            //function:

            //reusable - მრავალჯერ გამოყენებადი კოდი.
            // D R Y - dont repeat yourself.

            //მეთოდი ვს ფუნქცია

            //o o p - ობიექტზე ორიენტირებული ენა



            //local function 
            /*
           - void - გამომავალი მნიშნელობა არააქვს,int, string,  byte..
           - return
            */

            void Plus(int a, int b)
            {
                Console.WriteLine($"{a + b}");
            }
            Plus(x, y);

            //---

            string vord = "World";

            void Hello(string text)
            {
                Console.WriteLine($"Hello {text}");
            }
            Hello("Csharp");

            //---

            void Sum(int x, int y)
            {
                Console.WriteLine($"Sum: {x + y}");
            }

            Sum(10, 20);

            //======

            int SumInt(int x, int y)
            {
                return x + y;
            }

            int jami = SumInt(20, 20);
            Console.WriteLine(jami);




            bool Comp(string text1, string text2)
            {
                //if ()
                //{
                //    return true;
                //}
                return text1.ToLower().Trim() == text2.ToLower().Trim();
            }
            Console.WriteLine(Comp("HELLOO", "helloo"));


            //SRP - single responsibility 

            testMethod();
        }


        static void testMethod() {
            Console.WriteLine("Hello");
        
        }






    }
}
