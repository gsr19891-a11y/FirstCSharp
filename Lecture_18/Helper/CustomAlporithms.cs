using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lecture_18.Helper
{

    //Func - x,y - y
    //Predicate -bool
    //Action -void
    internal static class CustomAlporithms
    {
      

        public static T CustomFirst<T>(IEnumerable<T> collection, Predicate<T> predicate) {


            foreach (var item in collection)
            {
                if (predicate(item))// x=> x>50
                {
                    return item;
                }
                
            }


            throw new NotImplementedException();
        }




        public static T CustomFirstFunc<T>(IEnumerable<T> collection, Func<T,bool> func)
        {
            foreach (var item in collection)
            {
                if (func(item))
                {
                    return item;
                }

            }


            throw new NotImplementedException();

        }
        




        public static IEnumerable<T> CustomeWere<T>(this IEnumerable<T> collection, Func<T, bool> func = null)
        {

           
            foreach (var item in collection)
            {
                if (func(item))
                {
                    yield return item;
                }
                
            }
        }




        public static void Print(this string massage)
        {
            Console.WriteLine(massage);
        }







        public static int CustomCount<T>(this IEnumerable<T> collection, Func<T, bool> func = null)
        {
            int count = 0;
            foreach (var item in collection)
            {
                if (func(item))
                {
                    count ++;     
                }
            }
            return count;      
        }









            //First
            //FirstOrDefault
            //Last
            //LastOfDefault
            //Were








        }
}
