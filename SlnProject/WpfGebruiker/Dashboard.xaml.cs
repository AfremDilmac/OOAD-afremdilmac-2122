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

namespace WpfGebruiker
{
    /// <summary>
    /// Logique d'interaction pour Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
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

        }
    }
}
