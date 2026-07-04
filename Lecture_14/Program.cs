namespace Lecture_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int y = 0;
            try
            {
                Console.WriteLine(x / y);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("hI");

            }






        }
    }
}
