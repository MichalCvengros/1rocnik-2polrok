using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CardGame
{
    internal class Card : Grid
    {
        private TextBlock ManaTextBlock;
        private TextBlock HPTextBlock;
        private TextBlock AttackTextBlock;

        public Card(double height, int mana, int hp, int damage)
        {
            ManaTextBlock = new TextBlock()
            {
                Text = mana.ToString() + " ",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Background = Brushes.DarkBlue,
                Foreground = Brushes.Black,
                FontSize = 16,

                Margin = new Thickness(2)
            };
            HPTextBlock = new TextBlock()
            {
                Text = " " + hp.ToString(),
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top,
                Background = Brushes.DarkGreen,
                Foreground = Brushes.Black,
                FontSize = 16,
                Margin = new Thickness(2)
            };
            AttackTextBlock = new TextBlock()
            {
                Text = " " + damage.ToString() + " ",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
                Background = Brushes.DarkRed,
                Foreground = Brushes.Black,
                FontSize = 16,
                Margin = new Thickness(2),

            };

            Width = 80;
            Height = height;
            Background = Brushes.Red;
            Margin = new Thickness(2);

            Children.Add(ManaTextBlock);
            Children.Add(HPTextBlock);
            Children.Add(AttackTextBlock);

            MouseDown += OnCardClicked;
        }
        private void OnCardClicked(object sender, MouseButtonEventArgs e)
        {
            if (sender is Card card)
            {

            }
        }
    }
}