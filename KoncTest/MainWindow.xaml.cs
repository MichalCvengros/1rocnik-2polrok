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

namespace KoncTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Auto krokodil = new Auto();

        Auto cadca = new Auto
        {
            SPZ = "CA-123AB",
            basevzdialenost = 100000,
        };
        Auto zilina = new Auto
        {
            SPZ = "ZA-568HD",
            basevzdialenost = 150000,
        };
        Auto blava = new Auto
        {
            SPZ = "AA-987BC",
            basevzdialenost = 200000,
        };
        private void reLoadingDistance(int k)
        {
            int vzdialenost = k;
            if (Auta.SelectedIndex == 0)
            {
                cadca.basevzdialenost = vzdialenost;
            }
            else if (Auta.SelectedIndex == 1)
            {
                blava.basevzdialenost = vzdialenost;
            }
            else if (Auta.SelectedIndex == 2)
            {
                zilina.basevzdialenost = vzdialenost;
            }
            KMTextBlock.Text = vzdialenost.ToString();
        }
        private string checkingSPZ()
        {
            string spz = "";
            if (Auta.SelectedIndex == 0)
            {
                spz = cadca.SPZ;
            }
            else if (Auta.SelectedIndex == 1)
            {
                spz = blava.SPZ;
            }
            else if (Auta.SelectedIndex == 2)
            {
                spz = zilina.SPZ;
            }
            return spz;
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Auta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Auto auto = new Auto();
            int vzdialenost = 0;
            if (Auta.SelectedIndex == 0)
            {
                vzdialenost = cadca.basevzdialenost;
            }
            else if (Auta.SelectedIndex == 1)
            {
                vzdialenost = blava.basevzdialenost;
            }
            else if (Auta.SelectedIndex == 2)
            {
                vzdialenost = zilina.basevzdialenost;
            }
            KMTextBlock.Text = vzdialenost.ToString();
        }

        private void AddKmBtn_Click(object sender, RoutedEventArgs e)
        {
            safetycheck();
            SPZList.Items.Add(checkingSPZ());

            StartKM.Items.Add(KMTextBlock.Text);

            string nieco = KMTextBlock.Text;
            int niecoo = int.Parse(nieco);

            string nieco1 = AddKMTextBox.Text;
            int niecoo1 = int.Parse(nieco1);

            FinalKM.Items.Add(AddKMTextBox.Text);
            NajazdeneKM.Items.Add(niecoo1 - niecoo);

            double wbhg = 0;
            foreach (double i in calculateCost())
            {
                if (i > 0) wbhg = i;
            }
            CelkovaCena.Items.Add(wbhg);
            reLoadingDistance(niecoo1);
        }

        private List<double> calculateCost()
        {
            string nieco = KMTextBlock.Text;
            int niecoo = int.Parse(nieco);

            string nieconaprvavo = AddKMTextBox.Text;
            int nieco1napravo = int.Parse(nieconaprvavo);
            List<double> ceny = new List<double>();

            string cenaZeroCarr = "0,42";
            double cenaZeroCar = double.Parse(cenaZeroCarr);

            string cenaFisrtCarr = "0,36";
            double cenaFisrtCar = double.Parse(cenaFisrtCarr);

            string cenaSecondCarr = "0,25";
            double cenaSecondCar = double.Parse(cenaSecondCarr);

            double en = (nieco1napravo - niecoo);

            double FinalnacenaPreZeroauto = 0;
            double FinalnacenaPre1Auto = 0;
            double FinalnaCenaPre2Auto = 0;

            if (Auta.SelectedIndex == 0)
            {
                FinalnacenaPreZeroauto = en * cenaZeroCar;
            }
            else if (Auta.SelectedIndex == 1)
            {
                FinalnacenaPre1Auto = en * cenaFisrtCar;
            }
            else if (Auta.SelectedIndex == 2)
            {
                FinalnaCenaPre2Auto = en * cenaSecondCar;
            }
            ceny.Add(FinalnacenaPreZeroauto);
            ceny.Add(FinalnacenaPre1Auto);
            ceny.Add(FinalnaCenaPre2Auto);
            return ceny;
        }
        private void safetycheck()
        {
            if (AddKMTextBox.Text == "0")
            {
                MessageBox.Show("You cant do this.");
                this.Close();
            }
        }
    }
}