using MyClassLibrary;
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
            ReloadEmployees(null);
        }
        public void ReloadEmployees(int? selectedId)
        {
            // wis lijst en labels
            lbxResults.Items.Clear();
            lblEmail.Content = "";
            lblGender.Content = "";
            lblBirthdate.Content = "";
            lblCode.Content = "";

            // laad alle werknemers in
            List<User> allEmps = User.GetAll();
            foreach (User emp in allEmps)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = emp.ToString();
                item.Tag = emp.Id;
                item.IsSelected = selectedId == emp.Id;
                lbxResults.Items.Add(item);
            }
        }

        //private void btnLogin_Click(object sender, RoutedEventArgs e)
        //{
        //    if (User.LoginInDb(txtLogin.Text, txtPaswoord.Password) == true)
        //    {
        //        lblError.Content = "User bestaat";
        //    }
        //    else {
        //        lblError.Content = "De ID en/of paswoord is niet correct";
        //    }

        //}

        private void LbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // stel button states in
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            if (item == null) return;

            // als een werknemer geselecteerd is, vraag details op
            int employeeId = Convert.ToInt32(item.Tag);
            User emp = User.FindById(employeeId);
            lblEmail.Content = emp.FirstName;
            string gender = emp.LastName;
            lblGender.Content = gender;
            lblBirthdate.Content = emp.Role;
            lblCode.Content = emp.Password;
        }
    }
}

