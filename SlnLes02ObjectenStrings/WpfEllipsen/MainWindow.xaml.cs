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
using System.Windows.Threading;

namespace WpfEllipsen
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

        private void btnTekenen_Click(object sender, RoutedEventArgs e)
        {
            if (sldMin.Value > sldMax.Value)
            {
                lblWarning.Content = "De minimum straal mag niet groter zijn dan de maximum straal!";
            }
            else
            {
                const int AANTAL_ELLIPSEN = 1;
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);

                Int32 index = 1, maxValue = Convert.ToInt32(sldAantal.Value);

                timer.Tick += (s, e) =>
                {
                    
                    index++; // increment index
                    for (int i = 1; i <= AANTAL_ELLIPSEN; i++)
                    {  // maak de ellips
                        Random randomWidth = new Random();
                        int rWidth = randomWidth.Next(0, 100);

                        Random randomHeight = new Random();
                        int rHeight = randomHeight.Next(0, 100);

                        Random r = new Random();
                        Random g = new Random();
                        Random b = new Random();

                        Random random = new Random();
                        int width = 700;
                        int height = 200;
                        double rx = random.NextDouble() * width;
                        double ry = random.NextDouble() * height;

                        int minRadius = random.Next(Convert.ToInt32(sldMin.Value), Convert.ToInt32(sldMax.Value));
                        int maxRadius = random.Next(Convert.ToInt32(sldMin.Value), Convert.ToInt32(sldMax.Value));

                        Ellipse newEllipse = new Ellipse();
                        newEllipse.Width = minRadius;
                        newEllipse.Height = maxRadius;
                        newEllipse.Fill = new SolidColorBrush(Color.FromRgb((byte)r.Next(), (byte)g.Next(), (byte)b.Next()));
                        double xPos = rx;
                        double yPos = ry;
                        newEllipse.SetValue(Canvas.LeftProperty, xPos);
                        newEllipse.SetValue(Canvas.TopProperty, yPos);
                        //voeg ellips toe aan het canvas
                        canvas1.Children.Add(newEllipse);
                    }

                    // Stop if this event has been raised max number of times
                    if (index > maxValue) timer.Stop();
                };

                timer.Start();
              
            }
        }

        private void sldAantal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                string value = string.Format("{0}", Math.Floor(e.NewValue));
                lblAantal.Content = value;
            });
        }

        private void sldMin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                string value = string.Format("{0}", Math.Floor(e.NewValue));
                lblMin.Content = value;
            });
        }

        private void sldMax_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                string value = string.Format("{0}", Math.Floor(e.NewValue));
                lblMax.Content = value;
            });
        }
    }
}
