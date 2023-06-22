using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.managers
{
    class KorisnikManager
    {

        private static KorisnikManager instance;
        private ObservableCollection<Korisnik> sviKorisnici = new ObservableCollection<Korisnik>();

        public ObservableCollection<Korisnik> SviKorisnici { get => sviKorisnici; set => sviKorisnici = value; }

        public static KorisnikManager GetInstance()
        {
            if (instance == null) instance = new KorisnikManager();
            return instance;
        }

        public Korisnik getKorisnikById(int id)
        {
            Korisnik foundKorisnik = sviKorisnici.ToList().Find(x => x.KorisnikID == id);
            if (foundKorisnik == null)
            {
                throw new Exception("Korisnik nije pronadjen");
            }
            return foundKorisnik;
        }

    }
}
