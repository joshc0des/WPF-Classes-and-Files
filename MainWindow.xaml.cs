using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
using static System.Net.Mime.MediaTypeNames;

namespace WPF_Classes_and_Files
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var rowsOfCSV = File.ReadAllLines("Toys.csv");

            foreach (var item in rowsOfCSV.Skip(1))
            {
                Toy t = new Toy();
                string[] toyData = item.Split(',');
                t.Manufacturer = toyData[0];
                t.Name = toyData[1];
                t.Price = Convert.ToDouble(toyData[2]);
                t.Image = toyData[3];

                lstToys.Items.Add(t);
            }
        }

        private void lstToys_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstToys.SelectedItem != null)
            {
                Toy selectedToy = (Toy)lstToys.SelectedItem;
                var uri = new Uri(selectedToy.Image);
                imageControl.Source = new BitmapImage(uri);
            } else
            {
                imageControl.Source = null;
            }
        }

        private void lstToys_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Toy selectedToy = (Toy)lstToys.SelectedItem;

            if (lstToys.SelectedItem != null)
            {
                MessageBox.Show($"{selectedToy.GetAisle()}");
            }
        }

        private void subButton_Click(object sender, RoutedEventArgs e)
        {
            Toy t = new Toy();
            t.Manufacturer = txtMan.Text;
            t.Name = txtNam.Text;
            t.Price = Convert.ToDouble(txtPri.Text);
            t.Image = txtImg.Text;

            lstToys.Items.Add(t);
        }
    }
}
