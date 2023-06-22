using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    public class Vlasnik
    {
        private string _zaradaInterval;

        public string zaradaInterval
        {
            get { return _zaradaInterval; }
            set { _zaradaInterval = value; }
        }

        private string _dnevnaZarada;

        public string dnevnaZarada
        {
            get { return _dnevnaZarada; }
            set { _dnevnaZarada = value; }
        }

        private string _nedeljnaZarada;

        public string nedeljnaZarada
        {
            get { return _nedeljnaZarada; }
            set { _nedeljnaZarada = value; }
        }

        private string _mesecnaZarada;

        public string mesecnaZarada
        {
            get { return _mesecnaZarada; }
            set { _mesecnaZarada = value; }
        }

        private string _najboljiTrener;

        public string najboljiTrener
        {
            get { return _najboljiTrener; }
            set { _najboljiTrener = value; }
        }




    }


}
