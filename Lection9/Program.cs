using System.Security.Cryptography.X509Certificates;

namespace Lection9
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ElectroProduct elProduct = new();
            Console.WriteLine(elProduct);

            Product product = new Product("Milk", -10, true);
            //product.Name = "Test";
            //product.Price = 103;
            //product.IsNutAndVegiterian();
            product.Print();



            //1) ინკაფსულაცია
            //2)მემკვიდრეობა
            //3)პოლიმორფიმი


            








        }
    }

    









}

