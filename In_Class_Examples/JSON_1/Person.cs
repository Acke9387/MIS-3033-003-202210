using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JSON_1
{
    public class Person
    {

        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName    {get;set;}
        public string last_name     {get;set;}
        public string email         {get;set;}
        public string gender        {get;set;}
        public string ip_address    {get;set;}
        public string city          {get;set;}

        public override string ToString()
        {
            return $"{FirstName} {last_name} {city}";
        }

    }
}
