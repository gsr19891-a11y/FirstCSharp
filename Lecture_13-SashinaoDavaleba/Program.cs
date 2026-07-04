using Lecture_13_SashinaoDavaleba.Helpers;

namespace Lecture_13_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 8 };

            //ArrayHelper.PrintArray(numbers);

            //ArrayHelper.GetFirstElement(numbers);

            //ArrayHelper.GetLastElement(numbers);

            //Console.WriteLine(ArrayHelper.ContainsElement(numbers, 30));

            //ArrayHelper.CountElements(numbers);

          //Console.WriteLine  (ArrayHelper.FindIndex(numbers, 8));

            ArrayHelper.Swap(numbers, 0, 1);
        }
    }
}
