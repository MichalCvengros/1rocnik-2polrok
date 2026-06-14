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

namespace GunShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        }

        private void ShopBtn_Click(object sender, RoutedEventArgs e)
        {
            Shop shop = new Shop(this);
            shop.Show();

            foreach (var item in GunList.Items)
            {
                shop.ShopList.Items.Add(item.ToString());
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            GunList.Items.Add(GunText.Text);
        }
    }
}