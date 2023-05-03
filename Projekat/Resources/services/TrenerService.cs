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
    class TrenerService
    {

        TrenerRepository repository;
        public TrenerService()
        {
            repository = new TrenerRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public ObservableCollection<Trener> getTreneri()
        {
            try
            {
                ObservableCollection<Trener> treneri = new ObservableCollection<Trener>(TrenerManager.GetInstance().SviTreneri.Where(osoba => !(osoba.Obrisano)).ToList());
                return treneri;
            }
            catch (Exception exception)
            {
                return new ObservableCollection<Trener>();
            }
        }

        public Trener getTrenerByID(int osobaID)
        {
            try
            {
                Trener osoba = TrenerManager.GetInstance().getTrenerById(osobaID);
                return osoba;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen trener.");
                return null;
            }
        }

        public void CreateTrener(int trenerID, Osoba osoba, string diploma, string sertifikat, string zvanje)
        {
            repository.Create(trenerID, osoba, diploma, sertifikat, zvanje);
        }

        public void UpdateTrener(int trenerID, string diploma, string sertifikat, string zvanje)
        {
            repository.Update(trenerID, diploma, sertifikat, zvanje);
        }

        public void DeleteTrener(int trenerID)
        {
            repository.Delete(trenerID);
        }

    }
}
