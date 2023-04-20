using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.Models
{
    class Klijent
    {

		private int klijentID;
		private Osoba osoba;
		private float visina;
		private float tezina;
		private string zdrStanje;
        private List<Rekvizit> listaRekvizita;
        private List<Cilj> listaCiljeva;

        public int KlijentID { get => klijentID; set => klijentID = value; }
        public float Visina { get => visina; set => visina = value; }
        public float Tezina { get => tezina; set => tezina = value; }
        public string ZdrStanje { get => zdrStanje; set => zdrStanje = value; }
        internal Osoba Osoba { get => osoba; set => osoba = value; }
        internal List<Rekvizit> ListaRekvizita { get => listaRekvizita; set => listaRekvizita = value; }
        internal List<Cilj> ListaCiljeva { get => listaCiljeva; set => listaCiljeva = value; }

        public Klijent(int klijentID, Osoba osoba, float visina, float tezina, string zdrStanje, List<Rekvizit> listaRekvizita, List<Cilj> listaCiljeva)
        {
            this.KlijentID = klijentID;
            this.Osoba = osoba;
            this.Visina = visina;
            this.Tezina = tezina;
            this.ZdrStanje = zdrStanje;
            this.ListaRekvizita = listaRekvizita;
            this.ListaCiljeva = listaCiljeva;
        }

    }
}
