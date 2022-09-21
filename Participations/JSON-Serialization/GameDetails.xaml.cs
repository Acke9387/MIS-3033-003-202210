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
using System.Windows.Shapes;

namespace JSON_Serialization
{
    /// <summary>
    /// Interaction logic for GameDetails.xaml
    /// </summary>
    public partial class GameDetails : Window
    {
        public GameDetails()
        {
            InitializeComponent();
        }

        public void PopulateData(Game g)
        {
            txtMetaScore.Text = g.MetaScore.ToString();
            txtPlatform.Text = g.Platform;
            txtReleaseDate.Text = g.ReleaseDate;
            txtSummary.Text = g.Summary;
            txtUserReview.Text = g.UserReview.ToString();

            lblTitle.Content = g.Name;
        }
    }
}
