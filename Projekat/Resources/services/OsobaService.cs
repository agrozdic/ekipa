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
    class OsobaService
    {

        OsobaRepository repository;
        public OsobaService()
        {
            repository = new OsobaRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public ObservableCollection<Osoba> getOsobe()
        {
            try
            {
                ObservableCollection<Osoba> osobe = new ObservableCollection<Osoba>(OsobaManager.GetInstance().SveOsobe.Where(osoba => !(osoba.Obrisano)).ToList());
                return osobe;
            }
            catch (Exception exception)
            {
                return new ObservableCollection<Osoba>();
            }
        }

        public Osoba getOsobaByID(int osobaID)
        {
            try
            {
                Osoba osoba = OsobaManager.GetInstance().getOsobaById(osobaID);
                return osoba;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen osoba.");
                return null;
            }
        }

        public void CreateOsoba(int osobaID, string ime, string prezime, string email, string adresa, string brKartice, Jezik osnovniJezik)
        {
            repository.Create(osobaID, ime, prezime, email, adresa, brKartice, osnovniJezik);
        }

        public void UpdateOsoba(int osobaID, string ime, string prezime, string email, string adresa, string brKartice, Jezik osnovniJezik)
        {
            repository.Update(osobaID, ime, prezime, email, adresa, brKartice, osnovniJezik);
        }

        public void DeleteOsoba(int osobaID)
        {
            repository.Delete(osobaID);
        }

    }
}
