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

        public int JezikID { get => JezikID; set => JezikID = value; }
        public string Naziv { get => naziv; set => naziv = value; }

        public Jezik(int jezikID, string naziv)
        {
            this.JezikID = jezikID;
            this.Naziv = naziv;
        }

    }
}