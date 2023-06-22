using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    public class Rekviziti
    {
        private string _naziv;

        public string naziv
        {
            get { return _naziv; }
            set { _naziv = value; }
        }

        private string _primena;

        public string Primena
        {
            get { return _primena; }
            set { _primena = value; }
        }
    }
}
