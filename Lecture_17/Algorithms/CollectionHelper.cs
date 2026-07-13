using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_17.Algorithms
{
    internal class CollectionHelper
    {

        public static T CustomFindFirst<T>(List<T> collection, T searchFor)
        {
            foreach (var item in collection)
            {
                if (item.Equals(searchFor))
                {
                    return item;
                }

                
            }
            return default;

        }


        //{50,60,70}      60


        public static T CustomFirst<T>(List<T> collection, T searchFor)
        {
            foreach (var item in collection)
            {
                if (item.Equals(searchFor))
                {
                    return item;
                }


            }
           throw new NotImplementedException();

        }


















    }
}
