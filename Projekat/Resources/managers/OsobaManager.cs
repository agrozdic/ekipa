using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.managers
{
    class OsobaManager
    {
        private static OsobaManager instance;
        private ObservableCollection<Osoba> sveOsobe = new ObservableCollection<Osoba>();

        public ObservableCollection<Osoba> SveOsobe { get => sveOsobe; set => sveOsobe = value; }

        public static OsobaManager GetInstance()
        {
            if (instance == null) instance = new OsobaManager();
            return instance;
        }

        public Osoba getOsobaById(int id)
        {
            Osoba foundOsoba = sveOsobe.ToList().Find(x => x.OsobaID == id);
            if (foundOsoba == null)
            {
                throw new Exception("Osoba nije pronadjena");
            }
            return foundOsoba;
        }
    }
}
