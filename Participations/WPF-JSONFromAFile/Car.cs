using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_JSONFromAFile
{
    public class Car
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }


        public Car()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Make = string.Empty;
            Model = string.Empty;
            Year = 0;
            Color = string.Empty;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} has a {Color} {Year.ToString("G0")} {Make} {Model}";
        }
    }
}
