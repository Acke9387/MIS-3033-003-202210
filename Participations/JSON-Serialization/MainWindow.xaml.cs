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

namespace JSON_Serialization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Game> AllGames = new List<Game>();
        public MainWindow()
        {
            InitializeComponent();

            List<string> linesOfFile = File.ReadAllLines("all_games.csv").Skip(1).ToList();

            foreach (string line in linesOfFile)
            {
                //        0      1          2         3         4          5
                // line: name,platform,release_date,summary,meta_score,user_review

                string[] pieces = line.Split(",");

                double review;
                Game g;
                if (double.TryParse(pieces[5], out review))
                {
                    g = new Game()
                    {
                        Name = pieces[0],
                        Platform = pieces[1],
                        ReleaseDate = pieces[2],
                        Summary = pieces[3],
                        MetaScore = Convert.ToInt32(pieces[4]),
                        UserReview = Convert.ToDouble(pieces[5])
                    };
                }
                else
                {
                    g = new Game()
                    {
                        Name = pieces[0],
                        Platform = pieces[1],
                        ReleaseDate = pieces[2],
                        Summary = pieces[3],
                        MetaScore = Convert.ToInt32(pieces[4]),
                        UserReview = null
                    };
                }

                //g.Summary = pieces[3];
                if (cboPlatforms.Items.Contains(g.Platform) == false)
                {
                    cboPlatforms.Items.Add(g.Platform); 
                }

                AllGames.Add(g);
                lstGames.Items.Add(g);
            }


        }

        private void cboPlatforms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string platform = (string)cboPlatforms.SelectedItem;

            lstGames.Items.Clear();

            foreach (Game item in AllGames)
            {
                if (item.Platform == platform)
                {
                    lstGames.Items.Add(item);
                }
            }

            //var matchedResults = AllGames.Where(item => item.Platform == platform);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string serializedData = JsonConvert.SerializeObject(lstGames.Items, Formatting.Indented);

            File.WriteAllText($"{cboPlatforms.SelectedItem.ToString()}_games.json", serializedData);

            MessageBox.Show("Data saved successfully.");
        }

        private void lstGames_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Game selected = (Game)lstGames.SelectedItem;

            GameDetails g = new GameDetails();
            g.PopulateData(selected);
            g.ShowDialog();
        }
    }
}
