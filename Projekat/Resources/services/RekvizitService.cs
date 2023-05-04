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
    class RekvizitService
    {

        RekvizitRepository repository;
        public RekvizitService()
        {
            repository = new RekvizitRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public ObservableCollection<Rekvizit> getRekviziti()
        {
            try
            {
                ObservableCollection<Rekvizit> rekviziti = new ObservableCollection<Rekvizit>(RekvizitManager.GetInstance().SviRekviziti.Where(rekvizit => !(rekvizit.Obrisano)).ToList());
                return rekviziti;
            }
            catch (Exception exception)
            {
                return new ObservableCollection<Rekvizit>();
            }
        }

        public Rekvizit getRekvizitByID(int rekvizitID)
        {
            try
            {
                Rekvizit rekvizit = RekvizitManager.GetInstance().getRekvizitById(rekvizitID);
                return rekvizit;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen rekvizit.");
                return null;
            }
        }

        public Rekvizit GetRekvizitByName(string naziv)
        {
            try
            {
                Rekvizit rekvizit = RekvizitManager.GetInstance().getRekvizitByName(naziv);
                return rekvizit;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen rekvizit.");
                return null;
            }
        }

        public void CreateRekvizit(int rekvizitID, string naziv, string opis)
        {
            repository.Create(rekvizitID, naziv, opis);
        }

        public void UpdateRekvizit(int rekvizitID, string naziv, string opis)
        {
            repository.Update(rekvizitID, naziv, opis);
        }

        public void DeleteRekvizit(int rekvizitID)
        {
            repository.Delete(rekvizitID);
        }

    }
}