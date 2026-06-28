using Lecture_12.Models;

namespace Lecture_12
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = [50,60,0,30,11,23,17];

            Array1 arr1 = new Array1(arr);

            //Array1 arr2 = new Array1(new int[] { 40, 50, 10 });
            arr1.ShowEven();

            arr1.ShowOdd();
















        }
    }
}
