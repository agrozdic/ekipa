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
    class CiljService
    {

        CiljRepository repository;
        public CiljService()
        {
            repository = new CiljRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public ObservableCollection<Cilj> getCiljevi()
        {
            try
            {
                ObservableCollection<Cilj> ciljevi = new ObservableCollection<Cilj>(CiljManager.GetInstance().SviCiljevi.Where(cilj => !(cilj.Obrisano)).ToList());
                return ciljevi;
            }
            catch (Exception exception)
            {
                return new ObservableCollection<Cilj>();
            }
        }

        public Cilj getCiljByID(int ciljID)
        {
            try
            {
                Cilj cilj = CiljManager.GetInstance().getCiljById(ciljID);
                return cilj;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen cilj.");
                return null;
            }
        }

        public Cilj GetCiljByName(string naziv)
        {
            try
            {
                Cilj cilj = CiljManager.GetInstance().getCiljByName(naziv);
                return cilj;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen cilj.");
                return null;
            }
        }

        public void CreateCilj(int ciljID, string naziv, string opis)
        {
            repository.Create(ciljID, naziv, opis);
        }

        public void UpdateCilj(int ciljID, string naziv, string opis)
        {
            repository.Update(ciljID, naziv, opis);
        }

        public void DeleteCilj(int ciljID)
        {
            repository.Delete(ciljID);
        }

    }
}
