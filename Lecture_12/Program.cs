using Lecture_12.Helper;
using Lecture_12.Models;

namespace Lecture_12
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr = [50,60,0,30,11,23,17];
            string[] arr10 = ["hola", "dfdg", "dfs22w", "worldd"];

            Array1 arr1 = new Array1(arr);


            Student[] students = new Student[] {new Student(20,"john"), new Student(23, "hukk")};

            //Array1 arr2 = new Array1(new int[] { 40, 50, 10 });
            //arr1.ShowEven();

            //arr1.ShowOdd();

            ArrayHelper.PrintArray<int>(arr);

            ArrayHelper.PrintArray<Student>(students);




            ArrayHelper.PrintArray<string>(arr10);










        }
    }
}
