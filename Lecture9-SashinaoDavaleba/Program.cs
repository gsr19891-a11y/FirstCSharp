namespace Lecture9_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {


            #region cars

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

                //carsItem.CheckCar();
                
                

                elcar[index] = carsItem;
                index++;



            }
            foreach (var item in elcar)
            {
                //Console.WriteLine(item.ToString());

                
                
            }

            #endregion


            string path1 = "../../../AppliancesData.txt";
            string[] lines1 = File.ReadAllLines(path1);
            Appliances[] tech = new Appliances[lines1.Length];

            int i = 0;
            foreach (string line in lines1)
            {
                

                string[] parts = line.Split(",");

                Appliances appliance = new Appliances();
                appliance.Type = parts[0];
                appliance.Brand = parts[1];
                appliance.Model = parts[2];
                appliance.Price = int.Parse(parts[3]);
                appliance.PowerUsage = int.Parse(parts[4]);
                appliance.HasWifi = bool.Parse(parts[5]);


                tech[i] = appliance;
                i++;

                Console.WriteLine(appliance.ToString());

               
            }


        }
    }
}
