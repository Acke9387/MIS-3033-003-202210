using System;
using System.Collections.Generic;
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

namespace WPF_Classes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Toy myToy = new Toy();
            myToy.Manufacturer = "Hasbro";
            myToy.Name = "Buzz";
            //...

            var uri = new Uri("https://images-na.ssl-images-amazon.com/images/I/71rL5zB1UZL.__AC_SX300_SY300_QL70_FMwebp_.jpg");
            var img = new BitmapImage(uri);

            imgPicture.Source = img;

            lstToys.Items.Add(myToy);
        }

        private void lstToys_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Toy selectedToy = (Toy)lstToys.SelectedItem;

            MessageBox.Show($"{selectedToy.Name}");
        }
    }
}
