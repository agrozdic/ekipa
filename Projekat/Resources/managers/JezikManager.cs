using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.managers
{
    class JezikManager
    {

        private static JezikManager instance;
        private ObservableCollection<Jezik> sviJezici = new ObservableCollection<Jezik>();

        public ObservableCollection<Jezik> SviJezici { get => sviJezici; set => sviJezici = value; }

        public static JezikManager GetInstance()
        {
            if (instance == null) instance = new JezikManager();
            return instance;
        }

        public Jezik getJezikById(int id)
        {
            Jezik foundJezik = sviJezici.ToList().Find(x => x.JezikID == id);
            if (foundJezik == null)
            {
                throw new Exception("Jezik nije pronadjen");
            }
            return foundJezik;
        }

        public Jezik getJezikByName(string name)
        {

            Jezik foundJezik = sviJezici.ToList().Find(x => x.Naziv == name);
            if (foundJezik == null)
            {
                throw new Exception("Nije pronadjen jezik.");
            }
            return foundJezik;
        }
    }
}
