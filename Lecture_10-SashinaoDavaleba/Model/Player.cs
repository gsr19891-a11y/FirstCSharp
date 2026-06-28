using Lecture_10_SashinaoDavaleba.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10_SashinaoDavaleba.Model
{
    internal class Player : Sprite, IMovable, IDemegable
    {
        //public string Name { get; set; }
        //public int X {  get; set; }
        //public int Y {  get; set; }
        //public int HP { get; set; }

        public int Score { get; set; }
        public int HP { get; set; }

        public void Move(int x, int y)
        {
            Console.WriteLine("Player mooves on x and y");
        }

        Gun gun = new Gun();
       

        public string[] Inventory { get; set; }
    }
}
