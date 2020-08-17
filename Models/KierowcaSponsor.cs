using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class KierowcaSponsor
    {
        public int IdKierowca { get; set; }
        public int IdSponsor { get; set; }

        public Kierowca Kierowca { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}