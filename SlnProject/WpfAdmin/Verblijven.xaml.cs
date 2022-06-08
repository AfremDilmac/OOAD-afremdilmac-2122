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
    public enum Status { Afwachting, Geldig, Geweigerd }
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

        private void btnClickItem(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int id = (int)btn.Tag;
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
            cbxStatus.SelectedIndex = residency.Status;

            wrpItem.Children.Clear();
            List<Foto> items = Foto.GetResidencyById(userId);
            if (items == null) return;

            int i = 0;
            foreach (Foto test in items)
            {
                Button btn = new Button();
                btn.Name = $"btn{i + 1}";
                btn.Tag = test.Id;
                btn.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                btn.BorderBrush = Brushes.White;
                btn.Click += new RoutedEventHandler(btnClickItem);

                StackPanel s = new StackPanel();

                Image image = new Image();
                image.Width = 180;
                image.Height = 150;
                image.Source = test.Image;

                Label l = new Label();
                l.Content = test.ToString();
                l.Width = 180;
                l.HorizontalContentAlignment = HorizontalAlignment.Center;
                l.FontSize = 10;

                s.Children.Add(image);
                s.Children.Add(l);
                btn.Content = s;
                wrpItem.Children.Add(btn);
            }

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

            Status afwachting = Status.Afwachting;
            Status geldig = Status.Geldig;
            Status geweigerd = Status.Geweigerd;
            switch (cbxStatus.SelectedIndex)
            {
                case 0:
                    verblijven.Status = Convert.ToInt32(afwachting);
                    break;
                case 1:
                    verblijven.Status = Convert.ToInt32(geldig);
                    break;
                case 2: verblijven.Status = Convert.ToInt32(geweigerd);
                    break;
                default:
                    verblijven.Status = 0;
                    break;
            }
            verblijven.Update();
        }

        private void cbxStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
