using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Tor
    {
        public int IdTor { get; set; }
        public string Nazwa { get; set; }
        public double Dlugosc { get; set; }
        public double StawkaGodzinowa { get; set; }
        public int IdAdres { get; set; }
        public int IdWlasciciel { get; set; }

        public Adres Adres { get; set; }
        public Wlasciciel Wlasciciel { get; set; }
        public ICollection<Gokart> Gokarty { get; set; }
        public ICollection<Przejazd> Przejazdy { get; set; }
        public ICollection<Pracownik> Pracownicy { get; set; }
    }
}
