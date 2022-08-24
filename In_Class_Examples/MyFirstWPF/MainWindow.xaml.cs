using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MyFirstWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
            {
                lstNames.Items.Add(i.ToString("N4"));
            }

        }

        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;

            string name = $"{lastName}, {firstName}";

            lstNames.Items.Add(name);

            txtFirstName.Text = string.Empty;
            txtLastName.Clear();

        }

        //private void btnClickMe_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    MessageBox.Show("You entered the button", "Entered", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //}

    }
}
