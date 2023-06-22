using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.services
{
    public class KlijentService : IKlijentService
    {
        public List<Korisnik> FindallClients(string email)
        {
            throw new NotImplementedException();
        }

        public Klijent NadjiKlijentaPrekoEmaila(string email)
        {
            foreach (Klijent klijent in Main.Instance.Klijenti)
            {
                if (email.Equals(klijent.Korisnik.Email))
                    return klijent;
            }
            return null;
        }
        public void ReadUsers(string filename)
        {
            Main.Instance.Klijenti = new ObservableCollection<Klijent>();

            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] klijentIzFajla = line.Split(';');
                    Korisnik korisnik = Main.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(klijentIzFajla[2]));

                    Klijent klijent = new Klijent
                    {

                        Korisnik = korisnik,

                    };

                    Main.Instance.Klijenti.Add(klijent);
                }
            }
        }
        public void SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Klijent klijent in Main.Instance.Klijenti)
                {
                    file.WriteLine(klijent.KlijentZaUpisUFajl());
                }
            }
        }

    }
}
