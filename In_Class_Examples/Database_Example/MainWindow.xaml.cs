using Microsoft.EntityFrameworkCore;
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

namespace Database_Example
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DB_128040_practiceContext db = new DB_128040_practiceContext();
        public MainWindow()
        {
            InitializeComponent();


            //foreach (var movie in db.Movies.Include(m => m.Director).Take(100))
            //{
            //    lstMovies.Items.Add(movie);
            //}

            var directors = db.Directors.Include(x => x.Movies) ;

            //Director James_Cameron = db.Directors.Find(1);

            foreach (var director in directors)
            {
                cboDirectors.Items.Add(director);
            }


            //Create a new director
            Director d = new Director();
            d.DirectorId = 4;
            d.DirectorName = "Matt";

            db.Directors.Add(d);

            db.SaveChanges();

            //Delete a director

            var dd = db.Directors.Find(4);
            db.Directors.Remove(dd);

            db.SaveChanges();

            //UPDATE a director

            dd = db.Directors.Find(4);
            dd.DirectorName = "John";

            db.SaveChanges();

        }

        private void cboDirectors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstMovies.Items.Clear();
            Director selected = (Director)cboDirectors.SelectedItem;

            var movies = db.Movies.Where(x => x.DirectorId == selected.DirectorId);

            foreach (var movie in selected.Movies)
            {
                lstMovies.Items.Add(movie);
            }
        }
    }
}
