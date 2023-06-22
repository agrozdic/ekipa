using Projekat.Models;
using Projekat.resources.managers;
using Projekat.resources.services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.repos
{
    class KorisnikRepository
    {

        private OsobaService osobaService = new OsobaService();

        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * from Korisnik";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Osoba osoba = osobaService.getOsobaByID(reader.GetInt32(1));
                    Korisnik korisnik = new Korisnik(reader.GetInt32(0), osoba, reader.GetString(2), reader.GetString(3));
                    korisnik.Obrisano = reader.GetBoolean(4);

                    KorisnikManager.GetInstance().SviKorisnici.Add(korisnik);
                }

                conn.Close();
            }

        }

        public void Create(int korisnikID, Osoba osoba, string korisnickoIme, string lozinka)
        {
            Korisnik korisnik = new Korisnik(korisnikID, osoba, korisnickoIme, lozinka);
            KorisnikManager.GetInstance().SviKorisnici.Add(korisnik);
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("INSERT INTO Korisnik VALUES(@korisnikID, @osoba, @korisnickoIme, @lozinka, @obrisano)", conn))
                {
                    cmd.Parameters.AddWithValue("@korisnikID", korisnikID);
                    cmd.Parameters.AddWithValue("@osoba", osoba.OsobaID);
                    cmd.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                    cmd.Parameters.AddWithValue("@lozinka", lozinka);
                    cmd.Parameters.AddWithValue("@obrisano", false);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int korisnikID, string korisnickoIme, string lozinka)
        {
            Korisnik korisnik = KorisnikManager.GetInstance().getKorisnikById(korisnikID);
            korisnik.KorisnickoIme = korisnickoIme;
            korisnik.Lozinka = lozinka;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Korisnik SET KorisnickoIme = @korisnickoIme, Lozinka = @lozinka WHERE KorisnikID = @korisnikID", conn))
                {
                    cmd.Parameters.AddWithValue("@korisnikID", korisnikID);
                    cmd.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
                    cmd.Parameters.AddWithValue("@lozinka", lozinka);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int korisnikID)
        {
            Korisnik korisnik = KorisnikManager.GetInstance().getKorisnikById(korisnikID);
            korisnik.Obrisano = true;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Korisnik SET Obrisano = 1 WHERE korisnikID = @korisnikID", conn))
                {
                    cmd.Parameters.AddWithValue("@korisnikID", korisnikID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

    }
}
