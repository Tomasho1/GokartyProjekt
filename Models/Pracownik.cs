using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Pracownik
    {
        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string Stanowisko { get; set; }
        public double Wynagrodzenie { get; set; }
        public int IdTor { get; set; }
        public int IdUzytkownik { get; set; }

        public Tor Tor { get; set; }
        public Uzytkownik Uzytkownik { get; set; }
    }
}