using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.DTOs.Requests
{
    public class AddNewLapTimeRequest
    {
        public String Czas { get; set; }
        public DateTime DataPrzejazdu { get; set; }
        public int IdTor { get; set; }
        public int IdGokart { get; set; }
        public int IdKierowca { get; set; }

    }
}
