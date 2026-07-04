using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_14.Helpers
{
    internal class ArrayHelper
    {
        public static int CountElements<T>(T[] collections)
        {
            int count = 0;
            foreach (var item in collections)
            {

                count++;
            }
            return count;
        }


        public static int FindIndex<T>(T[] collections, T element)
        {

            for (int i = 0; i < collections.Length; i++)
            {
                if (collections[i].Equals(element))
                {
                    return i;
                }


            }
            return -1;
        }


        public static T[] Swap<T>(T[] collections, int ind1, int ind2)
        {

            T temp = collections[ind1];

            collections[ind1] = collections[ind2];

            collections[ind2] = temp;

            return collections;


        }

    }
}
