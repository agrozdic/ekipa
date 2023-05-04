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
    class TerminRepository
    {

        TrenerService trenerService = new TrenerService();

        public void Read()
        {

            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"SELECT * from Termin";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Trener trener = trenerService.getTrenerByID(reader.GetInt32(1));
                    Termin termin = new Termin(reader.GetInt32(0), trener, reader.GetDateTime(2), reader.GetTimeSpan(3), reader.GetBoolean(4));
                    termin.Obrisano = reader.GetBoolean(5);

                    TerminManager.GetInstance().SviTermini.Add(termin);
                }

                conn.Close();
            }

        }

        public void Create(int terminID, Trener trener, DateTime datum, TimeSpan vreme, bool slobodan)
        {
            Termin termin = new Termin(terminID, trener, datum, vreme, slobodan);
            TerminManager.GetInstance().SviTermini.Add(termin);
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("INSERT INTO Termin VALUES(@terminID, @trener, @datum, @vreme, @slobodan, @obrisano)", conn))
                {
                    cmd.Parameters.AddWithValue("@terminID", terminID);
                    cmd.Parameters.AddWithValue("@trener", trener.TrenerID);
                    cmd.Parameters.AddWithValue("@datum", datum);
                    cmd.Parameters.AddWithValue("@vreme", vreme);
                    cmd.Parameters.AddWithValue("@slobodan", slobodan);
                    cmd.Parameters.AddWithValue("@obrisano", false);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(int terminID, DateTime datum, TimeSpan vreme, bool slobodan)
        {
            Termin termin = TerminManager.GetInstance().getTerminById(terminID);
            termin.Datum = datum;
            termin.Vreme = vreme;
            termin.Slobodan = slobodan;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Termin SET Datum = @datum, Vreme = @vreme, Slobodan = @slobodan WHERE terminID = @terminID", conn))
                {
                    cmd.Parameters.AddWithValue("@terminID", terminID);
                    cmd.Parameters.AddWithValue("@datum", datum);
                    cmd.Parameters.AddWithValue("@vreme", vreme);
                    cmd.Parameters.AddWithValue("@slobodan", slobodan);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Delete(int terminID)
        {
            Termin termin = TerminManager.GetInstance().getTerminById(terminID);
            termin.Obrisano = true;
            using (SqlConnection conn = new SqlConnection(ConnectionString.ConnString))
            {
                conn.Open();
                using (SqlCommand cmd =
                    new SqlCommand("UPDATE Termin SET Obrisano = 1 WHERE terminID = @terminID", conn))
                {
                    cmd.Parameters.AddWithValue("@terminID", terminID);
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

    }
}
