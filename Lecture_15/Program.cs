using Lecture_15.Exeptions;
using Lecture_15.Models;

namespace Lecture_15
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //try
            //{
            //    BankTransfer bankTransfer = new BankTransfer();
            //    bankTransfer.IBAN = "";

            //}
            //catch(InvalidIbanExeption ex)
            //{
            //    Console.WriteLine(ex.Message);

            //}



            //list==========================================================

            int[] arr = [20, 30, 40];

            List<int> list = new List<int>() { 2, 4, 1, 5 };
            Console.WriteLine(list.Count());

            list[0] = 100;

            list.Add(200);
            list.AddRange(10, 20, 30);
            list.AddRange(arr);

            list.Insert(1,300); //რომელ ინდექსზე რა ჩავანატოთ და გაწიოს ამის მერე რა რიცხვებიცაა

            list.Remove(20);// წაშლის პირველ მაგ რიცხვს

            list.RemoveAt(5);//5 ინდექსზე წაშლის ელემენტს
            list.Clear();//წაშლის ყველა ელემენტს

            list.Sort(); //დალაგება ზრდადობით
            list.Reverse();
            list.Max();
            list.Min();

            list.Average();

            //list.Capacity(); //რამდენი ელემენტისთვის აქვს ადგილი გამოყოფილი

            int[] ints = list.ToArray();//მასივში გადაყავს------------------------
            List<int> list2 = arr.ToList();//მასივიდან სიაში გადაყავს--------------


            //List<string> list2 = new List<string>();

            //List<BankTransfer> list3 = new List<BankTransfer>();

            BankTransfer bankTransfer1 = new BankTransfer("iban1", "bank1");


            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);

            }


            List<Money> moneyList = new List<Money>();

            //Money money1 = new Money() { Currency = "USD", Amount = 100 };
            //Money money2 = new Money() { Currency = "USD", Amount = 350 };

            //moneyList.AddRange(money1, money2);

            moneyList.Sort();
            moneyList.Reverse();






        }

      
    }
}
