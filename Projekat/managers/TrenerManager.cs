using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.managers
{
    class TrenerManager
    {

        private static TrenerManager instance;
        private ObservableCollection<Trener> sviTreneri = new ObservableCollection<Trener>();

        public ObservableCollection<Trener> SviTreneri { get => sviTreneri; set => sviTreneri = value; }

        public static TrenerManager GetInstance()
        {
            if (instance == null) instance = new TrenerManager();
            return instance;
        }

        public Trener getTrenerById(int id)
        {
            Trener foundTrener = sviTreneri.ToList().Find(x => x.TrenerID == id);
            if (foundTrener == null)
            {
                throw new Exception("Trener nije pronadjen");
            }
            return foundTrener;
        }

    }
}
