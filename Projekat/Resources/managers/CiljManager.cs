using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.managers
{
    class CiljManager
    {

        private static CiljManager instance;
        private ObservableCollection<Cilj> sviCiljevi = new ObservableCollection<Cilj>();

        public ObservableCollection<Cilj> SviCiljevi { get => sviCiljevi; set => sviCiljevi = value; }

        public static CiljManager GetInstance()
        {
            if (instance == null) instance = new CiljManager();
            return instance;
        }

        public Cilj getCiljById(int id)
        {
            Cilj foundCilj = sviCiljevi.ToList().Find(x => x.CiljID == id);
            if (foundCilj == null)
            {
                throw new Exception("Cilj nije pronadjen");
            }
            return foundCilj;
        }

        public Cilj getCiljByName(string name)
        {

            Cilj foundCilj = sviCiljevi.ToList().Find(x => x.Naziv == name);
            if (foundCilj == null)
            {
                throw new Exception("Nije pronadjen cilj.");
            }
            return foundCilj;
        }
    }
}
