using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    class Rekvizit
    {

        private int rekvizitID;
        private string naziv;
        private string opis;

        public int RekvizitID { get => rekvizitID; set => rekvizitID = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public string Opis { get => opis; set => opis = value; }

        public Rekvizit(int rekvizitID, string naziv, string opis)
        {
            this.RekvizitID = rekvizitID;
            this.Naziv = naziv;
            this.Opis = opis;
        }
    }
}