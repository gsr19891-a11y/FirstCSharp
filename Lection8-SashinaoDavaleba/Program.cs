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








}
