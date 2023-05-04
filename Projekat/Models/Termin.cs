using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    class Termin
    {

		private int terminID;
		private Trener trener;
		private DateTime datum;
        private TimeSpan vreme;
		private bool slobodan;
        private bool obrisano;

        public int TerminID { get => terminID; set => terminID = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public TimeSpan Vreme { get => vreme; set => vreme = value; }
        public bool Slobodan { get => slobodan; set => slobodan = value; }
        internal Trener Trener { get => trener; set => trener = value; }
        public bool Obrisano { get => obrisano; set => obrisano = value; }

        public Termin(int terminID, Trener trener, DateTime datum, TimeSpan vreme, bool slobodan)
        {
            this.TerminID = terminID;
            this.Trener = trener;
            this.Datum = datum;
            this.Vreme = vreme;
            this.Slobodan = slobodan;
            this.Obrisano = false;
        }
    }
}