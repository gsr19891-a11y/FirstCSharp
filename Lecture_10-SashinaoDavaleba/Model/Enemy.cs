using Lecture_10_SashinaoDavaleba.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10_SashinaoDavaleba.Model
{
    internal class Enemy : Sprite, IMovable, IDemegable, IComparable<Enemy>
    {
        //public string Name { get; set; }
        //public int X { get; set; }
        //public int Y { get; set; }
        //public int HP { get; set; }

        public int Score { get; set; }
        public int Damage { get; set; }
        public int HP { get; set; }


        public int CompareTo(Enemy enemy)
        {
            return Damage.CompareTo(enemy.Damage);
        }


        public void Move(int x, int y)
        {
            Console.WriteLine("Enemy mooves on x and y");
        }


        public void OnCollision(Player player)
        {
            if (X == player.X && Y == player.Y)
            {
                if (HP > player.HP)
                {
                    player.HP -= Damage;
                }
                else
                {
                    HP = 0;
                }
            }
        }
    }
}
