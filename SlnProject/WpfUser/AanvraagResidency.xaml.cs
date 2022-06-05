using MyClassLibrary;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace WpfUser
{
    /// <summary>
    /// Logique d'interaction pour AanvraagResidency.xaml
    /// </summary>
    public partial class AanvraagResidency : Page
    {
        Residency residence = new Residency();
        Pet pet = new Pet();
        Package package = new Package();
        Option option = new Option();
        string pettype;

        public AanvraagResidency(MainWindow dashboard,int userid, string pettype)
        {
            InitializeComponent();
            ReloadPackage(null, userid,pettype);

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;

            if (item == null) return;

            int packageId = Convert.ToInt32(item.Tag);
            Package package = Package.FindById(packageId);

            residence.Startdate = dateStart.SelectedDate;
            residence.EndDate = dateEnd.SelectedDate;
            residence.Remarks = tbxRemarks.Text;
            residence.PackageId = package.Id;
            residence.PetId = pet.Id;
            residence.Status = 0;
            residence.InsertToDb();
        }

        private void LbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListBoxItem item = (ListBoxItem)lbxResults.SelectedItem;
            
            if (item == null) return;

            int packageId = Convert.ToInt32(item.Tag);
            Package package = Package.FindById(packageId);
            lblPackagePrice.Content = package.PricePerDay;
            lblPackageName.Content = package.Name;

            int OptionId = Convert.ToInt32(item.Tag);
            Package option = Package.FindPackageOptionById(OptionId);
            Package option2 = Package.GetAllOptionsById(OptionId);
            lblOptionName.Content = option2.Name;
            lblOptionDescription.Content = option2.Description;
            lblPrice.Content = option2.PricePerDay;

            lblTotalPrice.Content = package.PricePerDay + option2.PricePerDay;
        }


        public void ReloadPackage(int? selectedId, int userid, string pettype)
        {
            pet = Pet.FindById(userid);
            List<Package> allPackages = Package.GetAll();
            foreach (Package pack in allPackages)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = pack.ToString();
                item.Tag = pack.Id;
                item.IsSelected = selectedId == pack.Id;
                if (pack.PetTypeName == pettype)
                {
                    lbxResults.Items.Add(item);
                }
            }
        }
    }
}
