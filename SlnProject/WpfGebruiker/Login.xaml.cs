﻿using MyClassLibrary;
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

namespace WpfGebruiker
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (User.LoginInDbUser(tbxUsername.Text, tbxPassword.Password))
            {
                MainWindow venster = new MainWindow();
                this.Close();
                venster.Show();
            }
            else
            {
                lblError.Content = "De ID en/of paswoord is niet correct";
            }
        }
    }
}