using Lecture_11_SashinaoDavaleba.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_11_SashinaoDavaleba.Models
{
    internal class Array1 : IOutput2, ICalc2
    {
        public Array1(int[] collection)
        {
            Collection = collection;
        }

        public int[] Collection { get; set; }



        public void ShowEven()
        {
            foreach (var item in Collection)
            {
                if (item == 0)
                {
                    Console.WriteLine($"{item} is not even and odd");
                }
                else if (item % 2 == 0)
                {
                    Console.WriteLine($"{item} is even");
                }

            }
        }

        public void ShowOdd()
        {
            foreach (var item in Collection)
            {
                if (item == 0)
                {
                    Console.WriteLine($"{item} is not even and odd");
                }
                else if (item % 2 == 1)
                {
                    Console.WriteLine($"{item} is odd");
                }

            }

        }





        public int CountDistinct()
        {
            bool isDublicated = false;
            int count = 0;

            for (int i = 0; i < Collection.Length; i++)
            {
                isDublicated = false;
                for (int j = 0; j < Collection.Length; j++)
                {

                    if (i == j) { continue; }

                    if (Collection[i] == Collection[j])
                    {
                        isDublicated = true;
                        break;

                    }

                }
                if (!isDublicated)
                {
                    count++;
                }

            }
            return count;
        }

        public int EqualToValue(int valueToCompare)
        {
           int count = 0;

            foreach (var item in Collection)
            {
                if (item == valueToCompare)
                {
                    count++;
                    
                }

            }








            return count;


        }



















    }



}
