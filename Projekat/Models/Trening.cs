using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    class Trening
    {

		private int treningID;
		private Klijent klijent;
		private Trener trener;
		private Termin termin;
		private string plan;
		private int ocenaKlijenta;
		private int ocenaTrenera;

        public int TreningID { get => treningID; set => treningID = value; }
        public string Plan { get => plan; set => plan = value; }
        public int OcenaKlijenta { get => ocenaKlijenta; set => ocenaKlijenta = value; }
        public int OcenaTrenera { get => ocenaTrenera; set => ocenaTrenera = value; }
        internal Klijent Klijent { get => klijent; set => klijent = value; }
        internal Trener Trener { get => trener; set => trener = value; }
        internal Termin Termin { get => termin; set => termin = value; }

        public Trening(int treningID, Klijent klijent, Trener trener, Termin termin, string plan, int ocenaKlijenta, int ocenaTrenera)
        {
            this.TreningID = treningID;
            this.Klijent = klijent;
            this.Trener = trener;
            this.Termin = termin;
            this.Plan = plan;
            this.OcenaKlijenta = ocenaKlijenta;
            this.OcenaTrenera = ocenaTrenera;
        }
    }
}
