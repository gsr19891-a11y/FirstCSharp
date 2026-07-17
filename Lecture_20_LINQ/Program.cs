namespace Lecture_20_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LINQ-------------------------------------------



            List<int> num = new List<int> { 50,40,22,34,224,53,22,6,15,7,19,35,25,8,24,61,23};






            //query (იშვიათია)
            var odds = from n in num
                       where n % 2 == 1
                       select n;




            //method

            var odds1 = num
                .Where(x=> x % 2 == 1) //50
                .Skip(2)//48
                .Take(5)
                .OrderBy(x => x);//5

            foreach (var item in odds1)
            {
                Console.WriteLine(item);
                
            }








            var result = num.FirstOrDefault(x => x >50);
            //Console.WriteLine(result);


            var result3 = num.LastOrDefault(x => x > 50);
            //Console.WriteLine(result3);



            try
            {
                var result2 = num.FirstOrDefault(x => x > 100);
            }
            catch (Exception ex) { 
            Console.WriteLine(ex.Message);
            }









        }
    }
}
