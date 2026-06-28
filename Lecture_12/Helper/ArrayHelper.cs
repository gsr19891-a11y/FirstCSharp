using Lecture_12.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_12.Helper
{

    //generic - ზოგადი


    internal class ArrayHelper
    {


        public static void PrintArray<T>(T[] collection)
        {

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }



        //public static void PrintArray(int[] ints) {

        //    foreach (var item in ints)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}


        //public static void PrintArray(string[] ints)
        //{

        //    foreach (var item in ints)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}



        //public static void PrintArray(Student[] students)
        //{

        //    foreach (var item in students)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}



    }
}
