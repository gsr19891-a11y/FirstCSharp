using Practiculi.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Practiculi.Models
{
    internal abstract class Person
    {

        private int _age;
        private string _email;




        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age
        {
            get => _age;
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new InvalidAgeException();
                }
                _age = value;

            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (!value.Contains("@"))
                {
                    throw new InvalidEmailException("email must contain @");
                }

                if (!Regex.IsMatch(value, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
                {
                    throw new InvalidEmailException();

                }

                _email = value;
            }
        }

        public string Number { get; set; }























    }
}
