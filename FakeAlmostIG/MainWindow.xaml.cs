using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FakeAlmostIG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<User> idk = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            load();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            MenoLbl.Visibility = Visibility.Visible;
            HesloLbl.Visibility = Visibility.Visible;
            MenoBox.Visibility = Visibility.Visible;
            HesloBox.Visibility = Visibility.Visible;
            EnterChatBtn.Visibility = Visibility.Visible;
        }

        private void CreateAccBtn_Click(object sender, RoutedEventArgs e)
        {
            VytvorenieAcc vytvorenieAcc = new VytvorenieAcc(this);

            vytvorenieAcc.Show();
        }
        private void CheckingNameAndPassword()
        {
            foreach (User user in idk)
            {
                Chat chat = new Chat(this);

                if (user.Meno == MenoBox.Text && user.Heslo == HesloBox.Text)
                {
                    MessageBox.Show("Login successful!");
                    chat.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }
            }
        }

        private void EnterChatBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckingNameAndPassword();
        }

        public void save()
        {
            string json = JsonSerializer.Serialize(idk);
            File.WriteAllText("users.json", json);
        }
        public void load()
        {
            string jsonL = File.ReadAllText("users.json");
            idk = JsonSerializer.Deserialize<List<User>>(jsonL);
        }

    }
}