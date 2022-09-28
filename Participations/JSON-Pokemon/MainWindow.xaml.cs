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

namespace JSON_Pokemon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PokemonDetails pokemon = null;
        private bool showFront = true;

        public MainWindow()
        {
            InitializeComponent();


            string url = "https://pokeapi.co/api/v2/pokemon/?offset=0&limit=1200";
            PokemonAPI api = null;

            using (var client = new HttpClient())
            {

                HttpResponseMessage response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {

                    var json = response.Content.ReadAsStringAsync().Result;

                    api = JsonConvert.DeserializeObject<PokemonAPI>(json);

                }

            }

            foreach (ResultItem pokemon in api.results.OrderBy(x => x.name))
            {
                lstPokemon.Items.Add(pokemon);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultItem seleted = (ResultItem)lstPokemon.SelectedItem;

            using (var client = new HttpClient())
            {
                string json = client.GetStringAsync(seleted.url).Result;

                pokemon = JsonConvert.DeserializeObject<PokemonDetails>(json);
                txtHeight.Text = pokemon.height.ToString();
                txtWeight.Text = pokemon.weight.ToString();
                txtName.Text = pokemon.name;

                img.Source = new BitmapImage(new Uri(pokemon.sprites.front_default));
                showFront = false;

            }
        }

        private void btnFlip_Click(object sender, RoutedEventArgs e)
        {

            if (showFront)
            {
                img.Source = new BitmapImage(new Uri(pokemon.sprites.front_default));
                showFront = false;
            }
            else
            {
                if (pokemon.sprites.back_default != null)
                {
                    img.Source = new BitmapImage(new Uri(pokemon.sprites.back_default)); 
                }
                showFront = true;
            }
           


        }
    }
}
