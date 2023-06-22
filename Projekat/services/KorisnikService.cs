using Projekat.Izuzeci;
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
    public class KorisnikService : IKorisnikService
    {
        public void DeleteUser(string email)
        {

            Korisnik Korisnik = Main.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(email));
            if (korisnik == null)
            {
                throw new UserNotFoundException($"Ne postoji korisnik sa emailom: {email}");
            }

            korisnik.Aktivan = false;
            Console.WriteLine("Uspesno obrisan korisnik sa emailom:" + email);


            Main.Instance.SacuvajEntitet("korisnici.txt");
        }

        public void ReadUsers(string filename)
        {
            Main.Instance.Korisnici = new ObservableCollection<Korisnik>();

            using (StreamReader file = new StreamReader(@"../../Resources/" + filename))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');

                    Enum.TryParse(korisnikIzFajla[8], out ETipKorisnika tip);
                    Enum.TryParse(korisnikIzFajla[10], out ECilj cilj);
                    Boolean.TryParse(korisnikIzFajla[11], out Boolean status);
                    Korisnik korisnik = new Korisnik
                    {

                        Ime = korisnikIzFajla[0],
                        Prezime = korisnikIzFajla[1],
                        Email = korisnikIzFajla[2],
                        Telefon = korisnikIzFajla[3],
                        Adresa = korisnikIzFajla[4],
                        BrKartice = korisnikIzFajla[5],
                        OsnovniJezik = korisnikIzFajla[6],
                        DodatniJezik = korisnikIzFajla[7],
                        TipKorisnika = tip,
                        Lozinka = korisnikIzFajla[9],
                        Cilj = cilj,
                        Aktivan = status
                    };

                    Main.Instance.Korisnici.Add(korisnik);
                }
            }
        }

        public void SaveUsers(string filename)
        {
            using (StreamWriter file = new StreamWriter(@"../../Resources/" + filename))
            {
                foreach (Korisnik korisnik in Main.Instance.Korisnici)
                {
                    file.WriteLine(korisnik.KorisnikZaUpisUFajl());
                }
            }
        }
    }
}
