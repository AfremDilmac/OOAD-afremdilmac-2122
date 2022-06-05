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
            lblResidencyId.Text = "";
            lblEndDate.Text = "";
            lblStartDate.Text = "";
            lblPetId.Text = "";
            lblPackageId.Text = "";
            lblRemarks.Text = "";
            lblStatus.Text = "";
            

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
            lblResidencyId.Text = Convert.ToString(residency.Id);
            lblEndDate.Text = Convert.ToString(residency.EndDate);
            lblStartDate.Text = Convert.ToString(residency.Startdate);
            lblPetId.Text = Convert.ToString(residency.PetId);
            lblPackageId.Text = Convert.ToString(residency.PackageId);
            lblRemarks.Text = Convert.ToString(residency.Remarks);
            lblStatus.Text = Convert.ToString(residency.Status);
            
        }

        private void lblStatus_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnUpdateStatus_Click(object sender, RoutedEventArgs e)
        {
            verblijven.Id = Convert.ToInt32(lblResidencyId.Text);
            verblijven.Startdate = Convert.ToDateTime(lblStartDate.Text);
            verblijven.EndDate = Convert.ToDateTime(lblEndDate.Text);
            verblijven.Remarks = lblRemarks.Text;
            verblijven.PackageId = Convert.ToInt32(lblPackageId.Text);
            verblijven.PetId = Convert.ToInt32(lblPetId.Text);
            verblijven.Status = Convert.ToInt32(lblStatus.Text);
            verblijven.Update();
        }
    }
}
