﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace JSON_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string dataAsJson = File.ReadAllText("MOCK_DATA.json");

            List<Person> peeps = new List<Person>();
            peeps = JsonConvert.DeserializeObject<List<Person>>(dataAsJson);



            foreach (Person person in peeps)
            {
                lstPeople.Items.Add(person);
            }



        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
