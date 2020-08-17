using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Silnik
    {
        public int IdSilnik { get; set; }
        public int Moc { get; set; }
        public double Pojemnosc { get; set; }
        public string Producent { get; set; }

        public ICollection<Gokart> Gokarty { get; set; }
    }
}