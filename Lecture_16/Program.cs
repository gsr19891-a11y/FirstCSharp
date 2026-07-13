namespace Lecture_16
{
    internal class Program
    {
        static void Main(string[] args)
        {



            //Stack==========================================================================
            //push pop----------------------------------------
            Stack<int> stack = new Stack<int>(); //LIFO - last in first out

            stack.Push(100);
            stack.Push(200);
            stack.Push(300);

            stack.Pop();//ამოაგდებს ბოლოში ვინცაა(300)

            foreach (var item in stack)
            {
                Console.WriteLine(item);
                
            }

            stack.Peek();//ბოლოში ვინცაა იმას გამოიტანს მაგრამ არ ამოაგდებს


            //Queue==========================================================================
            Queue<int> queue = new Queue<int>(); //FIFO - first in first out

            queue.Enqueue(100);//დამატება ბოლოში
            queue.Enqueue(200);

            queue.Peek(); //100


            queue.Dequeue(); //ამოაგდებს პირველ ელემენტს(100)




            //HashSet==========================================================================


            HashSet<int> hash = new HashSet<int>(); //მხოლოდ უნიკალურ ტიპებს შეინახავს!
            hash.Add(100);
            hash.Add(200);
            hash.Add(100);


            foreach (var item in queue)
            {
                Console.WriteLine(item);
                
            }

            int[] arr = new int[] { 1, 2, 1, 1, 5 };

            var uniqueNumbers = arr.ToHashSet();

            foreach (var item in uniqueNumbers)
            {
                Console.WriteLine(item);
                
            }


            Dictionary<int, int> hotline = new Dictionary<int, int>();

            hotline.Add(100, 200);





        }
    }
}
