using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Przejazd
    {
        public int IdPrzejazd { get; set; }
        public TimeSpan Czas { get; set; }
        public DateTime DataPrzejazdu { get; set; }
        public int IdTor { get; set; }
        public int IdGokart { get; set; }
        public int IdKierowca { get; set; }

        public Tor Tor { get; set; }
        public Gokart Gokart { get; set; }
        public Kierowca Kierowca { get; set; }
    }
}
