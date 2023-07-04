using Projekat.services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    public sealed class Main
    {
        private static readonly Main instance = new Main();
        private IKorisnikService korisnikService;
        private ITrenerService trenerService;
        private IKlijentService klijentService;
        private ITreningService treningService;

        public ObservableCollection<RegistrovaniKorisnik> Korisnici { get; set; }
        public ObservableCollection<Trener> Treneri { get; set; }
        public ObservableCollection<Klijent> Klijenti { get; set; }
        public ObservableCollection<Trening> Treninzi { get; set; }

        private Main()
        {
            korisnikService = new KorisnikService();
            trenerService = new TrenerService();
            klijentService = new KlijentService();
            treningService = new TreningService();
        }

        static Main() { }

        public static Main Instance
        {
            get
            {
                return instance;
            }
        }

        public void Initialize()
        {

            Korisnici = new ObservableCollection<RegistrovaniKorisnik>();
            Treneri = new ObservableCollection<Trener>();
            Klijenti = new ObservableCollection<Klijent>();
            Treninzi = new ObservableCollection<Trening>();

        }

        public RegistrovaniKorisnik Login(string email, string lozinka)
        {
            foreach (RegistrovaniKorisnik korisnik in Korisnici)
            {
                if (korisnik.Email.Equals(email) && korisnik.Lozinka.Equals(lozinka))
                {
                    return korisnik;
                }
            }
            return null;
        }

        public void SacuvajEntitet(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                korisnikService.SaveUsers(filename);
            }
            else if (filename.Contains("treneri"))
            {
                trenerService.SaveUsers(filename);
            }
            else if (filename.Contains("klijenti"))
            {
                klijentService.SaveUsers(filename);
            }
            else
            {
                treningService.SaveTrening(filename);
            }
        }

        public void CitanjeEntiteta(string filename)
        {
            if (filename.Contains("korisnici"))
            {
                korisnikService.ReadUsers(filename);
            }
            else if (filename.Contains("treneri"))
            {
                trenerService.ReadUsers(filename);
            }
            else if (filename.Contains("klijenti"))
            {
                klijentService.ReadUsers(filename);
            }
            else
            {
                treningService.ReadTrening(filename);
            }
        }

        public void DeleteUser(string email)
        {
            korisnikService.DeleteUser(email);
        }

        public void DeleteTrening(int sifra)
        {
            treningService.DeleteTrening(sifra);
        }
    }
}
