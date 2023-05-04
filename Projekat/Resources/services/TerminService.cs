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
    class TerminService
    {

        TerminRepository repository;
        public TerminService()
        {
            repository = new TerminRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public ObservableCollection<Termin> getTermini()
        {
            try
            {
                ObservableCollection<Termin> termini = new ObservableCollection<Termin>(TerminManager.GetInstance().SviTermini.Where(termin => !(termin.Obrisano)).ToList());
                return termini;
            }
            catch (Exception exception)
            {
                return new ObservableCollection<Termin>();
            }
        }

        public Termin getTerminByID(int terminID)
        {
            try
            {
                Termin termin = TerminManager.GetInstance().getTerminById(terminID);
                return termin;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen termin.");
                return null;
            }
        }

        public void CreateTermin(int terminID, Trener trener, DateTime datum, TimeSpan vreme, bool slobodan)
        {
            repository.Create(terminID, trener, datum, vreme, slobodan);
        }

        public void UpdateTermin(int terminID, DateTime datum, TimeSpan vreme, bool slobodan)
        {
            repository.Update(terminID, datum, vreme, slobodan);
        }

        public void DeleteTermin(int terminID)
        {
            repository.Delete(terminID);
        }

    }
}
