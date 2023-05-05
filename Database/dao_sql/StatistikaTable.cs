using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel.Database.dao_sqls
{
    class StatistikaTable
    {
        private static List<int> years = new List<int>();
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ToString();
        private static string SQL_SELECT = "SELECT * FROM Statistika";
        private static string SQL_YEAR = "SELECT YEAR(prodej.datum) as Year FROM PRODEJ GROUP BY YEAR(prodej.datum)";

        public static List<int> GetYears()
        {
            return years;
        }

        public static List<int> Years()
        {
 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_YEAR, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            years.Add(reader.GetInt32(reader.GetOrdinal("Year")));
                        }
                    }
                }
                connection.Close();
            }

            return years;
        }

        public static Statistika Select(int rok)
        {
            Statistika s = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("StatistikaZaRok", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@p_rok", rok);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(SQL_SELECT, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            s = new Statistika()
                            {
                                Leden = reader.GetInt32(reader.GetOrdinal("Leden")),
                                Unor = reader.GetInt32(reader.GetOrdinal("Unor")),
                                Brezen = reader.GetInt32(reader.GetOrdinal("Brezen")),
                                Duben = reader.GetInt32(reader.GetOrdinal("Duben")),
                                Kveten = reader.GetInt32(reader.GetOrdinal("Kveten")),
                                Cerven = reader.GetInt32(reader.GetOrdinal("Cerven")),
                                Cervenec = reader.GetInt32(reader.GetOrdinal("Cervenec")),
                                Srpen = reader.GetInt32(reader.GetOrdinal("Srpen")),
                                Zari = reader.GetInt32(reader.GetOrdinal("Zari")),
                                Rijen = reader.GetInt32(reader.GetOrdinal("Rijen")),
                                Listopad = reader.GetInt32(reader.GetOrdinal("Listopad")),
                                Prosinec = reader.GetInt32(reader.GetOrdinal("Prosinec")),
                                Rok = reader.GetInt32(reader.GetOrdinal("Rok"))
                            };                      
                        }
                    }
                }
                connection.Close();
            }
            return s;
        }
    }
}
