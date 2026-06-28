using Lecture_11.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_11.Models
{
    internal class Enemy : Sprite, IMoveble, IDemegable
    {


        public int Damage { get; set; }
        public int HP { get; set; }

        public void Move(int x, int y)
        {
            Console.WriteLine("Enemy moves");
        }

        public void onColision(Player player)
        {
            if(X == player.X && Y == player.Y)
            {
                if(HP > player.HP)
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
