using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_11.Interfaces
{
    internal interface IDemegable
    {
        public int HP { get; set; }
        public void Damage(int damage)
        {
            HP -= damage;

        }
    }
}
