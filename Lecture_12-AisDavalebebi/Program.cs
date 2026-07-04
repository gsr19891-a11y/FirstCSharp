using Lecture_12_AisDavalebebi.Interfaces.Models;

namespace Lecture_12_AisDavalebebi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Electronics laptop = new Electronics("Ноутбук", 1200, 12);

          
            Electronics phone = new Electronics("Смартфон", 800, 24);

            Electronics tv = new Electronics("tv", 4500, 21);

          
            laptop.PrintDetails();

            phone.PrintDetails(); 
            tv.PrintDetails();
        }
    }
    
}
