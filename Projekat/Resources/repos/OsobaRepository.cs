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
    class OsobaRepository
    {

        private JezikService jezikService = new JezikService();

        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * from Osoba";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Jezik jezik = jezikService.getJezikByID(reader.GetInt32(6));
                    Osoba osoba = new Osoba(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), jezik);
                    osoba.Obrisano = reader.GetBoolean(7);

                    OsobaManager.GetInstance().SveOsobe.Add(osoba);
                }

                conn.Close();
            }

        }

        public void Create(int osobaID, string ime, string prezime, string email, string adresa, string brKartice, Jezik osnovniJezik)
        {
            Osoba osoba = new Osoba(osobaID, ime, prezime, email, adresa, brKartice, osnovniJezik);
            OsobaManager.GetInstance().SveOsobe.Add(osoba);
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("INSERT INTO Osoba VALUES(@osobaID, @ime, @prezime, @email, @adresa, @brKartice, @osnovniJezik, @obrisano)", conn))
                {
                    cmd.Parameters.AddWithValue("@osobaID", osobaID);
                    cmd.Parameters.AddWithValue("@ime", ime);
                    cmd.Parameters.AddWithValue("@prezime", prezime);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@adresa", adresa);
                    cmd.Parameters.AddWithValue("@brKartice", brKartice);
                    cmd.Parameters.AddWithValue("@osnovniJezik", osnovniJezik.JezikID);
                    cmd.Parameters.AddWithValue("@obrisano", false);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int osobaID, string ime, string prezime, string email, string adresa, string brKartice, Jezik osnovniJezik)
        {
            Osoba osoba = OsobaManager.GetInstance().getOsobaById(osobaID);
            osoba.Ime = ime;
            osoba.Prezime = prezime;
            osoba.Email = email;
            osoba.Adresa = adresa;
            osoba.BrKartice = brKartice;
            osoba.OsnovniJezik = osnovniJezik;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Osoba SET Ime = @ime, Prezime = @prezime, Email = @email, Adresa = @adresa, BrKartice = @brKartice, OsnoviJezik = @osnovniJezik WHERE osobaID = @osobaID", conn))
                {
                    cmd.Parameters.AddWithValue("@osobaID", osobaID);
                    cmd.Parameters.AddWithValue("@ime", ime);
                    cmd.Parameters.AddWithValue("@prezime", prezime);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@adresa", adresa);
                    cmd.Parameters.AddWithValue("@brKartice", brKartice);
                    cmd.Parameters.AddWithValue("@osnovniJezik", osnovniJezik.JezikID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int osobaID)
        {
            Osoba osoba = OsobaManager.GetInstance().getOsobaById(osobaID);
            osoba.Obrisano = true;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Osoba SET Obrisano = 1 WHERE osobaID = @osobaID", conn))
                {
                    cmd.Parameters.AddWithValue("@osobaID", osobaID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

    }
}
