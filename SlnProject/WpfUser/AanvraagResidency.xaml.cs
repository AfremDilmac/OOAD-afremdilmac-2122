using MyClassLibrary;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfUser
{
    /// <summary>
    /// Logique d'interaction pour AanvraagResidency.xaml
    /// </summary>
    public partial class AanvraagResidency : Page
    {
        Residency residence = new Residency();

        public AanvraagResidency(MainWindow dashboard)
        {
            InitializeComponent();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            residence.Startdate = dateStart.SelectedDate;
            residence.EndDate = dateEnd.SelectedDate;
            residence.PetId = Convert.ToInt32(tbxPetId.Text);
            residence.Remarks = tbxRemarks.Text;
            residence.Id = Convert.ToInt32(tbxId.Text);
            residence.Status = 0;
            residence.InsertToDb();
        }
    }
}
