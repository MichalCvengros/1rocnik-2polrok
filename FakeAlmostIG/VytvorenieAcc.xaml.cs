using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FakeAlmostIG
{
    /// <summary>
    /// Interaction logic for VytvorenieAcc.xaml
    /// </summary>
    public partial class VytvorenieAcc : Window
    {
        MainWindow mainWindow;
        public VytvorenieAcc(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();


            user.Meno = NameText.Text.ToString();
            user.Heslo = HesloText.Text.ToString();
            mainWindow.idk.Add(user);

            this.Close();
        }
    }
}
