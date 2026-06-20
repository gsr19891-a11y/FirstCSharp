namespace Lection8_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Product product = new();
            Random rand = new();
            Product[] producs = [product];

            

            product.Id = rand.Next(1, 100);

            Console.WriteLine("Enter Product name:");
            product.Name = Console.ReadLine();

            Console.WriteLine("Enter Product price:");
            product.Price = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product nuts true or false:");
            product.Nuts = bool.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product image:");
            product.Image = Console.ReadLine();

            Console.WriteLine("Product for vegetarian?:");
            product.Vegeterian = bool.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product spiciness:");
            product.Spiciness = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product category:");
            product.Categry = Console.ReadLine();


            foreach (var item in producs)
            {
                Console.WriteLine(item.ToString());
            }
            



            //Countdown(4);
            Sum(3);

            Book book = new Book
            {
                Id = 1,
                Title = "Csharp code",
                Author = "Bajadze",
                Pages = 400,
                Price = 40,
                Avialable = true,
            };

            book.GetInfo();
            book.ApplyDiscount(20);
            book.Borrow();

            Console.WriteLine(book.Price);


            List<Car> cars = new List<Car>
{
    new Car
    {
        Brand = "Mercedes",
        Model = "W211",
        Year = 2005,
        Fuel = 10,
        Speed = 0,
        isStarted = false
    },

    new Car
    {
        Brand = "BMW",
        Model = "F30",
        Year = 2015,
        Fuel = 50,
        Speed = 0,
        isStarted = false
    }
};

            foreach (var item in cars)
            {
                Console.WriteLine(item.Brand);
            }

            Car myCar = new Car();


            myCar.StartEngine();
            myCar.Refuel(15);
            myCar.Accelerate(120);






        }
        //geminis davalebebi------------------------------------

        /*
         
         //1
        static void Countdown(int n)
        {
            if (n == 0) {
                Console.WriteLine("start");
                return;
            }
 Countdown(n - 1);
            Console.WriteLine(n);

           
        }


        */
        //2



        static int Sum(int n)
        {
            if (n == 0) return 0;

            //Console.WriteLine(n);
            int result = n + Sum(n - 1);

            return result;

        }

        //static void addProduct(int id, string name, int price, bool nuts, string image, bool vegeterian, int spiciness, string category)
        //{


        //}

    }

    //davaleba 


    class Product
    {
        public int Id;
        public string Name;

        private int _price;
        public int Price
        {
            get => _price; set
            {
                if (value >= 0)
                {
                    Console.WriteLine("Price valid");
                    _price = value;
                }
                else
                {
                    _price = 0;
                    Console.WriteLine("Price not valid");
                }
            }
        }
        public bool Nuts;
        public string Image;
        public bool Vegeterian;
        public int Spiciness;
        public string Categry;
        public string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Price: {Price}, Category: {Categry}";
        }

    }


    public class Book
    {
        public int Id;
        public string Title;
        public string Author;
        public int Pages;
        public double Price;
        public bool Avialable;

        public void GetInfo()
        {
            Console.WriteLine($"Title:{Title}, Author: {Author}, Price: {Price}.");

        }
        public double ApplyDiscount(double percent)
        {
            Price -= Price * percent / 100;
            return Price;
        }
        public bool Borrow()
        {

            return Avialable = false;
        }
        public bool ReturnBook()
        {
            return Avialable = true;
        }
    }

    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Fuel { get; set; }
        public int Speed { get; set; }
        public bool isStarted { get; set; }

        public bool StartEngine()
        {
            return isStarted = true;
        }

        public bool StopEngine()
        {
            return isStarted = false;
        }

        public int Accelerate(byte speed)
        {
            return Speed = speed;
        }

        public int Brake(byte speed)
        {
            return Speed = 0;
        }

        public int Refuel(int fuel)
        {
            return Fuel += fuel;

        }


    }






}
