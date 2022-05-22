﻿using MyClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace WpfAdmin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connString = ConfigurationManager.AppSettings["connString"];
        public MainWindow()
        {
            InitializeComponent();
            ReloadUsers(null);
        }
        public void ReloadUsers(int? selectedId)
        {
            // wis lijst en labels
            lbxResults.Items.Clear();
            lblId.Content = "";
            lblFirstName.Content = "";
            lblLastName.Content = "";
            lblDate.Content = "";
            lblRole.Content = "";
            lblLogin.Content = "";
            lblPassword.Content = "";

            // laad alle werknemers in
            List<User> allEmps = User.GetAllClients();
            foreach (User emp in allEmps)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = emp.ToString();
                item.Tag = emp.Id;
                item.IsSelected = selectedId == emp.Id;
                lbxResults.Items.Add(item);
            }
        }

        private void LbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            btnEdit.IsEnabled = item != null;
            btnRemove.IsEnabled = item != null;
            if (item == null) return;
          
            int userId = Convert.ToInt32(item.Tag);
            User user = User.FindById(userId);
            lblId.Content = user.Id;
            lblFirstName.Content = user.FirstName;
            lblLastName.Content = user.LastName;
            lblDate.Content = user.CreateDate;
            lblRole.Content = user.Role;
            lblLogin.Content = user.Login;
            lblPassword.Content = user.Password;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            int userId = Convert.ToInt32(item.Tag);
            frmShow.Content = new EditUser(this, userId);
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            if (item == null) return;
            int userId = Convert.ToInt32(item.Tag);
            User user = User.FindById(userId);
            MessageBoxResult result = MessageBox.Show($"Do you want to delete this user: {user.FirstName}", "Delete", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;
            user.DeleteFromDb();
            ReloadUsers(null);
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

