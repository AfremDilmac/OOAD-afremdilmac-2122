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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAdmin
{
    /// <summary>
    /// Logique d'interaction pour CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Page
    {
        User user = new User();
        MainWindow md = new MainWindow();
        public CreateUser(MainWindow dashboard)
        {
            InitializeComponent();
            md = dashboard;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            user.Login = txtLogin.Text;
            user.Password = txtPassword.Text;
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            if (cbxRole.SelectedIndex == 0)
            {
                user.Role = "user";
            }
            else
            {
                user.Role = "admin";
            }
            user.Id = Convert.ToInt32(txtId.Text);
            user.InsertToDb();
        }
    }
}
