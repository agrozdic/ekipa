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
    class TrenerRepository
    {

        private OsobaService osobaService = new OsobaService();

        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * from Trener";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Osoba osoba = osobaService.getOsobaByID(reader.GetInt32(1));
                    Trener trener = new Trener(reader.GetInt32(0), osoba, reader.GetString(2), reader.GetString(3), reader.GetString(4));
                    trener.Obrisano = reader.GetBoolean(5);

                    TrenerManager.GetInstance().SviTreneri.Add(trener);
                }

                conn.Close();
            }

        }

        //int trenerID, Osoba osoba, string diploma, string sertifikat, string zvanje
        public void Create(int trenerID, Osoba osoba, string diploma, string sertifikat, string zvanje)
        {
            Trener trener = new Trener(trenerID, osoba, diploma, sertifikat, zvanje);
            TrenerManager.GetInstance().SviTreneri.Add(trener);
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("INSERT INTO Trener VALUES(@trenerID, @osoba, @diploma, @sertifikat, @zvanje, @obrisano)", conn))
                {
                    cmd.Parameters.AddWithValue("@trenerID", trenerID);
                    cmd.Parameters.AddWithValue("@osoba", osoba.OsobaID);
                    cmd.Parameters.AddWithValue("@diploma", diploma);
                    cmd.Parameters.AddWithValue("@sertifikat", sertifikat);
                    cmd.Parameters.AddWithValue("@zvanje", zvanje);
                    cmd.Parameters.AddWithValue("@obrisano", false);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int trenerID, string diploma, string sertifikat, string zvanje)
        {
            Trener trener = TrenerManager.GetInstance().getTrenerById(trenerID);
            trener.Diploma = diploma;
            trener.Sertifikat = sertifikat;
            trener.Zvanje = zvanje;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Trener SET Diploma = @diploma, Sertifikat = @sertifikat, Zvanje = @Zvanje WHERE TrenerID = @trenerID", conn))
                {
                    cmd.Parameters.AddWithValue("@trenerID", trenerID);
                    cmd.Parameters.AddWithValue("@diploma", diploma);
                    cmd.Parameters.AddWithValue("@sertifikat", sertifikat);
                    cmd.Parameters.AddWithValue("@zvanje", zvanje);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int trenerID)
        {
            Trener trener = TrenerManager.GetInstance().getTrenerById(trenerID);
            trener.Obrisano = true;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Trener SET Obrisano = 1 WHERE trenerID = @trenerID", conn))
                {
                    cmd.Parameters.AddWithValue("@trenerID", trenerID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

    }
}
