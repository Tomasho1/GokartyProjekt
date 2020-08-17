using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Podwozie
    {
        public int IdPodwozie { get; set; }
        public string Producent { get; set; }

        public ICollection<Gokart> Gokarty { get; set; }
    }
}