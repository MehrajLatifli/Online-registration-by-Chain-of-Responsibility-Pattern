using Online_registration_by_CoR.Chain_of_Responsibility_Desigin_Pattern;
using Online_registration_by_CoR.Command;
using Online_registration_by_CoR.Models;
using Online_registration_by_CoR.Views.User_control;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Online_registration_by_CoR.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public MainWindow MainWindows { get; set; }
        SingInViewModel_UC SingInViewModel_UCs { get; set; }
        SingUpViewModel_UC SingUpViewModel_UCs { get; set; }
        OrderViewModel_UC OrderViewModel_UCs { get; set; }


        private User _user;

        public User User { get { return _user; } set { _user = value; OnpropertyChanged(); } }

        SingIn_UC singIn_UCs { get; set; }

        SingUp_UC singUp_UCs { get; set; }
        Order_UC order_UC { get;set; }


        public ICommand GotoSingIn_Command { get; set; }
        public ICommand GotoSingUp_Command { get; set; }
        public ICommand GotoOrder_Command { get; set; }


        private object selectedSingInViewModel;
        private object selectedSingUpViewModel;
        private object selectedOrderViewModel;

        public object SelectedSingInViewModel
        {
            get { return selectedSingInViewModel; }
            set
            {
                selectedSingInViewModel = value;
                OnpropertyChanged(nameof(SelectedSingInViewModel));
            }
        }

        public object SelectedSingUpViewModel
        {
            get { return selectedSingUpViewModel; }
            set
            {
                selectedSingUpViewModel = value;
                OnpropertyChanged(nameof(SelectedSingUpViewModel));
            }
        }

        public object SelectedOrderViewModel
        {
            get { return selectedOrderViewModel; }
            set
            {
                selectedOrderViewModel = value;
                OnpropertyChanged(nameof(SelectedOrderViewModel));
            }
        }


        private void NavigateTo_SingIn(object obj)
        {
            MainWindows.UserDockPanel.Visibility = Visibility.Hidden;

            SelectedSingInViewModel = new SingInViewModel_UC();

            MainWindows.SingIn_ContentControl.Visibility = Visibility.Visible;
            MainWindows.SingUp_ContentControl.Visibility = Visibility.Hidden;
            MainWindows.Order_ContentControl.Visibility = Visibility.Hidden;




    

        }
        private void NavigateTo_SingUp(object obj)
        {
            //string stepofchain = "SingUp Chain";

            //IChain chain = new SingUp_Chain();
            //IChain chain2 = new SingIn_Chain();
            //IChain chain3 = new Order_Chain();

            //chain.SetNextChain(chain2);
            //chain2.SetNextChain(chain3);

            //User U = new User(stepofchain);
            //chain.User_if_else(U);

            MainWindows.UserDockPanel.Visibility = Visibility.Hidden;

            SelectedSingUpViewModel = new SingUpViewModel_UC();

            MainWindows.SingUp_ContentControl.Visibility = Visibility.Visible;
            MainWindows.SingIn_ContentControl.Visibility = Visibility.Hidden;
            MainWindows.Order_ContentControl.Visibility = Visibility.Hidden;


            //SingUpViewModel_UCs.SingUp_UCs.NameTBox.IsEnabled = false;

        }

        private void NavigateTo_Order(object obj)
        {
            MainWindows.UserDockPanel.Visibility = Visibility.Hidden;

            SelectedOrderViewModel = new OrderViewModel_UC();

            MainWindows.Order_ContentControl.Visibility = Visibility.Visible;
            MainWindows.SingUp_ContentControl.Visibility = Visibility.Hidden;
            MainWindows.SingIn_ContentControl.Visibility = Visibility.Hidden;



 


        }



        public MainViewModel()
        {
            if (!File.Exists($"../../User.json"))
            {
                File.Create($"../../User.json").Close();
            }

        
                File.Delete($"../../Order.json");
            


            // MainWindows = new MainWindow();
            GotoSingIn_Command = new RelayCommand(NavigateTo_SingIn);
            GotoSingUp_Command = new RelayCommand(NavigateTo_SingUp);
            GotoOrder_Command = new RelayCommand(NavigateTo_Order);
        }

    }
}
