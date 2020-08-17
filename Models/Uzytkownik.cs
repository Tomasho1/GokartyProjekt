using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GokartyProjekt.Models
{
    public class Uzytkownik
    {
        public int IdUzytkownik { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }

        public Kierowca Kierowca { get; set; }
        public Pracownik Pracownik { get; set; }
    }
}
