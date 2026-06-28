using Lecture_12.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_12.Models
{
    internal class Array1 : IOutput2
    {
        public Array1(int[] collection)
        {
            Collection = collection;
        }

      

        public int[] Collection {  get; set; }

        public void ShowEven()
        {
            foreach (var item in Collection)
            {
                if(item == 0)
                {
                    Console.WriteLine($"{item} - is not odd or even");
                }
                else if (item % 2 == 0)
                {Console.WriteLine($"{item} - is even");
                    
                }

            }
        }

        public void ShowOdd()
        {
            foreach (var item in Collection)
            {
                if (item % 2 == 1)
                {
                    Console.WriteLine($"{item} - is odd");
                }
                else if (item == 0) {
                    Console.WriteLine($"{item} - is not odd or even");
                }

            }
        }
    }
}
