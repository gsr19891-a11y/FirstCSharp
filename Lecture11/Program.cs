using Lecture_11.Models;

namespace Lecture11
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Enemy enemy = new Enemy();
            enemy.Name = "Vader";
            enemy.Damage = 100;
            enemy.HP = 10;
            enemy.X = 40;
            enemy.Y = 150;

            Enemy enemy2 = new Enemy();
            enemy.Name = "Vader";
            enemy.Damage = 200;
            enemy.HP = 10;
            enemy.X = 40;
            enemy.Y = 150;






            Player player = new Player();
            player.Name = "Luke";
            player.HP = 15;
            player.Score = 100;
            player.X = 50;
            player.Y = 150;



            player.Inventory = [new Gun("Ak47", 30), new Gun("m4", 25), ];




            Food food = new Food();
            food.Name = "GoldApple";
            food.Heal = 5;
            food.X = 50;
            food.Y = 150;

food.Eat(player);


         
            












        }
    }
}
