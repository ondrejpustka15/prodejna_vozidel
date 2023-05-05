using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel.Database.dao_sqls
{
    class RezervaceTable
    {
        private static List<Rezervace> rezervace = new List<Rezervace>();
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ToString();
        private static string SQL_SELECT = "SELECT rID, datum_zacatek, datum_konec, rezervace.zID, rezervace.vID, CONCAT(Zakaznik.jmeno, ' ', Zakaznik.prijmeni) as Zakaznik, CONCAT(Vozidlo.znacka, ' ', Vozidlo.model, ', ', Vozidlo.rok) as Vozidlo FROM Rezervace join Vozidlo on Rezervace.vID = Vozidlo.vID join Zakaznik on Rezervace.zID = Zakaznik.zID";
        private static string SQL_SELECT_UKONCENE = "SELECT * FROM \"Rezervace_ukoncene\"";
        private static string SQL_SELECT_ONE = "SELECT * FROM \"Rezervace\" WHERE RID=@RID";
        private static string SQL_SELECT_BY_VID = "SELECT * FROM \"Rezervace\" WHERE VID=@VID";
        private static string SQL_INSERT = "INSERT INTO \"Rezervace\" (VID, ZID) OUTPUT INSERTED.RID VALUES (@VID, @ZID)";
        private static string SQL_DELETE = "DELETE FROM \"Rezervace\" WHERE RID=@RID";
        private static List<int> rezervace_ukoncene = new List<int>();

        public static List<Rezervace> GetReservations()
        {
            return rezervace;
        }

        public static Rezervace GetReservation(int index)
        {
            return rezervace[index];
        }

        public static void RemoveReservation(Rezervace r)
        {
            rezervace.Remove(r);
        }

        //4.1 Nova rezervace
        public static void Insert(Rezervace r)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_INSERT, connection))
                {
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@VID",
                        Value = r.VID
                    });

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@ZID",
                        Value = r.ZID
                    });

                    Int32 Id = (Int32)cmd.ExecuteScalar();
                    r.RID = Id;
                    rezervace.Add(r);
                }
                connection.Close();
            }
        }

        //4.2 Detail Rezervace
        public static Rezervace Select_One(int id)
        {
            Rezervace r = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT_ONE, connection))
                {
                    cmd.Parameters.AddWithValue("@RID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            r = new Rezervace()
                            {
                                RID = reader.GetInt32(reader.GetOrdinal("RID")),
                                Datum_zacatek = reader.GetDateTime(reader.GetOrdinal("Datum_zacatek")),
                                Datum_konec = reader.GetDateTime(reader.GetOrdinal("Datum_konec")),
                                VID = reader.GetInt32(reader.GetOrdinal("VID")),
                                ZID = reader.GetInt32(reader.GetOrdinal("ZID")),
                                Zakaznik = reader.GetString(reader.GetOrdinal("Zakaznik")),
                                Vozidlo = reader.GetString(reader.GetOrdinal("Vozidlo"))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return r;
        }

        //4.3 Smazani rezervace 
        public static void Delete(Rezervace r)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_DELETE, connection))
                {
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@RID",
                        Value = r.RID
                    });

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            RemoveReservation(r);
        }

        public static void Select()
        {
            rezervace.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rezervace r = new Rezervace()
                            {
                                RID = reader.GetInt32(reader.GetOrdinal("RID")),
                                Datum_zacatek = reader.GetDateTime(reader.GetOrdinal("Datum_zacatek")),
                                Datum_konec = reader.GetDateTime(reader.GetOrdinal("Datum_konec")),
                                VID = reader.GetInt32(reader.GetOrdinal("VID")),
                                ZID = reader.GetInt32(reader.GetOrdinal("ZID")),
                                Zakaznik = reader.GetString(reader.GetOrdinal("Zakaznik")),
                                Vozidlo = reader.GetString(reader.GetOrdinal("Vozidlo"))
                            };
                            rezervace.Add(r);
                        }
                    }
                }
                connection.Close();
            }
        }

        //7.1 Upozorneni na konec rezervace
        public static List<int> Delete()
        {
            rezervace_ukoncene.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                using (SqlCommand cmd = new SqlCommand("KonecRezervace", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand(SQL_SELECT_UKONCENE, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("zID"));
                            rezervace_ukoncene.Add(id);
                        }
                    }
                }
                connection.Close();
            }

            return rezervace_ukoncene;
        }

        public static Rezervace Select_VID(int vid)
        {
            Rezervace r = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT_BY_VID, connection))
                {
                    cmd.Parameters.AddWithValue("@VID", vid);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            r = new Rezervace()
                            {
                                RID = reader.GetInt32(reader.GetOrdinal("RID")),
                                Datum_zacatek = reader.GetDateTime(reader.GetOrdinal("Datum_zacatek")),
                                Datum_konec = reader.GetDateTime(reader.GetOrdinal("Datum_konec")),
                                VID = reader.GetInt32(reader.GetOrdinal("VID")),
                                ZID = reader.GetInt32(reader.GetOrdinal("ZID"))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return r;
        }
    }
}