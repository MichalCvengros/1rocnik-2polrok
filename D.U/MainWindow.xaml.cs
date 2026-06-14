using System.Net;
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
using System.IO;

namespace D.U_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

        }

        private void Add_Student_Btn_Click(object sender, RoutedEventArgs e)
        {
            Student_ListView.Items.Add(Add_Student_Box.Text);
        }

        private void Remove_Student_Btn_Click(object sender, RoutedEventArgs e)
        {
            Student_ListView.Items.Remove(Student_ListView.SelectedItem);
        }

        private void Student_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Student_View_Box.Text = Student_ListView.SelectedItem.ToString();
        }
        private void AddGrade_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(Student_ListView.SelectedItem == null)
            {
                return;
            }
            string grade = AddGrade.Text;
            StudentsGrades.Items.Add(grade);
            List<int> grades = new List<int>();

            foreach (var item in StudentsGrades.Items)
            {
                grades.Add(int.Parse(item.ToString()));
            }

            PocetZnamok.Text = StudentsGrades.Items.Count.ToString();
            PriemerZnamok.Text = calculatePriemer(grades);
        }
        private string calculatePriemer(List<int> grades)
        {
            double sucet = 0;
            double max = grades.Count;
            double total = 0;
            foreach (var grade in grades)
            {
                sucet += grade;
            }
            total = sucet / max;
            return total.ToString();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ukladanieStudenta();
            ukladanieStudentovychZnamok();
        }

        List<int > grades = new List<int>();

        public void ukladanieStudenta()
        {
            Student student = new Student();

            string json = JsonSerializer.Serialize(Student_ListView.Items);
            File.WriteAllText("student.json", json);
        }

        private void ukladanieStudentovychZnamok()
        {
            if (Student_ListView.SelectedItem == " ")
            {
                string json2 = JsonSerializer.Serialize(StudentsGrades.Items);
                File.WriteAllText("grades.json", json2);
            }
        }
    }
}