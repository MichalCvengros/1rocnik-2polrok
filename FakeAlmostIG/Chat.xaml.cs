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
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        MainWindow mainWindow;
        public Chat(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            ChatList.Items.Add($"{mainWindow.idk[0].Meno}: {ChatBox.Text}");
        }
    }
}
