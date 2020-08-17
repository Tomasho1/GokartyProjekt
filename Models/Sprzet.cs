using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Sprzet
    {
        public int IdSprzet { get; set; }
        public string Nazwa { get; set; }
        public string Koszt { get; set; }
        public int? IdKierowca { get; set; }

        public Kierowca Kierowca { get; set; }
    }
}