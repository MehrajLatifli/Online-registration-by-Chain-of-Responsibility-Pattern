using Online_registration_by_CoR.Models;
using Online_registration_by_CoR.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_registration_by_CoR.Chain_of_Responsibility_Desigin_Pattern
{
    class SingUp_Chain : IChain
    {
        public IChain NextChain { get ; set ; }


        public void SetNextChain(IChain chain)
        {
            NextChain = chain;
        }

        public void User_if_else(User user)
        {
                string data = File.ReadAllText($"../../User.json");
            if (user.StepsofChain == "SingUp Chain" && user.Name != string.Empty && user.Surname != string.Empty && user.Password != string.Empty && user.Email != string.Empty && user.EmailComfirm != string.Empty && data.Length > 0)
            {

             
                    NextChain.User_if_else(user);
                
            }

            if(user.StepsofChain == "SingUp Chain" && ( user.Name == string.Empty || user.Surname == string.Empty || user.Password == string.Empty || user.Email == string.Empty || user.EmailComfirm == string.Empty || data.Length < 0))
            {
              //  NextChain.User_if_else(user);
                MessageBox.Show($"Can not sing up","First Chain", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
