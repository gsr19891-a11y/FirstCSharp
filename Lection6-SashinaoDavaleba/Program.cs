namespace Lection6_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //დავალება 1


            /*
            int[][] arr1 = [
                [8,4,6,10],
                [9,3,5,7],
                [10,2,4,3],
                ];




            for (int i = 0; i < arr1.Length; i++)
            {
                double sum = 0;
                for (int j = 0; j < arr1[i].Length; j++)
                {
                    sum += arr1[i][j];

                }
                double average = sum / arr1[i].Length;
                //Console.WriteLine($"student {i + 1}: sum points = {sum}, avergae points = {average}");

            }
            


            //2

            Console.WriteLine("Enter passcode");

            bool isPassValid = int.TryParse(Console.ReadLine(), out int userPass);

            int[] arr = [1234, 4321, 1111, 2222, 5422, 5555, 6677, 8444, 6312, 1091];



            if (isPassValid)
            { bool isFound = false;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] == userPass)
                    {
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    Console.WriteLine("Correct!");
                }
                else
                {
                    Console.WriteLine("Wrong!");
                }
            }
            else
            {
                Console.WriteLine("Input error!");
            }




            //3


            int[] arr = [12, -1, 22, -51, -9, 50, 60, 11, 23];

            int max = arr[0];
            int min = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
               if(arr[i] > max)
                {
                    max = arr[i];
                }
               if(arr[i] < min)
                {
                    min = arr[i];
                }

            }

            Console.WriteLine($"min num: {min}");
            Console.WriteLine($"max num: {max}");


            //4

            string[] str = ["Hello", "World!"];

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str[i].Length; j++)
                {
                    Console.WriteLine(str[i][j]);
                }    
            }


            //5

            string[] emailArr = ["Giorgi@gmail.com", "gsr19891@gmail.com", "hh@gmail.com", "step@mail.ge"];

            bool allEmailsValid = true;

            for (int i = 0; i < emailArr.Length; i++)
            {
                bool emailValid = false;

                for (int j = 0; j < emailArr[i].Length; j++)
                {
                    if(emailArr[i][j] == '@')
                    {
                        emailValid = true;
                    }

                }

                if (!emailValid)
                {
                    allEmailsValid = false;
                }

            }

            if (allEmailsValid) {
                Console.WriteLine("All emails with @");
            }
            else
            {
                Console.WriteLine("Some emails without @");
            }
*/


            //geminis დავალებები: 
            //1


            /*
            int[][] arr10 = [
                [8,4,6,10],
                [9,3,5,7],
                [10,2,4,3],
                ];


            for (int i = 0; i < arr10.Length; i++)
            {
                double maxPoints = 0;

                for (int j = 0; j < arr10[i].Length; j++)
                {
                    if (arr10[i][j] > maxPoints)
                    {
                        maxPoints = arr10[i][j];

                    }


                }
                //Console.WriteLine($"student {i + 1}: Max points: {maxPoints}");
            }

            //2

            int[][] arr11 = [
                [1,4,6,5],
                [9,3,5,1],
                [10,2,4,3],
                ];


            

            for (int i = 0; i < arr11.Length; i++)
            {
                int point = 0;

                for (int j = 0; j < arr11[i].Length; j++)
                {
                    if (arr11[i][j] < 4){
                        point++;
                    }
                    
                }

                Console.WriteLine(point);


            }
            

            //3

            int[][] arr10 = [
               [8,4,6,10],
                [9,3,5,7],
                [10,2,4,3],
                ];
            int point = 0;


            double averageSum = 0;

            for (int i = 0; i < arr10.Length; i++)
            {


                foreach (int item in arr10[i])
                {
                    point ++;
                    averageSum += item;

                }

                

            }
averageSum = averageSum / point;
            Console.WriteLine(point);
            Console.WriteLine(averageSum);



            //3

            int[][] arr10 = new int[][] {
    new int[] { 8, 9, 10 },
    new int[] { 10, 9, 9 },
    new int[] { 5, 9, 10 }
};


            for (int i = 0; i < arr10.Length; i++)
            {
                int point = 0;

                for (int j = 0; j < arr10[i].Length; j++)
                {

                    if (arr10[i][j] >= 9)
                    {
                        point++;
                    }
                }

                if(point == arr10[i].Length)
                {
                    Console.WriteLine($"student {i + 1}");
                }     
            }



            //4

            int[][] arr = new int[][] {
    new int[] { 2, 3, 1 }, 
    new int[] { 4, 3, 2 }, 
    new int[] { 1, 2, 3 }  
};
            

            for (int i = 0; i < arr.Length; i++)
            {int points = 0;

                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] < 4)
                    {
                        points++;
                    }
                }
                if (points == arr[i].Length)
                {
                    Console.WriteLine($"studentma ver chhabara: {i + 1}");
                }

            }





            //5
            int[][] arr = new int[][] {
    new int[] { 4, 5, 6 }, 
    new int[] { 8, 9, 10 } 
};

            for (int i = 0; i < arr.Length; i++)
            {
  
                int sum = 0;


                for (int j = 0; j < arr[i].Length; j++)
                {
                    sum += arr[i][j];
                   
                }
                double average = sum /arr[i].Length;

                int point = 0;

                for (int j = 0; j < arr[i].Length; j++)
                {
                    if(arr[i][j] > average)
                    {
                        point++;
                    }
                    
                }


                Console.WriteLine($"{i + 1} stunetis sashualo qulaa :{average}, {point} ");
            }



            //6


            int[][] arr = new int[][] {
            new int[] { 5, 5, 5 },   
            new int[] { 10, 10, 10 },
            new int[] { 4, 4, 4 } 
             };


            int maxSum = 0;     
            int bestStudent = 0; 


            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;
                for (int j = 0; j < arr[i].Length; j++)
                {
                    sum += arr[i][j];
                }

                if (sum > maxSum)
                {
                    maxSum = sum;
                    bestStudent = i;
                }

            }

            Console.WriteLine($"Студент {bestStudent + 1} набрал больше всего баллов: {maxSum}");





            //7
            int[][] arr = new int[][] {
    new int[] { 8, 3, 6 }, // четные: 8, 6. Всего: 2.
    new int[] { 9, 5, 2 }  // четные: 2. Всего: 1.
};


            for (int i = 0; i < arr.Length; i++)
            {int count = 0;

                for (int j = 0; j < arr[i].Length; j++)
                {
                    if(arr[i][j] % 2 == 0)
                    {
                        count++;
                    }
                    
                }

                Console.WriteLine($"studenti {i + 1}: luwi ricxvebis raodenoba = {count}");

            }

            //8

            int[][] arr = new int[][] {
    new int[] { 4, 9, 2, 7 }, // мин: 2, макс: 9
    new int[] { 10, 6, 8 }    // мин: 6, макс: 10
};


            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i][0];
                int max = arr[i][0];

                for (int j = 0; j < arr[i].Length; j++)
                {
                    if( arr[i][j] < min)
                    {
                        min = arr[i][j];
                    }

                    if (arr[i][j] > max)
                    {
                        max = arr[i][j];
                    }
                    
                }
                Console.WriteLine($"studenti {i + 1}: min ricxvebis raodenoba = {min}, maqsimaluri: {max}");

            }


            //9

            int[][] arr = new int[][] {
    new int[] { 4, 9, 2, 7 },
    new int[] { 10, 6, 8, 5 }
};

            for (int i = 0; i < arr.Length; i++)
            {

                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] % 2 != 0)
                    {
                        arr[i][j] = 0;
                    }
                    
                }

            }
            for (int i = 0; i < arr.Length; i++)
            {
                //Console.WriteLine($"student {i + 1}: {string.Join(", ", arr[i])}");
            }



            //10

            int[][] arr = new int[][] {
    new int[] { 5, -3, 8 },    
    new int[] { -1, 4, -2, 9 } 
};

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] < 0)
                    {
                        arr[i][j] = 0;
                    }
                    
                }
          
                Console.WriteLine( string.Join(", ", arr[i]));

            }



            //11


            int[][] arr = new int[][] {
    new int[] { 3, 6, 2, 7 },  
    new int[] { 5, 4, 10, 9 }  
};


            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] > 5)
                    {
                        arr[i][j] = 5;
                    }

                }

                Console.WriteLine(string.Join(",", arr[i]));

            }

       

            //12

            int[][] arr = new int[][] {
    new int[] { 4, 9, 2, 7 }, 

    new int[] { 10, 6, 8, 5 } 
};
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if(j % 2 == 0)
                    {
                        arr[i][j] = 0;
                    }
                    
                }
                Console.WriteLine(string.Join(",", arr[i]));

            }


 */














        }
    }
}
