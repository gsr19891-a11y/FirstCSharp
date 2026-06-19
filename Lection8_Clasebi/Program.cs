namespace Lection8_Clasebi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(Powerer(2, 3));

            Random rantom = new();
            Console.WriteLine(rantom.Next(1, 10));

            User user = new(); // {}
            user.Username = "John";
            user.Age = 20;
            //Console.WriteLine($"User name: {user.username}, Age: {user.age}");

            user.Email = "dfdwfe@";

            var user2 = new User();
            user2.Username = "sashka";
            user2.Age = 30;


            int[] saxeli = [];
            User[] users = [user, user2];

            foreach (User item in users)
            {
                item.Print();
            }

        }



        static int Powerer(int num, int pow)
        {
            if (pow == 1)
            {
                return num;
            }
            return num * Powerer(num, pow - 1);
        }

    }

    //!!!!!!! თუ public - ვწერთ დიდი ასოთი


    class User // მახასიათებლები(ფილდები და პროფერთი)      და მეთოდები
    {



        //ფილდი---------------------------------------
        private string password;
        public string Username;
        public int Age;

        //ფროფერტი------------------------------------
        public string Phone { get; set; }



        //full ფროფერტი ფილდი + ფროფერტი------------
        private string _idNumber;
        public string IdNumber { get; set; }


        private string _email;
        public string Email
        {
            get => _email; set
            {
                if (!value.Contains("@")) {
                    Console.WriteLine("Email is not valid!");
                    return;
                }
                else
                {
                    Console.WriteLine("Email valid!");
                }
                _email = value;
            }
        }




        public void Print()// ეს მეთოდია
        {
            Console.WriteLine($"{Username} {Age} {Email}");
        }
    }
}
