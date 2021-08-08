using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Online_registration_by_CoR.Models
{
    public class User 
    {

        public User()
        {

        }

        public User(string name, string surname, string password, string password_2, string email, string stepsofChain)
        {
            Name = name;
            Surname = surname;
            Password = password;
            EmailComfirm = password_2;
            Email = email;
            StepsofChain = stepsofChain;
        }

        public User(string stepsofChain)
        {
            StepsofChain = stepsofChain;
        }

        public User(string name, string stepsofChain, string password)
        {
            Name = name;
            StepsofChain = stepsofChain;
            Password = password;
        }

        public string Name { get; set; }
        public string StepsofChain { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string EmailComfirm { get; set; }
        public string Email { get; set; }



        public override string ToString()
        {
            return $"{Name} {Surname} {Email}";
        }
    }
}
