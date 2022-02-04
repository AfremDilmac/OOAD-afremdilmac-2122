﻿using System;
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

namespace WpfOxo
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
        int turn = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Hier wordt er berekend wie zijn beurt is om te spelen.
            //Hier ziet men of de button O of X zal zijn.
            if (turn % 2 == 0)
            {
                btn1.Content = Convert.ToString("O");
                turn++;
                btn1.IsEnabled = false;
            }
            else
            {
                btn1.Content = Convert.ToString("X");
                btn1.IsEnabled = false;
            }

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            //Hier wordt er berekend wie zijn beurt is om te spelen.
            if (turn % 2 == 1)
            {
                btn2.Content = Convert.ToString("X");
                turn++;
                btn2.IsEnabled = false;
            }
            else
            {
                btn2.Content = Convert.ToString("O");
                btn2.IsEnabled = false;
            }

            //Hier ziet men of de button O of X zal zijn.
            if (btn1.Content.ToString() == ("O") && btn2.Content.ToString() == ("O"))
            {
                if (btn3.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn1.Content.ToString() == ("X") && btn2.Content.ToString() == ("X"))
            {
                if (btn3.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            //Hier wordt er berekend wie zijn beurt is om te spelen.
            if (turn % 2 == 0)
            {
                btn3.Content = Convert.ToString("O");
                turn++;
                btn3.IsEnabled = false;
            }
            else
            {
                btn3.Content = Convert.ToString("X");
                btn3.IsEnabled = false;
            }

            //Hier ziet men of de button O of X zal zijn.
            if (btn1.Content.ToString() == ("O") && btn2.Content.ToString() == ("O"))
            {
                if (btn3.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn1.Content.ToString() == ("X") && btn2.Content.ToString() == ("X"))
            {
                if (btn3.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }
            if (btn3.Content.ToString() == ("O") && btn5.Content.ToString() == ("O"))
            {
                if (btn7.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn3.Content.ToString() == ("X") && btn5.Content.ToString() == ("X"))
            {
                if (btn7.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }


            if (btn3.Content.ToString() == ("O") && btn6.Content.ToString() == ("O"))
            {
                if (btn9.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn3.Content.ToString() == ("X") && btn6.Content.ToString() == ("X"))
            {
                if (btn9.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            //Hier wordt er berekend wie zijn beurt is om te spelen.
            if (turn % 2 == 1)
            {
                btn4.Content = Convert.ToString("X");
                turn++;
                btn4.IsEnabled = false;
            }
            else
            {
                btn4.Content = Convert.ToString("O");
                btn4.IsEnabled = false;
            }

            //Hier ziet men of de button O of X zal zijn.
            if (btn1.Content.ToString() == ("O") && btn4.Content.ToString() == ("O"))
            {
                if (btn7.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn1.Content.ToString() == ("X") && btn4.Content.ToString() == ("X"))
            {
                if (btn7.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }

            if (btn1.Content.ToString() == ("O") && btn4.Content.ToString() == ("O"))
            {
                if (btn9.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn1.Content.ToString() == ("X") && btn4.Content.ToString() == ("X"))
            {
                if (btn9.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            //Hier wordt er berekend wie zijn beurt is om te spelen.
            if (turn % 2 == 0)
            {
                btn5.Content = Convert.ToString("O");
                turn++;
                btn5.IsEnabled = false;
            }
            else
            {
                btn5.Content = Convert.ToString("X");
                btn5.IsEnabled = false;
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            //Hier wordt er berekend wie zijn beurt is om te spelen.
            if (turn % 2 == 1)
            {
                btn6.Content = Convert.ToString("X");
                btn6.IsEnabled = false;
                turn++;
            }
            else
            {
                btn6.Content = Convert.ToString("O");
                btn6.IsEnabled = false;

            }

            //Hier ziet men of de button O of X zal zijn.
            if (btn3.Content.ToString() == ("O") && btn6.Content.ToString() == ("O"))
            {
                if (btn9.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn3.Content.ToString() == ("X") && btn6.Content.ToString() == ("X"))
            {
                if (btn9.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }

            if (btn3.Content.ToString() == ("O") && btn5.Content.ToString() == ("O"))
            {
                if (btn7.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn3.Content.ToString() == ("X") && btn5.Content.ToString() == ("X"))
            {
                if (btn7.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            //Hier wordt er berekend wie zijn beurt is om te spelen.
            if (turn % 2 == 0)
            {
                btn7.Content = Convert.ToString("O");
                turn++;
                btn7.IsEnabled = false;
            }
            else
            {

                btn7.Content = Convert.ToString("X");
                btn7.IsEnabled = false;
            }

            //Hier ziet men of de button O of X zal zijn.
            if (btn1.Content.ToString() == ("O") && btn4.Content.ToString() == ("O"))
            {
                if (btn7.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn1.Content.ToString() == ("X") && btn4.Content.ToString() == ("X"))
            {
                if (btn7.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }


            if (btn7.Content.ToString() == ("O") && btn8.Content.ToString() == ("O"))
            {
                if (btn9.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn7.Content.ToString() == ("X") && btn8.Content.ToString() == ("X"))
            {
                if (btn9.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }

            if (btn3.Content.ToString() == ("O") && btn5.Content.ToString() == ("O"))
            {
                if (btn7.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn3.Content.ToString() == ("X") && btn5.Content.ToString() == ("X"))
            {
                if (btn7.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            //Hier wordt er berekend wie zijn beurt is om te spelen.
            if (turn % 2 == 1)
            {
                btn8.Content = Convert.ToString("X");
                btn8.IsEnabled = false;
                turn++;
            }
            else
            {
                btn8.Content = Convert.ToString("O");
                btn8.IsEnabled = false;
            }

            //Hier ziet men of de button O of X zal zijn.
            if (btn7.Content.ToString() == ("O") && btn8.Content.ToString() == ("O"))
            {
                if (btn9.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn7.Content.ToString() == ("X") && btn8.Content.ToString() == ("X"))
            {
                if (btn9.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            //Hier wordt er berekend wie zijn beurt is om te spelen.
            if (turn % 2 == 0)
            {
                btn9.Content = Convert.ToString("O");
                turn++;
                btn9.IsEnabled = false;
            }
            else
            {
                btn9.Content = Convert.ToString("X");
                btn9.IsEnabled = false;
            }

            //Hier ziet men of de button O of X zal zijn.
            if (btn3.Content.ToString() == ("O") && btn6.Content.ToString() == ("O"))
            {
                if (btn9.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn3.Content.ToString() == ("X") && btn6.Content.ToString() == ("X"))
            {
                if (btn9.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }

            if (btn7.Content.ToString() == ("O") && btn8.Content.ToString() == ("O"))
            {
                if (btn9.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn7.Content.ToString() == ("X") && btn8.Content.ToString() == ("X"))
            {
                if (btn9.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }

            if (btn1.Content.ToString() == ("O") && btn4.Content.ToString() == ("O"))
            {
                if (btn9.Content.ToString() == ("O"))
                {
                    lblUitvoer.Content = "Player 1 heeft gewonnen!";
                }
            }
            else if (btn1.Content.ToString() == ("X") && btn4.Content.ToString() == ("X"))
            {
                if (btn9.Content.ToString() == ("X"))
                {
                    lblUitvoer.Content = "Player 2 heeft gewonnen!";
                }
            }

        }
    }
}