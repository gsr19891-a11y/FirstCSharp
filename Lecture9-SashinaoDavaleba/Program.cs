namespace Lecture9_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {
       

            //string pasth = "C:\\Users\\Giorg\\Desktop\\C#\\CSharp\\Lecture9-SashinaoDavaleba\\CarsData.txt";

            string path = @"../../../CarsData.txt";

            string[] lines = File.ReadAllLines(path);
            Car[] elcar = new Car[lines.Length];

            int index = 0;

            foreach (string line in lines)
            {
                //Console.WriteLine(line);
                string[] parts = line.Split(',');
                Car carsItem = new();
                carsItem.Brand = parts[0];
                carsItem.Model = parts[1];
                carsItem.Year = int.Parse(parts[2]);
                carsItem.Price = int.Parse(parts[3]);
                carsItem.Color = parts[4];

                carsItem.CheckCar();
                
                

                elcar[index] = carsItem;
                index++;



            }
            foreach (var item in elcar)
            {
                Console.WriteLine(item.ToString());

                
                
            }

            


        }
    }
}
