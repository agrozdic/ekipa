using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    class Osoba{

		private int osobaID;
		private string ime;
		private string prezime;
		private string email;
		private string adresa;
		private string brKartice;
		private Jezik osnovniJezik;
		private List<Jezik> listaDodatnihJezika;

		public int OsobaID { get => osobaID; set => osobaID = value; }
		public string Ime { get => ime; set => ime = value; }
		public string Prezime { get => prezime; set => prezime = value; }
		public string Email { get => email; set => email = value; }
		public string Adresa { get => adresa; set => adresa = value; }
		public string BrKartice { get => brKartice; set => brKartice = value; }
		public Jezik OsnovniJezik { get => osnovniJezik; set => osnovniJezik = value; }
        internal List<Jezik> ListaDodatnihJezika { get => listaDodatnihJezika; set => listaDodatnihJezika = value; }

        public Osoba(int osobaID, string ime, string prezime, string email, string adresa, string brKartice, Jezik osnovniJezik, List<Jezik> listaDodatnihJezika)
        {
            this.osobaID = osobaID;
            this.ime = ime;
            this.prezime = prezime;
            this.email = email;
            this.adresa = adresa;
            this.brKartice = brKartice;
            this.osnovniJezik = osnovniJezik;
            this.listaDodatnihJezika = listaDodatnihJezika;
        }
    }
}