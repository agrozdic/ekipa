using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.managers
{
    class TerminManager
    {

        private static TerminManager instance;
        private ObservableCollection<Termin> sviTermini = new ObservableCollection<Termin>();

        public ObservableCollection<Termin> SviTermini { get => sviTermini; set => sviTermini = value; }

        public static TerminManager GetInstance()
        {
            if (instance == null) instance = new TerminManager();
            return instance;
        }

        public Termin getTerminById(int id)
        {
            Termin foundTermin = sviTermini.ToList().Find(x => x.TerminID == id);
            if (foundTermin == null)
            {
                throw new Exception("Termin nije pronadjen");
            }
            return foundTermin;
        }
    }
}
