using Lecture_11_SashinaoDavaleba.Models;

namespace Lecture_11_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int[] arr1 = [12, 33,33,33, 41, 55, 8,8];

            Array1 arr2 = new Array1(arr1);


            arr2.ShowEven();

            arr2.ShowOdd();

            Console.WriteLine(arr2.CountDistinct());


            Console.WriteLine(arr2.EqualToValue(33));
        }
    }
}
