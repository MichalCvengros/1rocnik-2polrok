using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stack<Card> deck = [];
        public MainWindow()
        {
            InitializeComponent();
            P1_Cards.Height = 100;
            P1_Cards.Orientation = Orientation.Horizontal;

            deck.Push(new Card(P1_Cards.Height, 5, 7, 3));
            deck.Push(new Card(P1_Cards.Height, 2, 2, 2));
            deck.Push(new Card(P1_Cards.Height, 5, 5, 5));

            /*Card card1 = new Card(P1_Cards.Height, 5, 7, 3);
            Card card2 = new Card(P1_Cards.Height, 7, 6, 2);
            P1_Cards.Children.Add(card1);
            P1_Cards.Children.Add(card2);*/
        }

        private void NextTurn_Click(object sender, RoutedEventArgs e)
        {
            if(deck.Count > 0)
            {
                Card dreamcard = deck.Pop();
                P1_Cards.Children.Add(dreamcard);
            }
        }
    }
}