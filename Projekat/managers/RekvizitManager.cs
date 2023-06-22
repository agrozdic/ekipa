using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.managers
{
    class RekvizitManager
    {

        private static RekvizitManager instance;
        private ObservableCollection<Rekvizit> sviRekviziti = new ObservableCollection<Rekvizit>();

        public ObservableCollection<Rekvizit> SviRekviziti { get => sviRekviziti; set => sviRekviziti = value; }

        public static RekvizitManager GetInstance()
        {
            if (instance == null) instance = new RekvizitManager();
            return instance;
        }

        public Rekvizit getRekvizitById(int id)
        {
            Rekvizit foundRekvizit = sviRekviziti.ToList().Find(x => x.RekvizitID == id);
            if (foundRekvizit == null)
            {
                throw new Exception("Rekvizit nije pronadjen");
            }
            return foundRekvizit;
        }

        public Rekvizit getRekvizitByName(string name)
        {

            Rekvizit foundRekvizit = sviRekviziti.ToList().Find(x => x.Naziv == name);
            if (foundRekvizit == null)
            {
                throw new Exception("Nije pronadjen rekvizit.");
            }
            return foundRekvizit;
        }
    }
}
