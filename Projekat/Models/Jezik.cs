using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    class Jezik
    {

        private int jezikID;
        private string naziv;
        private bool obrisano;

        public int JezikID { get => jezikID; set => jezikID = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public bool Obrisano { get => obrisano; set => obrisano = value; }

        public Jezik(int jezikID, string naziv)
        {
            this.JezikID = jezikID;
            this.Naziv = naziv;
            this.Obrisano = false;
        }

    }
}