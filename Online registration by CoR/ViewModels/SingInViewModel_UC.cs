using Newtonsoft.Json;
using Online_registration_by_CoR.Chain_of_Responsibility_Desigin_Pattern;
using Online_registration_by_CoR.Command;
using Online_registration_by_CoR.Models;
using Online_registration_by_CoR.Views.User_control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_registration_by_CoR.ViewModels
{
    public class SingInViewModel_UC : BaseViewModel
    {
        public SingIn_UC SingIn_UCs { get; set; }

        public OrderViewModel_UC OrderViewModel_UCs { get; set; }

        public Order_UC Order_UCs { get; set; }

        public bool singinclick = false;

        public ObservableCollection<User> _User_List { get; set; }
        public ObservableCollection<User> User_List { get { return _User_List; } set { _User_List = value; } }

        public ObservableCollection<User> new_User_List = new ObservableCollection<User>();


        string stepofchain = "SingIn Chain";
        public RelayCommand SingInCommand { get; set; }

        public SingInViewModel_UC()
        {
            SingIn_UCs = new SingIn_UC();

            SingInCommand = new RelayCommand((e) =>
             
             {
                 User_List = Deserialize();

                 foreach (var item in User_List)
                 {
                     if (item.Name == SingIn_UCs.NameTBox.Text && item.Password == SingIn_UCs.PasswordTBox.Text)
                     {
                         MessageBox.Show($"Welcome livE store {item.Name}");

                         singinclick = true;


                         if (!File.Exists($"../../Order.json"))
                         {
                             File.Create($"../../Order.json").Close();
                         }
                     }


                 }

                 if (!User_List.Any())
                 {

                     if (File.Exists($"../../Order.json"))
                     {
                         File.Delete($"../../Order.json");
                     }

                     IChain chain = new SingUp_Chain();
                     IChain chain2 = new SingIn_Chain();
                     IChain chain3 = new Order_Chain();

                     chain.SetNextChain(chain2);
                     chain2.SetNextChain(chain3);

                     User User = new User(SingIn_UCs.NameTBox.Text, SingIn_UCs.PasswordTBox.Text, stepofchain);
                     chain2.User_if_else(User);
                     singinclick = false;
                 }


                 if (!User_List.Any(x=>x.Name == SingIn_UCs.NameTBox.Text) || !User_List.Any(x => x.Password == SingIn_UCs.PasswordTBox.Text))
                 {
                     if (File.Exists($"../../Order.json"))
                     {
                         File.Delete($"../../Order.json");
                     }

                     IChain chain = new SingUp_Chain();
                     IChain chain2 = new SingIn_Chain();
                     IChain chain3 = new Order_Chain();

                     chain.SetNextChain(chain2);
                     chain2.SetNextChain(chain3);

                     User User = new User(SingIn_UCs.NameTBox.Text, SingIn_UCs.PasswordTBox.Text, stepofchain);
                     chain2.User_if_else(User);

                     singinclick = false;
                    
                 }
             });
        }


        public ObservableCollection<User> Deserialize()
        {


            string data = File.ReadAllText($"../../User.json");

            User_List = JsonConvert.DeserializeObject<ObservableCollection<User>>(data);

            if (User_List != null)
            {
                return User_List;
            }



            return new ObservableCollection<User>();
        }

        private void Serialize(ObservableCollection<User> usernData)
        {
            if (!File.Exists($"../../User.json"))
            {
                File.Create($"../../User.json").Close();
            }

            var f = Newtonsoft.Json.Formatting.Indented;
            string data = JsonConvert.SerializeObject(usernData, f);

            File.WriteAllText($"../../User.json", data);
        }
    }
}
