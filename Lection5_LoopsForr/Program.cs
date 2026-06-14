namespace Lection5_LoopsForr
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region davalebbei
            //დავალებების განიხილვა

            //1------------------------------
            /*
            Console.WriteLine("Enter Number:");
            bool isNumValit = int.TryParse(Console.ReadLine(), out int num);

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{num * i}");
            }

            //2-------------------------------

            int line = 4;

            for (int i = 1; i <= line; i++)
            {
                for (int k = line - i - 1; k >= 0 ; k--)
                {
                    Console.Write(' ');
                }
                for (int j = 1; j <= i ; j++)
                {
                    Console.Write(" *");          
                }

                Console.WriteLine();
            }
           

            //3-------------------------------


            Console.WriteLine("Enter Number:");

            bool isValit = int.TryParse(Console.ReadLine(), out int num);

            int sum = 0;

            for (int i = 2; i < num; i+=2)
            {

                sum += i;
                
            }
            Console.WriteLine(sum);


            //4------------------------------


            Random random = new Random();


            int ran = random.Next(0,100); //-2 mlrs + 2 miliardamde

            Console.WriteLine("Enter number:");
            

            bool isGuessed = true;

            do
            {bool isValid = int.TryParse(Console.ReadLine(), out int userNum);
                if(userNum == ran)
                {
                    isGuessed = false;
                }else if(userNum > ran)
                {
                    Console.WriteLine("Lower");
                }else if(userNum < ran)
                {
                    Console.WriteLine("Highter");
                }

            }while (isGuessed);


            //=========================================================================================


            //davaleba saklaso 

            Console.WriteLine("Enter Number:");

            int sum = 0;

            bool isValid = int.TryParse(Console.ReadLine(), out int userNum);

            int start = userNum + 6 - (userNum % 6);

            

            for (int i = start ; i < 100; i +=6 )
            {
                    sum += i; 
            }
            Console.WriteLine(sum);
 */




            #endregion===========================================================


            Random random = new Random();


            int[] arr = [12,46,11];
            int[] arr1 = { };


            arr[0] = 100;


            int[] arr2 = new int[5]; //[0,0,0,0,0]

            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = random.Next(1,100);
                //Console.WriteLine(arr2[i]);
                
            }

            foreach (int num in arr2)
            {
                Console.WriteLine(num);
            }


            // value         vs          referance

            //value
            int x = 5;

            int y = x;
            //  5   5

            y = 10;

            //x=5       y=10 - შეიცვლება ხმოლოდ y


            //---------------------

            //referance
            int[] arr7 = [20, 10, 50];
            int[] arr8 = arr7;

            arr8[0] = 1000;//ორივე შეიცვლება



            //2D array(მატრიცა)


            //jagged array - მასსივების მასივი
            int[][] numbers = 
                [
                [10,22,43],
                [31,44,52],
                [10,21,75]
                ];

            Console.WriteLine(numbers[0][0]);


            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    Console.WriteLine(numbers[i][j]);
                    
                }

            }


            int[][] numbers3 = new int[2][]; 



        


        }
    }
}
