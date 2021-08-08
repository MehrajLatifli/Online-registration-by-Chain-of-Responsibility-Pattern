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
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_registration_by_CoR.ViewModels
{
    public class SingUpViewModel_UC : BaseViewModel
    {
        public SingUp_UC SingUp_UCs { get; set; }

        public OrderViewModel_UC OrderViewModel_UCs { get; set; }

        public Order_UC Order_UCs { get; set; }

        public ObservableCollection<User> _User_List { get; set; }
        public ObservableCollection<User> User_List { get { return _User_List; } set { _User_List = value;  } }

        public ObservableCollection<User> new_User_List = new ObservableCollection<User>();

        private User _User;

        public User User { get { return _User; } set { _User = value; } }

        //private User _user;

        //public User User { get { return _user; } set { _user = value; OnpropertyChanged(); } }


        public RelayCommand SingUpComplateCommand { get; set; }
        public RelayCommand GetCodeCommand { get; set; }

       // SingUpViewModel_UC SingUpViewModel_UCs { get; set; }



        public string[] code= new string[11];

        public bool singupclick = false;
        public SingUpViewModel_UC()
        {
             SingUp_UCs = new SingUp_UC();

            string stepofchain = "SingUp Chain";

    

            GetCodeCommand = new RelayCommand((e) =>
            {

                code = new string[] { "11kv11", "39wk56", "10kg91", "44rt91","81kv65", "59wk42", "79kg82", "94rt59","64OP49","23IL40" };

                Random r1 = new Random();
                int n = code.Length;


                while (n > 1)
                {
                    n--;
                    int k = r1.Next(n + 1);
                    string value = code[k];
                    code[k] = code[n];
                    code[n] = value;
                }


                if (SingUp_UCs.EmailTBox.Text.Contains("@"))
                {
                    string mailBodyhtml =
               $"<h1 style=\"color: #EB0008;\"> Your code: {code[0]}</h1> <h1 style=\"color: #42A1D7;\"> User Name: {SingUp_UCs.NameTBox.Text}</h1> <h2 style=\"color: #42A1D7;\"> Surname: {SingUp_UCs.SurnameTBox.Text}</h2>";
                    var msg = new MailMessage("testtext24@yandex.com", SingUp_UCs.EmailTBox.Text, "livE", mailBodyhtml);
                    msg.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient($"smtp.yandex.com", 587);
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential("testtext24@yandex.com", "210193M");
                    smtpClient.EnableSsl = true;

                    try
                    {
                        smtpClient.Send(msg);

                        SingUp_UCs.EmailConfirmTBox.IsEnabled = true;

                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"<h1 style=\"color: #42A1D7;\">  An error occurred while sending your message. ");


                    }


                }


            });


            SingUpComplateCommand = new RelayCommand((e) =>
            {

                OrderViewModel_UCs = new OrderViewModel_UC();

                if (code[0] == SingUp_UCs.EmailConfirmTBox.Text && SingUp_UCs.EmailTBox.Text.Contains("@"))
                {


                    User_List = Deserialize();

                    new_User_List.Add(new User(SingUp_UCs.NameTBox.Text, SingUp_UCs.SurnameTBox.Text, SingUp_UCs.PasswordTBox.Text, SingUp_UCs.EmailTBox.Text, SingUp_UCs.EmailConfirmTBox.Text, stepofchain)
                    {
                        Name = SingUp_UCs.NameTBox.Text,
                        Surname = SingUp_UCs.SurnameTBox.Text,
                        Password = SingUp_UCs.PasswordTBox.Text,
                        Email = SingUp_UCs.EmailTBox.Text,
                        EmailComfirm = SingUp_UCs.EmailConfirmTBox.Text,
                        StepsofChain = stepofchain,

                    });


                    OrderViewModel_UCs.User_List.Add(User);

                    Serialize(new_User_List);

                    singupclick = true;

                }

                if(code[0]!= SingUp_UCs.EmailConfirmTBox.Text || !SingUp_UCs.EmailTBox.Text.Contains("@"))
                {
                    IChain chain = new SingUp_Chain();
                    IChain chain2 = new SingIn_Chain();
                    IChain chain3 = new Order_Chain();

                    chain.SetNextChain(chain2);
                    chain2.SetNextChain(chain3);

                    User User = new User(SingUp_UCs.NameTBox.Text, SingUp_UCs.SurnameTBox.Text, SingUp_UCs.PasswordTBox.Text, SingUp_UCs.EmailTBox.Text, SingUp_UCs.EmailConfirmTBox.Text, stepofchain);
                    chain.User_if_else(User);
                }


              //  chain.SetNextChain(this, SingInViewModel_UCs, OrderViewModel_UCs);

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
