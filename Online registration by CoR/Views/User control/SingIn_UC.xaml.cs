﻿using Online_registration_by_CoR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Online_registration_by_CoR.Views.User_control
{
    /// <summary>
    /// Interaction logic for SingIn_UC.xaml
    /// </summary>
    public partial class SingIn_UC : UserControl
    {
        public SingIn_UC()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = new SingInViewModel_UC() { SingIn_UCs = this };
        }
    }
}
