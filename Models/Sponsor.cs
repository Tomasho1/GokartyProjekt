using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Sponsor
    {
        public int IdSponsor { get; set; }
        public string Nazwa { get; set; }

        public ICollection<KierowcaSponsor> KierowcaSponsor { get; set; }
    }
}