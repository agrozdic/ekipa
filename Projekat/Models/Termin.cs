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
		private DateTime datumVreme;
		private bool slobodan;

        public int TerminID { get => terminID; set => terminID = value; }
        public DateTime DatumVreme { get => datumVreme; set => datumVreme = value; }
        public bool Slobodan { get => slobodan; set => slobodan = value; }
        internal Trener Trener { get => trener; set => trener = value; }

        public Termin(int terminID, Trener trener, DateTime datumVreme, bool slobodan)
        {
            this.TerminID = terminID;
            this.Trener = trener;
            this.DatumVreme = datumVreme;
            this.Slobodan = slobodan;
        }
    }
}