using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfCopyVs1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
                string chosenFileName;
                    // user picked a file and pressed OK
                    chosenFileName = dialog.FileName; // user accepted
                    FileInfo fi = new FileInfo(chosenFileName);
                    boxIn.Text += $"{fi.Name}";
                    boxOut.Text += $"out{fi.Extension}";
                    lblUitvoer.Content = $"bestand is overgezet";
                
            }
            catch (FileNotFoundException ex)
            {

                lblUitvoer.Content = "geen bestand gekozen";
            }
        }
    }
}
