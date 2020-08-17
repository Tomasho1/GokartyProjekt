using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Gokart
    {
        public int IdGokart { get; set; }
        public string Nazwa { get; set; }
        public int Waga { get; set; }
        public int IdSilnik { get; set; }
        public int IdPodwozie { get; set; }
        public int IdNadwozie { get; set; }
        public int IdTor { get; set; }

        public Silnik Silnik { get; set; }
        public Podwozie Podwozie { get; set; }
        public Nadwozie Nadwozie { get; set; }
        public Tor Tor { get; set; }
        public ICollection<Przejazd> Przejazdy { get; set; }
    }
}