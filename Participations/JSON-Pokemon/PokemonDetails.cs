using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Pokemon
{
    public class PokemonDetails
    {

        public int weight {get;set;}
        public int height { get; set; }


        public string name { get; set; }


        public Sprite sprites { get; set; }

    }

    public class Sprite
    {
        public string front_default { get; set; }

        public string back_default { get; set; }
    }
}
