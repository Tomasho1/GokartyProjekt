using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Adres
    {
        public int IdAdres { get; set; }
        public string Panstwo { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }

        public Tor Tor { get; set; }
    }
}
