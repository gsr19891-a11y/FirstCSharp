using System.Text;

namespace Lection6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region გამეორება


            Random rand = new Random();

            /*

            int[] arr1 = new int[6];

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = rand.Next(1,50);
                
            }
            
            foreach (int num in arr1)
            {
                //Console.WriteLine(num);
            }



            int[] arr2 = [23, 11, 34, 50, 12, 9];

            foreach (int num in arr2)
            {
                double result = (num * num) / 2;

                //Console.WriteLine(result);
                
            }

            int[][] arr3 = [
                [21,33],
                [12,46,52,31],
                [32,74,12]
                ];

            int sum = 0;

            for (int i = 0; i < arr3.Length; i++)
            {
                foreach (int num in arr3[i])
                {
                    sum += num;
                    Console.WriteLine(num);
    
                }

            }
            //Console.WriteLine(sum);

            */


            //davaleba 1


            int[] arr1 = [21, 43, 11];

            int[] arr2 = [32, 61, 51];

            int[] resultArray = new int[arr1.Length + arr2.Length];


            for (int i = 0; i < arr1.Length; i++)
            {
                resultArray[i] = arr1[i];

            }

            for (int i = 0; i < arr2.Length; i++)
            {
                resultArray[arr1.Length + i] = arr2[i];
            }

            foreach (int num in resultArray)
            {
                //Console.WriteLine(num);
            }






            #endregion

            //=================================================================================================

            // 2D matrica


            //jagged
            int[][] points = [
                [20,30,60],
                [10,33,12],
                []
                ];

            //Console.WriteLine(points[1][0]);

            foreach (int[] num in points)
            {
                foreach (int item in num)
                {
                    //Console.WriteLine(item);

                }


            }


            //matrix
            int[,] matrix = {
            {7,8,2 },
            { 11,6,4},
            { 41,5,8}
            };


            //davaleba 2

            int[] nums = [3, 5, -4, 8, 11, 1, -1, 6];
            int count = 0;
            int[][] resultArr = new int[count][];


            int index = 0;

            //bool isValid = int.TryParse(Console.ReadLine(), out int targetSum);

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] + nums[i] == 7)
                    {
                        //resultArray[index] = [nums[i], nums[j]];
                        //index++;
                    }

                }

            }

            //Console.WriteLine(resultArray);


            //davaleba saklaso 

            int sum = 0;
            int boxPrice = 0;

            int[][] container = [
                [50,80,70,12,55],
                [12,44,63,72,66],
                [17,30,56,77,22]
                ];

            foreach (int[] box in container)
            {
                foreach (int prod in box)
                {
                    sum += prod;

                }
            }

            foreach (int prod in container[0])
            {
                boxPrice += prod;

            }

            //Console.WriteLine(boxPrice);
            //Console.WriteLine(sum);


            //===========================================================

            int totalSum = 0;


            int[][] cont = [
                [20,60,70],
                [80,100,10,50],
                [15,30,90]
                ];


            int[] sums = new int[cont.Length];


            for (int i = 0; i < cont.Length; i++)
            {
                int boxSum = 0;

                for (int j = 0; j < cont[i].Length; j++)
                {
                    totalSum += cont[i][j];
                    boxSum += cont[i][j];
                    sums[i]= boxSum;


                }

                Console.WriteLine($" {i+1}box sum is {boxSum}");

            }

            Console.WriteLine($"total sum is {totalSum}");

            int min = sums[0];
            for (int i = 0; i < sums.Length; i++)
            {
                if (sums[i] < min)
                {
                    min = sums[i];
                }      
            }
            Console.WriteLine(min * 0.8);





            //string 

            string x = "sdfdwsfg";

            String test2 = new String("Hellooo");

            Console.WriteLine(x[0]);

            x = "hello";



            StringBuilder sb = new StringBuilder();

            sb.Append("hello");
            sb.Append("world");

            sb.AppendLine("Hello 2");


            sb.Replace("hello", "hi");






        }
    }
}
