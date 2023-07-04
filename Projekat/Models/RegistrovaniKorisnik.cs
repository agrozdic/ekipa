using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    public class RegistrovaniKorisnik
    {
        private string _ime;

        public string Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }

        private string _prezime;

        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _telefon;

        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }

        private string _adresa;

        public string Adresa
        {
            get { return _adresa; }
            set { _adresa = value; }
        }

        private string _brKartice;

        public string BrKartice
        {
            get { return _brKartice; }
            set { _brKartice = value; }
        }

        private string _osnovniJezik;

        public string OsnovniJezik
        {
            get { return _osnovniJezik; }
            set { _osnovniJezik = value; }
        }

        private string _dodatniJezik;

        public string DodatniJezik
        {
            get { return _dodatniJezik; }
            set { _dodatniJezik = value; }
        }

        private ETipKorisnika _tipKorisnika;

        public ETipKorisnika TipKorisnika
        {
            get { return _tipKorisnika; }
            set { _tipKorisnika = value; }
        }

        private ECilj _ciljKlijenta;

        public ECilj Cilj
        {
            get { return _ciljKlijenta; }
            set { _ciljKlijenta = value; }
        }

        private string _lozinka;

        public string Lozinka
        {
            get { return _lozinka; }
            set { _lozinka = value; }
        }

        private bool _aktivan;

        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }

        public RegistrovaniKorisnik() { }

        public override string ToString()
        {
            return "Ja sam " + Ime + " " + Prezime + " tip " + TipKorisnika + " moj email je: " + Email;
        }

        public string KorisnikZaUpisUFajl()
        {
            return Ime + ";" + Prezime + ";" + Email + ";" + Telefon + ";" + Adresa + ";" + BrKartice + ";" + OsnovniJezik + ";" + DodatniJezik + ";" + TipKorisnika + ";" + Lozinka + ";" + Cilj + ";" + Aktivan;
        }

        public RegistrovaniKorisnik Clone()
        {
            RegistrovaniKorisnik kopija = new RegistrovaniKorisnik();
            kopija.Ime = Ime;
            kopija.Prezime = Prezime;
            kopija.Email = Email;
            kopija.Adresa = Adresa;
            kopija.BrKartice = BrKartice;
            kopija.OsnovniJezik = OsnovniJezik;
            kopija.DodatniJezik = DodatniJezik;
            kopija.TipKorisnika = TipKorisnika;
            kopija.Cilj = Cilj;
            kopija.Lozinka = Lozinka;
            kopija.Aktivan = Aktivan;

            return kopija;
        }
    }
}
