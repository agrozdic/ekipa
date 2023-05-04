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
    class CiljRepository
    {

        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * from Cilj";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Cilj cilj = new Cilj(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                    cilj.Obrisano = reader.GetBoolean(3);

                    CiljManager.GetInstance().SviCiljevi.Add(cilj);
                }

                conn.Close();
            }

        }

        public void Create(int ciljID, string naziv, string opis)
        {
            Cilj cilj = new Cilj(ciljID, naziv, opis);
            CiljManager.GetInstance().SviCiljevi.Add(cilj);
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("INSERT INTO Cilj VALUES(@ciljID, @naziv, @opis, @obrisano)", conn))
                {
                    cmd.Parameters.AddWithValue("@ciljID", ciljID);
                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    cmd.Parameters.AddWithValue("@opis", opis);
                    cmd.Parameters.AddWithValue("@obrisano", false);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int ciljID, string naziv, string opis)
        {
            Cilj cilj = CiljManager.GetInstance().getCiljById(ciljID);
            cilj.Naziv = naziv;
            cilj.Opis = opis;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Cilj SET Naziv = @naziv, Opis = @Opis WHERE ciljID = @ciljID", conn))
                {
                    cmd.Parameters.AddWithValue("@ciljID", ciljID);
                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    cmd.Parameters.AddWithValue("@opis", opis);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int ciljID)
        {
            Cilj cilj = CiljManager.GetInstance().getCiljById(ciljID);
            cilj.Obrisano = true;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Cilj SET Obrisano = 1 WHERE ciljID = @ciljID", conn))
                {
                    cmd.Parameters.AddWithValue("@ciljID", ciljID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

    }
}
