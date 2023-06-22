using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    [Serializable]
    public class Trening
    {
        public Trening() { }

        private int _sifra;

        public int Sifra
        {
            get { return _sifra; }
            set { _sifra = value; }
        }

        private DateTime dateTime;

        public DateTime Datum
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        private int _trajanjeTreninga;

        public int TrajanjeTreninga
        {
            get { return _trajanjeTreninga; }
            set { _trajanjeTreninga = value; }
        }

        private EStatusTreninga _statusTreninga;

        public EStatusTreninga StatusTreninga
        {
            get { return _statusTreninga; }
            set { _statusTreninga = value; }
        }

        private Trener _trener;

        public Trener Trener
        {
            get { return _trener; }
            set { _trener = value; }
        }

        private Klijent _klijent;

        public Klijent Klijent
        {
            get { return _klijent; }
            set { _klijent = value; }
        }

        private bool _aktivan;

        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }

        public string TreningZaUpisUFajl()
        {
            if(Klijent == null)
                return Sifra + ";" + Datum + ";" + TrajanjeTreninga + ";" + StatusTreninga + ";" + Trener.Korisnik.Email + ";" + "NijeZakazan" + ";" + Aktivan;
            else
                return Sifra + ";" + Datum + ";" + TrajanjeTreninga + ";" + StatusTreninga + ";" + Trener.Korisnik.Email + ";" + Klijent.Korisnik.Email + ";" + Aktivan;
        }
    }
}
