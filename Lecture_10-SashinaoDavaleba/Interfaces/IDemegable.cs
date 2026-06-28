using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10_SashinaoDavaleba.Interfaces
{
    internal interface IDemegable
    {
        public int HP { get; set; }
        public void Demeg(int demage) { 
        HP -= demage;
        }
    }
}
