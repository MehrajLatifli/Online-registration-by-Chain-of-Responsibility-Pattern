using Online_registration_by_CoR.Models;
using Online_registration_by_CoR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_registration_by_CoR.Chain_of_Responsibility_Desigin_Pattern
{
    interface IChain
    {
        IChain NextChain { get; set; }
        void SetNextChain(IChain chain);

        void User_if_else(User user);
    }
}
