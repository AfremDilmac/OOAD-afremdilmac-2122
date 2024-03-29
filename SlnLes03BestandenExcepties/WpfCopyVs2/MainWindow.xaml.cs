﻿using Microsoft.Win32;
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

namespace WpfCopyVs2
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
        private void btnKies_Click(object sender, RoutedEventArgs e)
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
                boxZoek.Text = chosenFileName;
               
            }
            catch (FileNotFoundException ex)
            {
                lblUitvoer.text = "File not found";
               
            }

           
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dialog.Filter = "Tekstbestanden|*.TXT;*.TEXT";
                dialog.FileName = "savedfile.txt";
                if (dialog.ShowDialog() == true)
                {
                    File.WriteAllText(dialog.FileName, "your saved text here");
                }
                else
                {
                    // user pressed Cancel or escaped dialog window
                    lblUitvoer.text = "Event cancelled";
                }
            }
            catch (FileNotFoundException ex)
            {
                lblUitvoer.text = "Event cancelled";
               
            }

            
        }

    }
}
