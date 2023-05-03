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
    class JezikRepository
    {

        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * from Jezik";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Jezik jezik = new Jezik(reader.GetInt32(0), reader.GetString(1));
                    jezik.Obrisano = reader.GetBoolean(2);

                    JezikManager.GetInstance().SviJezici.Add(jezik);
                }

                conn.Close();
            }

        }

        public void Create(int jezikID, string naziv)
        {
            Jezik jezik = new Jezik(jezikID, naziv);
            JezikManager.GetInstance().SviJezici.Add(jezik);
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("INSERT INTO Jezik VALUES(@jezikID, @naziv)", conn))
                {
                    cmd.Parameters.AddWithValue("@id", jezikID);
                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int jezikID, string naziv)
        {
            Jezik jezik = JezikManager.GetInstance().getJezikById(jezikID);
            jezik.Naziv = naziv;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Jezik SET Naziv = @naziv WHERE jezikID = @jezikID", conn))
                {
                    cmd.Parameters.AddWithValue("@jezikID", jezikID);
                    cmd.Parameters.AddWithValue("@naziv", naziv);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int jezikID)
        {
            Jezik jezik = JezikManager.GetInstance().getJezikById(jezikID);
            jezik.Obrisano = true;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Jezik SET Obrisano = 1 WHERE jezikID = @jezikID", conn))
                {
                    cmd.Parameters.AddWithValue("@jezikID", jezikID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

    }
}
