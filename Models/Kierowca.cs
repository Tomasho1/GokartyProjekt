using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Kierowca
    {
        public int IdKierowca { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string NumerKarty { get; set; }

        public ICollection<KierowcaSponsor> KierowcaSponsor { get; set; }
        public ICollection<Sprzet> Sprzety { get; set; }
        public ICollection<Przejazd> Przejazdy { get; set; }
    }
}