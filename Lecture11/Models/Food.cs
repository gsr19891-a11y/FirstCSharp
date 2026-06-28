using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_11.Models
{
    internal class Food : Sprite
    {
        public int Heal { get; set; }

        public void Eat(Player player)
        {
            player.HP += Heal;
        }

    }
}
