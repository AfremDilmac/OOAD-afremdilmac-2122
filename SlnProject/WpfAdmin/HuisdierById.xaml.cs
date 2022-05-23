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
using MyClassLibrary;

namespace WpfAdmin
{
    /// <summary>
    /// Logique d'interaction pour HuisdierById.xaml
    /// </summary>
    public partial class HuisdierById : Page
    {
        User user = new User();
        int userid;
        Pet pet = new Pet();
        MainWindow md = new MainWindow();
        int petid;
        public HuisdierById(MainWindow dashboard, int userid)
        {
            InitializeComponent();
            ReloadUsers(null, userid);
        }
        public void ReloadUsers(int? selectedId, int userid)
        {
            user = User.FindById(userid);
            lblId.Content = "";
            lblName.Content = "";
            lblRemark.Content = "";
            lblSex.Content = "";
            lblSize.Content = "";
            lblAge.Content = "";
            lblUserId.Content = "";

            List<Pet> allEmps = Pet.GetAll();
            foreach (Pet emp in allEmps)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = emp.ToString();
                item.Tag = emp.Id;
                item.IsSelected = selectedId == emp.Id;
                if (emp.UserId == userid)
                {
                    lbxResults.Items.Add(item);
                }
            }
        }
        private void LbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            if (item == null) return;
            int userId = Convert.ToInt32(item.Tag);
            Pet pet = Pet.FindById(userId);
            lblId.Content = pet.Id;
            lblName.Content = pet.Name;
            lblRemark.Content = pet.Remarks;
            lblAge.Content = pet.Age;
            lblSex.Content = pet.Sex;
            lblSize.Content = pet.Size;
            lblUserId.Content = pet.UserId;
            lblType.Content = pet.TypeName;
            
        }
    }
}
