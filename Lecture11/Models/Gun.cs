using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_11.Models
{
    internal class Gun
    {
        public Gun(string name, int ammo)
        {
            Name = name;
            Ammo = ammo;
        }

        public string Name { get; set; }
        public int Ammo { get; set; }
    }
}
