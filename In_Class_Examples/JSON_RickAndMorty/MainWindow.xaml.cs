using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace JSON_RickAndMorty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string url = "https://rickandmortyapi.com/api/character";

            HttpClient client = new HttpClient();
            string json = client.GetStringAsync(url).Result;

            RickAndMortyAPI data = JsonConvert.DeserializeObject<RickAndMortyAPI>(json);

            foreach (Character character in data.results)
            {
                cboCharacters.Items.Add(character); 
            }
        }

        private void cboCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selected = (Character)cboCharacters.SelectedItem;

            img.Source = new BitmapImage(new Uri(selected.image));
            lblName.Content = selected.name;
        }
    }
}
