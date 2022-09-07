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
using System.IO;

namespace WPF_ContactList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] fileContents = File.ReadAllLines("contacts.txt");

            for (int i = 1; i < fileContents.Length; i++)
            {
                string[] pieces = fileContents[i].Split("|");
                //Id|FirstName|LastName|Email|Photo
                Contact c = new Contact()
                {
                    Id = Convert.ToInt32(pieces[0]),
                    FirstName = pieces[1],
                    LastName = pieces[2],
                    Email = pieces[3],
                    Photo = pieces[4]
                };
                //c.Id = Convert.ToInt32(pieces[0]);
                //c.FirstName = pieces[1];

                lstContacts.Items.Add(c);
            }

        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            Contact selected = (Contact)lstContacts.SelectedItem;
            //Contact selected = new Contact()
            //{
            //    Id = 1,
            //    FirstName = "john",
            //    LastName = "Smith",
            //    Email = "John@smith.com",
            //    Photo = ""
            //};

            if (selected is null)
            {
                return;
            }

            txtId.Text = selected.Id.ToString("N0");
            txtFirstname.Text = selected.FirstName;
            txtLastname.Text = selected.LastName;
            txtEmail.Text = selected.Email;
            imgPicture.Source = new BitmapImage(new Uri(selected.Photo));
            //...
        }

        private void lstContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnShow.IsEnabled = true;
        }
    }
}
