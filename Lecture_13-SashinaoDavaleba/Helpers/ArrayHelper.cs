using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_13_SashinaoDavaleba.Helpers
{
    internal class ArrayHelper
    {
        public static void PrintArray<T>(T[] collection)
        {
            for (int i = collection.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(collection[i]);
                
            }
        }




        public static void GetFirstElement<T>(T[] collection)
        {
            Console.WriteLine(collection[0]);
        }



        public static void GetLastElement<T>(T[] collection)
        {
            Console.WriteLine(collection[collection.Length - 1]);
        }


        public static bool ContainsElement<T>(T[] collection, T el)
        {

            foreach (var item in collection)
            {
                if(item.Equals(el))
                {
                    return true;
                }
                
            }
            return false;

        }


        public static void CountElements<T>(T[] collecion)
        {
            int count = 0;

            for (int i = 0; i < collecion.Length; i++)
            {
                count++;
  
            }
            Console.WriteLine(count);
        }



        public static int FindIndex<T>(T[] collection, T el)
        {
        

            for (int i = 0; i < collection.Length; i++)
            {
                if (collection[i].Equals(el))
                {
                    return i;
                }
                
            }
            return -1;

        }


        public static void Swap<T>(T[] collection, int i1, int i2)
        {
            T temp = collection[i1];
            collection[i1] = collection[i2];
            collection[i2] = temp;


            foreach (var item in collection)
            {
                Console.WriteLine(item);

            }
        
        }




    }
}
