using Projekat.Izuzeci;
using Projekat.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Projekat.services
{
    public class TreningService : ITreningService
    {
        public void ReadTrening(string filename)
        {
            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] tokens = line.Split(';');
                    Enum.TryParse(tokens[3], out EStatusTreninga statusTreninga);
                    Trening trening = new Trening()
                    {
                        Sifra = Int32.Parse(tokens[0]),
                        Datum = DateTime.Parse(tokens[1]),
                        TrajanjeTreninga = Int32.Parse(tokens[2]),
                        StatusTreninga = statusTreninga,
                        Trener = new TrenerService().NadjiTreneraPrekoEmaila(tokens[4]),
                        Klijent = new KlijentService().NadjiKlijentaPrekoEmaila(tokens[5]),
                        Aktivan = bool.Parse(tokens[6])
                    };
                    Main.Instance.Treninzi.Add(trening);
                }
            }
        }

        public void DeleteTrening(int sifra)
        {

            Trening trening = Main.Instance.Treninzi.ToList().Find(treninzi => treninzi.Sifra.Equals(sifra));
            if (trening == null)
            {
                throw new UserNotFoundException($"Ne postoji trening sa sifrom: {sifra}");
            }

            trening.Aktivan = false;
            MessageBox.Show("Uspesno obrisan", "Zauzet termin", MessageBoxButton.OK, MessageBoxImage.Information);

            Main.Instance.SacuvajEntitet("treninzi.txt");
        }
        public void SaveTrening(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Trening trening in Main.Instance.Treninzi)
                {
                    file.WriteLine(trening.TreningZaUpisUFajl());
                }
            }

        }
    }
}
