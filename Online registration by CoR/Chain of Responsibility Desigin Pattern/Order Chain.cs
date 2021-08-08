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
    class Order_Chain : IChain
    {
        public IChain NextChain { get; set; }

        public void SetNextChain(IChain chain)
        {
            NextChain = chain;
        }

        public void User_if_else(User user)
        {

            string data = File.ReadAllText($"../../User.json");

            if (user.StepsofChain == "Order Chain" && !string.IsNullOrEmpty(user.Name) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.EmailComfirm) && data.Length > 0)
            {

                NextChain.User_if_else(user);

            }

            else 
            { 
                //  NextChain.User_if_else(user);
                MessageBox.Show($"Can not order", "Third Chain", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
