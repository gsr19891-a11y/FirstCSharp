using Lecture_10_SashinaoDavaleba.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10_SashinaoDavaleba.Model
{
    internal class Food : Sprite
    {
        //public string Name { get; set; }
        //public int X { get; set; }
        //public int Y { get; set; }
        public int Heal { get; set; }

        //public override void Move(int x, int y);

        public void Eat(Player player)
        {
            player.HP += Heal;
        }

    }
}
