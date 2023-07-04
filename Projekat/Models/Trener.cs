using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    [Serializable]
    public class Trener
    {
        private RegistrovaniKorisnik korisnik;

        public RegistrovaniKorisnik Korisnik
        {
            get { return korisnik; }
            set { korisnik = value; }
        }

        public override string ToString()
        {
            return korisnik.Ime + " " + korisnik.Prezime;
        }

        public string TrenerZaUpisUFajl()
        {
            return korisnik.Ime + ";" + korisnik.Prezime + ";" + korisnik.Email + ";" + korisnik.Telefon + ";" + korisnik.Adresa + ";" + korisnik.BrKartice + ";" + korisnik.OsnovniJezik + ";" + korisnik.DodatniJezik + ";" + korisnik.TipKorisnika + ";" + korisnik.Lozinka + ";" + korisnik.Cilj + ";" + korisnik.Aktivan;
        }
    }
}
