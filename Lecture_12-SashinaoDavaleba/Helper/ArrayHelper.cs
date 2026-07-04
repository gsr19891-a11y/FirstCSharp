using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_12_SashinaoDavaleba.Helper
{
    internal class ArrayHelper //overloadin გადატვირთვა 
    {
        //1

        public static void PrintArray<T>(T[] collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
        //2


        //public static void PrintReverse<T>(T[] collection)
        //{
        //   Array.Reverse(collection);
        //    foreach (var item in collection)
        //    {
        //        Console.WriteLine(item);
                
        //    }
        //}

        public static void PrintReverse<T>(T[] collection)
        {
            for (int i = collection.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(collection[i]);
                
            }
        }


        //3

        public static T GetFirstElement<T>(T[] collection)
        {
            foreach (var item in collection)
            {
                return item;
            }

            return default;
        }


        //4
        public static T GetLastElement<T>(T[] collection)
        {
            if (collection.Length > 0)
            {
                return collection[collection.Length - 1];
            }
            return default;
        }



        //5

        public static bool CustomContains<T>(T[] collection, T searchFor) where T : class
        {

            //todo int

            if (typeof(T) == typeof(int))
            {
                for (int i = 0; i < collection.Length; i++)
                {
                    return collection.Contains(searchFor);
                    
                }
            }


            foreach (var item in collection)
            {
                return item.Equals(searchFor);
                
            }
            return false;
        }


     



        //public struct NumberStruct
        //{
        //    public int Value;
        //}














    }
}
