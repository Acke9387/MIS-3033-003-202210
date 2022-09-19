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

namespace WPF_JSONFromAFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Car> allData = new List<Car>();

        public MainWindow()
        {
            InitializeComponent();


            string data = File.ReadAllText("Mock_Data_Car_Owners.json");
            allData = JsonConvert.DeserializeObject<List<Car>>(data);


            cboColors.Items.Add("All Colors");
            cboColors.SelectedIndex = 0;
            List<string> colors = new List<string>();

            foreach (Car car in allData)
            {
                lstCars.Items.Add(car);

                if (!colors.Contains(car.Color))// !cboColors.Items.Contains(car.Color) )
                {
                    //cboColors.Items.Add(car.Color); 
                    colors.Add(car.Color);
                }
            }

            foreach (string color in colors.OrderBy(x => x))
            {
                cboColors.Items.Add(color);
            }
            lblResults.Content = $"There are {lstCars.Items.Count.ToString("N0")} cars";
        }

        private void cboColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedColor = (string)cboColors.SelectedItem;

            lstCars.Items.Clear();

            foreach (Car car in allData)
            {
                if (selectedColor == car.Color || selectedColor == "All Colors")
                {
                    lstCars.Items.Add(car);
                }
            }

            lblResults.Content = $"There are {lstCars.Items.Count.ToString("N0")} {selectedColor} cars";
        }
    }
}
