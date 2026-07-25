using Lecture_20_SashinaoDavaleba.Model;

namespace Lecture_20_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var products = new List<Product>
      {
          new Product { Name = "M1 Abrams Model Kit", Category = "Models", Price = 45.50m, Stock = 12 },
          new Product { Name = "Cyberpunk 2077", Category = "Games", Price = 59.99m, Stock = 0 },
          new Product { Name = "T-90 Tank Blueprint Poster", Category = "Posters", Price = 15.00m, Stock = 50 },
          new Product { Name = "Witcher 3: Wild Hunt", Category = "Games", Price = 29.99m, Stock = 8 },
          new Product { Name = "Leclerc Tank 3D Model", Category = "Digital", Price = 89.00m, Stock = 3 },
          new Product { Name = "Half-Life: Alyx", Category = "Games", Price = 59.99m, Stock = 15 }
      };
       
            IEnumerable<string> gameNames = products
                .Where(p => p.Category == "Games" && p.Stock > 0)
                .Select(p => p.Name);


            foreach (var item in gameNames)
            {
                Console.WriteLine(item);
                
            }


            var topExpensive = products
    .Where(p => p.Stock > 0)
    .OrderByDescending(p => p.Price)
    .ThenBy(p => p.Name)
    .Take(3);



            bool hasVeryExpensive = products.Any(p => p.Price > 100m);

          
            decimal totalWarehouseValue = products.Sum(p => p.Price * p.Stock);


            var categoryCounts = products
                .GroupBy(p => p.Category)
                .Select(group => new
                {
                    CategoryName = group.Key,
                    Count = group.Count()
                });

           



            Product cyberpunk = products.FirstOrDefault(p => p.Name == "Cyberpunk 2077");





        }
    }
}
