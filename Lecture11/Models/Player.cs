using Lecture_11.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_11.Models
{
    internal class Player : Sprite, IMoveble, IDemegable
    {
  
        public int Score { get; set; }
        public int HP { get; set; }



        public Gun[] Inventory { get; set; }









        public void Move(int x, int y)
        {
            Console.WriteLine("Player moves");
        }
    }
}
