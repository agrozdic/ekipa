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
    class JezikService
    {

        JezikRepository repository;
        public JezikService()
        {
            repository = new JezikRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public ObservableCollection<Jezik> getJezici()
        {
            try
            {
                ObservableCollection<Jezik> jezici = new ObservableCollection<Jezik>(JezikManager.GetInstance().SviJezici.Where(jezik => !(jezik.Obrisano)).ToList());
                return jezici;
            }
            catch (Exception exception)
            {
                return new ObservableCollection<Jezik>();
            }
        }

        public Jezik getJezikByID(int jezikID)
        {
            try
            {
                Jezik jezik = JezikManager.GetInstance().getJezikById(jezikID);
                return jezik;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen jezik.");
                return null;
            }
        }

        public Jezik GetJezikByName(string naziv)
        {
            try
            {
                Jezik jezik = JezikManager.GetInstance().getJezikByName(naziv);
                return jezik;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Nije pronadjen jezik.");
                return null;
            }
        }

        public void CreateJezik(int jezikID, string naziv)
        {
            repository.Create(jezikID, naziv);
        }

        public void UpdateJezik(int jezikID, string naziv)
        {
            repository.Update(jezikID, naziv);
        }

        public void DeleteJezik(int jezikID)
        {
            repository.Delete(jezikID);
        }

    }
}
