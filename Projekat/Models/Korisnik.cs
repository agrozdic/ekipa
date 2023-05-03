using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    class Korisnik
    {

		private string korisnikID;
		private Osoba osoba;
		private string korisnickoIme;
		private string lozinka;
        private bool obrisano;

        public string KorisnikID { get => korisnikID; set => korisnikID = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        internal Osoba Osoba { get => osoba; set => osoba = value; }
        public bool Obrisano { get => obrisano; set => obrisano = value; }

        public Korisnik(string korisnikID, Osoba osoba, string korisnickoIme, string lozinka)
        {
            this.KorisnikID = korisnikID;
            this.Osoba = osoba;
            this.KorisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
            this.Obrisano = false;
        }
    }
}