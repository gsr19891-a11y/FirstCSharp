using Lecture_10_SashinaoDavaleba.Enum;
using Lecture_10_SashinaoDavaleba.Model;

namespace Lecture_10_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {
         

        
            Employ[] employs = new Employ[8];

            employs[0] = new Employ("John", "Sukhashvili", new DateTime(1990, 1, 12), Country.France, Gender.Male, "511232231", "john@gmail.com", "fax1");
            employs[1] = new Employ("Mari", "Marishvili", new DateTime(2003, 11, 21), Country.Georgia, Gender.Female, "112233443", "marrr@mail.com", "fax2");
            employs[2] = new Employ("Luka", "Charkviani", new DateTime(2000, 5, 21), Country.Italy, Gender.Male, "4413895412", "lukaa@mail.ge", "fax3");
            employs[3] = new Employ("George", "Same", new DateTime(1995, 4, 18), Country.Spain, Gender.Male, "511122231", "geo@gmail.com", "fax4");
            employs[4] = new Employ("Goga", "Mishvili", new DateTime(2002, 11, 21), Country.Georgia, Gender.Male, "112233443", "gugg@mail.com", "fax5");
            employs[5] = new Employ("Lony", "Polkovksy", new DateTime(1999, 8, 8), Country.France, Gender.Male, "4485895419", "polk@mail.ge", "fax6");
            employs[6] = new Employ("Nona", "Iremashvili", new DateTime(2002, 1, 22), Country.Italy, Gender.Female, "588232231", "noni@gmail.com", "fax7");
            employs[7] = new Employ("Babi", "Kupnoshvili", new DateTime(1985, 7, 14), Country.Georgia, Gender.Female, "112288843", "bab@mail.com", "fax8");


            Employ.FindCountry(Country.Georgia, employs);



            Enemy enemy = new Enemy();
            enemy.Name = "Iani";
            enemy.Damage = 300;
            enemy.HP = 5;
            enemy.X = 40;
            enemy.Y = 150;


            Enemy enemy1 = new Enemy();
            enemy1.Name = "Iani1";
            enemy1.Damage = 200;
            enemy1.HP = 5;
            enemy1.X = 40;
            enemy1.Y = 150;


            Console.WriteLine(enemy.CompareTo(enemy1));

            Player player = new Player();
            player.Name = "Iani";
            player.Score = 0;
            player.HP = 3;
            player.X = 40;
            player.Y = 150;

            //player.Inventory = [new Gun("AK47", 30), new Gun("M4", 25)];



            Food food = new Food();
            food.Name = "testFood";
            food.Heal = 10;
            food.X = 40;
            food.Y = 150;

            Console.WriteLine(player.HP);

            food.Eat(player);

            Console.WriteLine(player.HP);


        }
    }
}

//როგორია ტიპი - კალსი(აღწერა)
//რა შეუძლია - ინტერფეისი(ქონტრაქტი)