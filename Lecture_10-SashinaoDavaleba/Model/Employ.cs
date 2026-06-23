using Lecture_10_SashinaoDavaleba.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_10_SashinaoDavaleba.Model
{
    internal class Employ
    {

        public Employ(string name, string surname, DateTime dateofbirth, Country country, Gender gender, string phonenumber, string email, string fax)
        {
            Name = name;
            Surname = surname;
            Dateifbirth = dateofbirth;
            Country = country;
            Gender = gender;
            PhoneNumber = phonenumber;
            Email = email;
            Fax = fax;

        }

        public Employ()
        {
        }

        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Dateifbirth { get; set; }

        public Country Country { get; set; }

        public Gender Gender { get; set; }





        public string Fax { get; set; }


        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (value.Length != 8)
                {
                    return;
                }
                _phoneNumber = value;
            }
        }


        public int CalculateAge(DateTime date)
        {
            DateTime today = DateTime.Today;

            int age = today.Year - date.Year;

            if (date.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }


        private string _email;


        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Contains("@"))
                {
                    _email = value;
                }
                else
                {
                    Console.WriteLine($"{value} - Invalid Email!");

                }



            }
        }

   
        public static void FindCountry(Country searchCountry, Employ[] employs)
        {
            foreach (var emp in employs)
            {
                if (emp.Country == searchCountry)
                {
                    Console.WriteLine($"{emp.Name} {emp.Surname} - {emp.Country}");
                }
            }
        }
    }
    }
