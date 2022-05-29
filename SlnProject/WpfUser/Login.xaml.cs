using MyClassLibrary;
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
using System.Windows.Shapes;

namespace WpfUser
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (User.LoginInDbUser(tbxUsername.Text, tbxPassword.Password))
            {
                string name = tbxUsername.Text;
               
                object test = User.GetId(name);
                string id = test.ToString();
                string result = id.Remove(1, 2);
                lblError.Content = result;
                int userId = Convert.ToInt32(result);
                MainWindow venster = new MainWindow(userId);
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
