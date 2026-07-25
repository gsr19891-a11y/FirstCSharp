using L23.Core.Interfaces;
using L23.Core.Models;
using L23.Infastructure.Repositories;
using L23.Services;

namespace L23.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IUserRepository userRepository = new UserRepository();
            UserService userService = new UserService(userRepository);



            //create user

            //User user = new User();
            //user.Name = "Giorgi";
            //user.Email = "gsr19891@gmail.com";
            //user.Role = Core.Enums.UserRole.Admin;
            //user.Password = "1234";
            //user.Id = 1;

            //userService.UserRegister(user);




            //verify
            Console.WriteLine("Enter Email for verify:");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Code:");
            string verificationCode = Console.ReadLine();

            userService.UserVerify(email, verificationCode);


      

         

        }
    }
}

