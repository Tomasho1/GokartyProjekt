using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Wlasciciel
    {
        public int IdWlasciciel{ get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public ICollection<Tor> Tory { get; set; }
    }
}
