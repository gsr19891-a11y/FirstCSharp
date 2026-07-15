using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_18_SashinaoDavaleba.User
{
    internal class UserClass : IComparable<UserClass>
    {
        public string FirstName { get; set; }
        public int Age { get; set; }



        public int CompareTo(UserClass? other)
        {
            return this.Age.CompareTo(other?.Age ?? 0);
        }


        public static List<UserClass> GetUsersOlderThan(List<UserClass> users, int minAge)
        {
            return users.Where(u => u.Age > minAge).ToList();
        }


        public static List<UserClass> SortUsersByAge(List<UserClass> users)
        {
            return users.OrderBy(u => u.Age).ToList();
        }

        public static UserClass GetFirstUserWithLetterOrThrow(List<UserClass> users, char letter)
        {
            return users.First(u => u.FirstName.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        public static UserClass? FindUserByName(List<UserClass> users, string name)
        {
            return users.FirstOrDefault(u => u.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static UserClass GetTheOnlyUserWithAge(List<UserClass> users, int age)
        {
            return users.Single(u => u.Age == age);
        }

        
        public static UserClass? FindUniqueUserByName(List<UserClass> users, string name)
        {
            return users.SingleOrDefault(u => u.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }


        public static bool HasUnderageUsers(List<UserClass> users)
        {
            return users.Any(u => u.Age < 18);
        }

        
        public static bool AreAllUsersOlderThan(List<UserClass> users, int limitAge)
        {
            return users.All(u => u.Age > limitAge);
        }

      
        public static int GetUsersWithLongNamesCount(List<UserClass> users)
        {
            return users.Count(u => u.FirstName.Length > 5);
        }

     
        public static List<int> GetUniqueAges(List<UserClass> users)
        {
            return users.Select(u => u.Age).Distinct().ToList();
        }

        public override string? ToString()
        {
            return $"Name: {FirstName}, Age: {Age}";
        }
    }
}
