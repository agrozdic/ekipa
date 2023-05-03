using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    class Trener
    {

		private int trenerID;
		private Osoba osoba;
		private string diploma;
		private string sertifikat;
		private string zvanje;
        private bool obrisano;

        public int TrenerID { get => trenerID; set => trenerID = value; }
        public string Diploma { get => diploma; set => diploma = value; }
        public string Sertifikat { get => sertifikat; set => sertifikat = value; }
        public string Zvanje { get => zvanje; set => zvanje = value; }
        internal Osoba Osoba { get => osoba; set => osoba = value; }
        public bool Obrisano { get => obrisano; set => obrisano = value; }

        public Trener(int trenerID, Osoba osoba, string diploma, string sertifikat, string zvanje)
        {
            this.TrenerID = trenerID;
            this.Osoba = osoba;
            this.Diploma = diploma;
            this.Sertifikat = sertifikat;
            this.Zvanje = zvanje;
            this.Obrisano = false;
        }
    }
}