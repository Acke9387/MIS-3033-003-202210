using Newtonsoft.Json;
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
        List<Person> peeps = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();

            string dataAsJson = File.ReadAllText("MOCK_DATA.json");

            peeps = JsonConvert.DeserializeObject<List<Person>>(dataAsJson);

            lstPeople.Items.Contains(new Person() { });

            foreach (Person person in peeps)
            {
                if (person.FirstName.ToLower()[0] == 'a')
                {
                    lstPeople.Items.Add(person);
                }
            }



        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            string serializedData = JsonConvert.SerializeObject(lstPeople.Items, Formatting.Indented);

            File.WriteAllText("all_people_starting_with_a.json", serializedData);

            MessageBox.Show("Saved successfully");
        }
    }
}
