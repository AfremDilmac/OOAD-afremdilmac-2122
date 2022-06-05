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
            btnNew.IsEnabled = false;
        }
        private void LbxResidency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void LbxPet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbxResidency.Items.Clear();

            btnNew.IsEnabled = true;
            ListBoxItem item = (ListBoxItem)lbxPet.SelectedItem;
            if (item == null) return;
            int userId = Convert.ToInt32(item.Tag);
            Pet pet = Pet.FindById(userId);
            lblName.Content = pet.Name;
            lblPetRemarks.Content = pet.Remarks;
            lblSex.Content = pet.Sex;
            lblSize.Content = pet.Size;
            lblAge.Content = pet.Age;

            List<Residency> allResidency = Residency.GetAllResidence(userId);
            foreach (Residency Residence in allResidency)
            {
                ListBoxItem item2 = new ListBoxItem();
                item2.Content = Residence.ToString();
                if (Residence.PetId == pet.Id)
                {
                    lbxResidency.Items.Add(item2);
                }
            }

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

            
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxPet.SelectedItem;
            int id = Convert.ToInt32(item.Tag);
            string petType= Convert.ToString(item.Content);
            frmShow.Content = new AanvraagResidency(this, id, petType);
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (frmShow.CanGoBack) frmShow.NavigationService.GoBack();
        }

        private void frmShow_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}
