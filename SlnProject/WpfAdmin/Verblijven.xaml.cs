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
    /// Logique d'interaction pour Verblijven.xaml
    /// </summary>
    public partial class Verblijven : Page
    {
        Residency verblijven = new Residency();
        MainWindow md = new MainWindow();
        public Verblijven(MainWindow dashboard)
        {
            InitializeComponent();
            ReloadUsers(null);
            md = dashboard;
        }
        public void ReloadUsers(int? selectedId)
        {
            lblResidencyId.Content = "";
            lblEndDate.Content = "";
            lblStartDate.Content = "";
            lblPetId.Content = "";
            lblPackageId.Content = "";
            lblRemarks.Content = "";
            lblStatus.Content = "";
            

            List<Residency> allEmps = Residency.GetAll();
            foreach (Residency emp in allEmps)
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
            if (item == null) return;
            int userId = Convert.ToInt32(item.Tag);
            Residency residency = Residency.FindById(userId);
            lblResidencyId.Content = residency.Id;
            lblEndDate.Content = residency.EndDate;
            lblStartDate.Content = residency.Startdate;
            lblPetId.Content = residency.PetId;
            lblPackageId.Content = residency.PackageId;
            lblRemarks.Content = residency.Remarks;
            lblStatus.Content = residency.Status;
            
        }
    }
}
