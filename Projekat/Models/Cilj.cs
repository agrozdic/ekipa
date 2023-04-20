using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    class Cilj
    {

        private int ciljID;
        private string naziv;
        private string opis;

        public int CiljID { get => ciljID; set => ciljID = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Opis { get => opis; set => opis = value; }

        public Cilj(int ciljID, string naziv, string opis)
        {
            this.CiljID = ciljID;
            this.Naziv = naziv;
            this.Opis = opis;
        }
    }
}