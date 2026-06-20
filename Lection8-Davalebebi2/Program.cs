using System.IO;
namespace Lection8_Davalebebi2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region varjishi
            byte[] nums = [1, 34, 23, 43];
            byte res = Summa(nums);
            //Console.WriteLine(res);


            //=======================

            string word = "Hello";
            word += "!";

            //concat
            word = string.Concat(word, "World");


            //compare
            //Console.WriteLine(string.Compare(word, "Hello! World"));

            //создвет массив из слов(разделение)
            string people = "Alex,Bob,Steve";
            string[] names = people.Split(new char[] { ',' });
            foreach (var item in names)
            {
                //Console.WriteLine(item);

            }



            //соединение
            people = string.Join("-", names);
            //Console.WriteLine(people);


            //trim удаление пробелов
            //Console.WriteLine(word.Trim());

            //substring
            //Console.WriteLine(word.Substring(0,word.Length - 1));//ბოლოდან მოჭრა 1 ასო

            //tolower/ toupper




            //Console.WriteLine("Enter text:");
            //string text = Console.ReadLine();

            //using (FileStream stream = new FileStream("info.txt", FileMode.OpenOrCreate))
            //{
            //    //byte[] array = System.Text.Encoding.Default.GetBytes(text);

            //    stream.Write(array, 0, array.Length);
            //}

            //using (FileStream stram1 = File.OpenRead("info.txt"))
            //{
            //    byte[] array = new byte[stram1.Length];
            //    stram1.Read(array, 0, array.Length);

            //    string textFromFile = System.Text.Encoding.Default.GetString(array);
            //    //Console.WriteLine($"{textFromFile}");

            //}
            #endregion



            //try catch =============================================================================


            Console.WriteLine("Enter Num");
            try
            {
                int num11 = int.Parse(Console.ReadLine());
                Console.WriteLine(num11);

            }
            catch (FormatException)
            {
                Console.WriteLine("Error input!");
            }















        }


        public static byte Summa(byte[] digits)
        {
            byte sum = 0;
            foreach (byte el in digits)
            {
                sum += el;

            }
            return sum;
        }








    }




}
