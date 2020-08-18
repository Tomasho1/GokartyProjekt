using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.DTOs
{
    public class UniversalFastestLapOnGivenTrackResponse
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int IdKierowca { get; set; }
        public DateTime DataPrzejazdu { get; set; }
        public double Minuty { get; set; }
        public double Sekundy { get; set; }
        public double Milisekundy { get; set; }
        public string NazwaGokartu { get; set; }
    }
}
