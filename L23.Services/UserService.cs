using L23.Core.Interfaces;
using L23.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace L23.Services
{
    public class UserService
    {

        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        //UserRegister----------------------------
        public void UserRegister(User user)
        {
            var users = _userRepository.GetUsers();

            if (!user.Email.Contains("@"))
            {
                throw new Exception("Invalid Email!");
            }

            int idCounter;
            if (users.Count == 0)
            {
                idCounter = 0;
            }
            else
            {

                idCounter = users.Max(x => x.Id);
            }

            user.Id = idCounter + 1;

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            Random rand = new Random();
            user.VerificationCode = rand.Next(1000, 9999).ToString();

            L23EmailService.SendEmail(user.Email, "Verification Message", $"Your Verification Code: {user.VerificationCode}");

            _userRepository.SaveUser(user);


        }

        //Login-------------------------------------------

        public void UserLogin(string email, string password)
        {
            User user = _userRepository.GetUserByEmail(email);

            if (user == null) {
                throw new Exception("Invalid Email");
            }
            if(!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exception("Invalid Password");
            }
            if(user.IsVerfyed == false)
            {
                throw new Exception("Verify your account!");
            }

            Console.WriteLine("Welcome!");

        }



        //VerifyAccount-----------------------------------------

        public void UserVerify(string email, string verificationCode) {

            User user = _userRepository.GetUserByEmail(email);

            if (user == null) {
                throw new Exception("Invalid Email");
            }


            if (user.VerificationCode != verificationCode)
            {
                throw new ArgumentException("Invalid verification code ");
            }

            Console.WriteLine("Verification succsessful");
            user.IsVerfyed = true;

            UserUpdate(user);
          
        }




        //User Update ------------------------------------------

        public void UserUpdate(User user)
        {
            if (!user.Email.Contains("@"))
            {
                throw new Exception("Invalid Email!");
            }

            _userRepository.UpdateUser(user);
        }




        //Delete User -----------------------------------------

        public void DeleteUser(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid Id!");
            }
            _userRepository.DeleteUser(id);
        }




    }
}




