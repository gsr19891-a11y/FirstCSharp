using Lecture_18_SashinaoDavaleba.User;

namespace Lecture_18_SashinaoDavaleba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserClass user = new UserClass();

            UserClass user1 = new UserClass();

            user.Age = 19;
            user.FirstName = "Test";

            user1.Age = 2;
            user1.FirstName = "Test2";



           List<UserClass> users = new List<UserClass>() { user, user1};

           List<UserClass> adult = UserClass.GetUsersOlderThan(users, 18);

            foreach (var item in adult)
            {
                Console.WriteLine(item);
            }



        }




     



    }
}
