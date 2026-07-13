using Lecture_18.Helper;

namespace Lecture_18
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> list = new List<int>() { 1, 10, 22, 134, 47, 985 };


            var resultEven = CustomAlporithms.CustomFirst(list, isEven); //20
            Console.WriteLine(resultEven);




            var resultOdd = CustomAlporithms.CustomFirst(list, isOdd);
            Console.WriteLine(resultOdd);




            string[] names = ["anna", "john@", "bob"];

            var resultb = CustomAlporithms.CustomFirst(names, StartsWithA);
            Console.WriteLine(resultb);


            //=> errow function, lambda expression

            //var resultbb = CustomAlporithms.CustomFirst(list, delegate (int x) { return x % 2 == 0; });
            //var resultbb = CustomAlporithms.CustomFirst(list,  (int x) => x % 2 == 0);
            var resultbb = CustomAlporithms.CustomFirst(list, x => x % 2 == 0);

            Console.WriteLine(resultbb);




            IEnumerable<int> resultWere = CustomAlporithms.CustomeWere(list, x=> x > 50);
            foreach (var item in resultWere)
            {
                Console.WriteLine(item);
            }






            IEnumerable<string> resultWerestring = CustomAlporithms.CustomeWere(names, x => x.Contains("@"));
            foreach (var item in resultWerestring)
            {
                Console.WriteLine(item);
            }





            IEnumerable<string> resultWerestringvar2 = names.CustomeWere(x => x.Contains("@"));

            foreach (var item in resultWerestringvar2)
            {
                Console.WriteLine(item);
            }



            //this-------------------------------------
            string test = "hello";
            test.Print();


            var countresult = list.CustomCount(x => x == 1);
          

                Console.WriteLine(countresult);
            

        }


        static bool isEven(int x)
        {
            return x % 2 == 0;
        }



        static bool isOdd(int x)
        {
            return x % 2 == 1;
        }



        static bool StartsWithA(string name)
        {
            return name.StartsWith("b");
        }








    }
}
