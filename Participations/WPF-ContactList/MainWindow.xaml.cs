﻿using System;
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

            }
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            Contact selectedContact = (Contact)lstContacts.SelectedItem;


            txtId.Text = selectedContact.Id;
            //...
        }
    }
}