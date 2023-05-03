using Projekat.Models;
using Projekat.resources.managers;
using Projekat.resources.repos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.services
{
    class KorisnikService
    {

        KorisnikRepository repository;
        public KorisnikService()
        {
            repository = new KorisnikRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public ObservableCollection<Korisnik> getKorisnici()
        {
            try
            {
                ObservableCollection<Korisnik> korisnici = new ObservableCollection<Korisnik>(KorisnikManager.GetInstance().SviKorisnici.Where(osoba => !(osoba.Obrisano)).ToList());
                return korisnici;
            }
            catch (Exception exception)
            {
                return new ObservableCollection<Korisnik>();
            }
        }

        public Korisnik getKorisnikByID(int osobaID)
        {
            try
            {
                Korisnik osoba = KorisnikManager.GetInstance().getKorisnikById(osobaID);
                return osoba;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen korisnik.");
                return null;
            }
        }

        public void CreateKorisnik(int korisnikID, Osoba osoba, string korisnickoIme, string lozinka)
        {
            repository.Create(korisnikID, osoba, korisnickoIme, lozinka);
        }

        public void UpdateKorisnik(int korisnikID, string korisnickoIme, string lozinka)
        {
            repository.Update(korisnikID, korisnickoIme, lozinka);
        }

        public void DeleteKorisnik(int korisnikID)
        {
            repository.Delete(korisnikID);
        }

    }
}
