using Newtonsoft.Json;
using Online_registration_by_CoR.Chain_of_Responsibility_Desigin_Pattern;
using Online_registration_by_CoR.Command;
using Online_registration_by_CoR.Models;
using Online_registration_by_CoR.Repo;
using Online_registration_by_CoR.Views.User_control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_registration_by_CoR.ViewModels
{
    public class OrderViewModel_UC : BaseViewModel
    {
        public Order_UC Order_UCs { get; set; }
       // public SingIn_UC SingIn_UCs { get; set; }

        public SingInViewModel_UC SingInViewModel_UCs { get; set; }
        public ObservableCollection<User> _User_List { get; set; }
        public ObservableCollection<User> User_List { get { return _User_List; } set { _User_List = value; } }

        public ObservableCollection<User> new_User_List = new ObservableCollection<User>();

        private User _User;

        public User User { get { return _User; } set { _User = value; } }
        public ObservableCollection<Products> _Products_List { get; set; }
        public ObservableCollection<Products> Products_List { get { return _Products_List; } set { _Products_List = value; } }

        public ObservableCollection<Products> new_Products_List = new ObservableCollection<Products>();

        private Products _product;

        public Products Product { get { return _product; } set { _product = value;  } }


        public ObservableCollection<Order> _Order_List { get; set; }
        public ObservableCollection<Order> Order_List { get { return _Order_List; } set { _Order_List = value; } }

        public ObservableCollection<Order> new_Order_List = new ObservableCollection<Order>();

        private Order _Order;

        public Order Order { get { return _Order; } set { _Order = value; } }

        public FakeRepo ProductRepository { get; set; }

        string stepofchain = "Order Chain";




        public RelayCommand SelectedItemChangedCommand { get; set; }

        public SingUpViewModel_UC SingUpViewModel_UCs { get; set; }


        public OrderViewModel_UC()
        {
            Order_UCs = new Order_UC();
            //    SingIn_UCs = new SingIn_UC();
            User_List = new ObservableCollection<User>();

            SingInViewModel_UCs = new SingInViewModel_UC();

            Product = new Products
            {
                Name = "Product",
                Weight = 0,
                Price = 0,
                ImagePath = "../Images/DefaultImage.png",
                Quantity = 0,
                Sum = 0,
            };

            ProductRepository = new FakeRepo();
            Products_List = new ObservableCollection<Products>(ProductRepository.GetAll());


            SelectedItemChangedCommand = new RelayCommand((e) =>
            {
                var SingUp_UC = new SingUp_UC();
                SingUpViewModel_UCs = new SingUpViewModel_UC();
                SingUpViewModel_UCs.User = User;
                SingUpViewModel_UCs.SingUp_UCs = SingUp_UC;
                User = new User();

                User_List = DeserializeUser();

                Order_List = Deserialize();


                if (File.Exists($"../../Order.json"))
                {
                    new_Order_List.Add(new Order()
                    {
                        Name = Products_List[Order_UCs.listbox1.SelectedIndex].Name,
                        Price = Products_List[Order_UCs.listbox1.SelectedIndex].Price,
                        Weight = Products_List[Order_UCs.listbox1.SelectedIndex].Weight,
                        Quantity = Products_List[Order_UCs.listbox1.SelectedIndex].Quantity,
                        Sum = Products_List[Order_UCs.listbox1.SelectedIndex].Sum,
                        ImagePath = Products_List[Order_UCs.listbox1.SelectedIndex].ImagePath,

                    });

                    Serialize(new_Order_List);

                    Process.Start("notepad.exe", $"../../Order.json");
                }




                if (!User_List.Any())
                {
                    IChain chain = new SingUp_Chain();
                    IChain chain2 = new SingIn_Chain();
                    IChain chain3 = new Order_Chain();

                    chain.SetNextChain(chain2);
                    chain2.SetNextChain(chain3);

                    User User = new User(SingUp_UC.NameTBox.Text, SingUp_UC.PasswordTBox.Text, stepofchain);
                    chain3.User_if_else(User);

                }

                if (!File.Exists($"../../Order.json"))
                {
                    IChain chain = new SingUp_Chain();
                    IChain chain2 = new SingIn_Chain();
                    IChain chain3 = new Order_Chain();

                    chain.SetNextChain(chain2);
                    chain2.SetNextChain(chain3);

                    User User = new User(SingUp_UC.NameTBox.Text, SingUp_UC.PasswordTBox.Text, stepofchain);
                    chain3.User_if_else(User);
                }

         

            });
        }

        public ObservableCollection<User> DeserializeUser()
        {


            string data = File.ReadAllText($"../../User.json");

            User_List = JsonConvert.DeserializeObject<ObservableCollection<User>>(data);

            if (User_List != null)
            {
                return User_List;
            }



            return new ObservableCollection<User>();
        }

        private void SerializeUser(ObservableCollection<User> usernData)
        {
            if (!File.Exists($"../../User.json"))
            {
                File.Create($"../../User.json").Close();
            }

            var f = Newtonsoft.Json.Formatting.Indented;
            string data = JsonConvert.SerializeObject(usernData, f);

            File.WriteAllText($"../../User.json", data);
        }

        public ObservableCollection<Order> Deserialize()
        {

            if (File.Exists($"../../Order.json"))
            {
                string data = File.ReadAllText($"../../Order.json");

                Order_List = JsonConvert.DeserializeObject<ObservableCollection<Order>>(data);

                if (Order_List != null)
                {
                    return Order_List;
                }

            }


            return new ObservableCollection<Order>();
        }

        private void Serialize(ObservableCollection<Order> orderData)
        {

            if (File.Exists($"../../Order.json"))
            {
                if (!File.Exists($"../../Order.json"))
                {
                    File.Create($"../../Order.json").Close();
                }

                var f = Newtonsoft.Json.Formatting.Indented;
                string data = JsonConvert.SerializeObject(orderData, f);

                File.WriteAllText($"../../Order.json", data);
            }
        }
    }
}
