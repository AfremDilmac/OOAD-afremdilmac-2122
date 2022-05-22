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
    /// Logique d'interaction pour EditUser.xaml
    /// </summary>
    public partial class EditUser : Page
    {
        User user = new User();
        MainWindow md = new MainWindow();
        int userid;
        public EditUser(MainWindow dashboard, int id)
        {
            InitializeComponent();
            this.md = dashboard;
            userid = id;
            user = User.FindById(userid);
            txtLogin.Text = user.Login;
            txtPassword.Text = user.Password;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtRole.Text = user.Role;
            md.ReloadUsers(null);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            user.Login = txtLogin.Text;
            user.Password = txtPassword.Text;
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Role = txtRole.Text;
            user.UpdateUser();
            
        }
    }
}
