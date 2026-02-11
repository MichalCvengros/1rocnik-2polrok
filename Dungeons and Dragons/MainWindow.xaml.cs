using System;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dungeons_and_Dragons
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

        int roll = 0;
        private void d4_Click(object sender, RoutedEventArgs e)
        {
            Random d4 = new Random();
            roll = d4.Next(1, 5);

            d4Zapis.Content = roll.ToString();
        }

        private void d6_Click_1(object sender, RoutedEventArgs e)
        {
            Random d6 = new Random();
            roll = d6.Next(1, 7);

            d6Zapis.Content = roll.ToString();
        }

        private void d8_Click_1(object sender, RoutedEventArgs e)
        {
            Random d8 = new Random();
            roll = d8.Next(1, 9);

            d8Zapis.Content = roll.ToString();
        }

        private void d10_Click(object sender, RoutedEventArgs e)
        {
            Random d10 = new Random();
            roll = d10.Next(1, 11);

            d10Zapis.Content = roll.ToString();
        }

        private void d12_Click(object sender, RoutedEventArgs e)
        {
            Random d12 = new Random();
            roll = d12.Next(1, 13);

            d12Zapis.Content = roll.ToString();
        }

        private void d20_Click(object sender, RoutedEventArgs e)
        {
            Random d20 = new Random();
            roll = d20.Next(1, 21);

            d20Zapis.Content = roll.ToString();
        }

        private string PlayerStrengthScore = "";

        private void StrengthScore_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlayerStrengthScore = StrengthScore.Text;
            int score = int.Parse(PlayerStrengthScore);
            int modifier = 0;
            modifier = (score - 10) / 2;

            if (modifier < 0)
            {
                modifier *= -1;
                StrengthModifier.Text = "-" + modifier.ToString();

                StrengthModifier.Text = modifier.ToString();
            }
        }

    }
}