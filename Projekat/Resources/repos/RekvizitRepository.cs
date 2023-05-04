using Projekat.Models;
using Projekat.resources.managers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat.resources.repos
{
    class RekvizitRepository
    {

        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * from Rekvizit";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Rekvizit rekvizit = new Rekvizit(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    rekvizit.Obrisano = reader.GetBoolean(3);

                    RekvizitManager.GetInstance().SviRekviziti.Add(rekvizit);
                }

                conn.Close();
            }

        }

        public void Create(int rekvizitID, string naziv, string opis)
        {
            Rekvizit rekvizit = new Rekvizit(rekvizitID, naziv, opis);
            RekvizitManager.GetInstance().SviRekviziti.Add(rekvizit);
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("INSERT INTO Rekvizit VALUES(@rekvizitID, @naziv, @opis, @obrisano)", conn))
                {
                    cmd.Parameters.AddWithValue("@rekvizitID", rekvizitID);
                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    cmd.Parameters.AddWithValue("@opis", opis);
                    cmd.Parameters.AddWithValue("@obrisano", false);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int rekvizitID, string naziv, string opis)
        {
            Rekvizit rekvizit = RekvizitManager.GetInstance().getRekvizitById(rekvizitID);
            rekvizit.Naziv = naziv;
            rekvizit.Opis = opis;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Rekvizit SET Naziv = @naziv, Opis = @Opis WHERE rekvizitID = @rekvizitID", conn))
                {
                    cmd.Parameters.AddWithValue("@rekvizitID", rekvizitID);
                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    cmd.Parameters.AddWithValue("@opis", opis);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int rekvizitID)
        {
            Rekvizit rekvizit = RekvizitManager.GetInstance().getRekvizitById(rekvizitID);
            rekvizit.Obrisano = true;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Rekvizit SET Obrisano = 1 WHERE rekvizitID = @rekvizitID", conn))
                {
                    cmd.Parameters.AddWithValue("@rekvizitID", rekvizitID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

    }
}
