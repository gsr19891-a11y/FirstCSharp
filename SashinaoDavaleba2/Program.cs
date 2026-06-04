namespace SashinaoDavaleba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //leqcia2

            //davaleba 1

            Console.WriteLine("Welcome to the online elections! Enter your age to participate in the elections:");

            byte age;

            bool isAgeValid = byte.TryParse(Console.ReadLine(), out age);
  
            if(age > 110 && age < 1)
            {
                Console.WriteLine("Error! That age can't exist.");
            }
            else if(age >=18 && isAgeValid)
            {
                Console.WriteLine("Expected result: Congratulations! You have the right to vote.");
            }
            else if(age <18 && isAgeValid)
            {
                Console.WriteLine("Expected result: Unfortunately, you are not yet eligible to vote.");
            }
            else
            {
                Console.WriteLine("Error! Incorrect age!");
            }

        }
    }
}
