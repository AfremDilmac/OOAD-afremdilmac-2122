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

namespace WpfUser
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(int userid)
        {
            InitializeComponent();
            ReloadResidency(null, userid);
        }
        private void LbxResidency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxResidency.SelectedItem;
            if (item == null) return;
            int userId = Convert.ToInt32(item.Tag);
            Residency residency = Residency.FindById(userId);
            lblEndDate.Content = residency.EndDate;
            lblStartDate.Content = residency.Startdate;
            lblPetRemarks.Content = residency.Remarks;

        }

        private void LbxPet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxPet.SelectedItem;
            if (item == null) return;
            int userId = Convert.ToInt32(item.Tag);
            Pet pet = Pet.FindById(userId);
            lblName.Content = pet.Name;
            lblPetRemarks.Content = pet.Remarks;
            lblSex.Content = pet.Sex;
            lblSize.Content = pet.Size;
            lblAge.Content = pet.Age;
        }

        public void ReloadResidency(int? selectedId, int userid) 
        {
            List<Pet> allEmps = Pet.GetAll();
            foreach (Pet emp in allEmps)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = emp.ToString();
                item.Tag = emp.Id;
                item.IsSelected = selectedId == emp.Id;
                if (emp.UserId == userid)
                {
                    lbxPet.Items.Add(item);
                }
            }

            List<Residency> allResidency = Residency.GetAll();
            foreach (Residency Residence in allResidency)
            {
                ListBoxItem item2 = new ListBoxItem();
                item2.Content = Residence.ToString();
                item2.Tag = Residence.Id;
                item2.IsSelected = selectedId == Residence.Id;
                if (Residence.Id == userid)
                {
                    lbxResidency.Items.Add(item2);
                }
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            frmShow.Content = new AanvraagResidency(this);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frmShow.CanGoBack) frmShow.NavigationService.GoBack();
        }
    }
}
