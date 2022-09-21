using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JSON_Serialization
{
    public class Game
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public string ReleaseDate { get; set; }
        public string Summary { get; set; }
        public int MetaScore { get; set; }
        public double? UserReview { get; set; }

        public Game()
        {
            Name = string.Empty;
            Platform = string.Empty;
            ReleaseDate = string.Empty;
            Summary = string.Empty;
            MetaScore = 0;
            UserReview = 0;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
