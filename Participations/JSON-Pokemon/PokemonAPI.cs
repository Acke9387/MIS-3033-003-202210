using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Pokemon
{
    public class PokemonAPI
    {


        public int count { get; set; }

        public List<ResultItem> results { get; set; }

    }

    public class ResultItem
    {

        public string name { get; set; }

        public string url { get; set; }

        public override string ToString()
        {
            return name;
        }

    }
}
