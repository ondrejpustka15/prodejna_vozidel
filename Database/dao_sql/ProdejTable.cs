using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel.Database.dao_sqls
{
    class ProdejTable
    {
        private static BindingList<Prodej> prodeje = new BindingList<Prodej>();
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ToString();
        private static string SQL_SELECT = "SELECT pID, datum, prodej.maID, prodej.zID, prodej.vID, CONCAT(Vozidlo.znacka, ' ', Vozidlo.model, ', ', Vozidlo.rok) as Vozidlo, CONCAT(Zakaznik.jmeno, ' ', Zakaznik.prijmeni) as Zakaznik, CONCAT(Manazer.jmeno, ' ', Manazer.prijmeni) as Manazer FROM Prodej join Vozidlo on Prodej.vID = Vozidlo.vID join Zakaznik on Prodej.zID = Zakaznik.zID join Manazer on Prodej.maID = Manazer.maID";
        private static string SQL_SELECT_ONE = "SELECT * FROM \"Prodej\" WHERE PID=@PID";
        private static string SQL_SELECT_BY_VID = "SELECT * FROM \"Prodej\" WHERE VID=@VID";
        private static string SQL_INSERT = "INSERT INTO \"Prodej\" (Datum, MaID, VID, ZID) OUTPUT INSERTED.PID VALUES (@Datum, @MaID, @VID, @ZID)";
        private static string SQL_UPDATE = "UPDATE \"Prodej\" SET Datum=@Datum, MaID=@MaID, VID=@VID, ZID=@ZID WHERE PID=@PID";
        private static string SQL_DELETE = "DELETE FROM \"Prodej\" WHERE PID=@PID";

        public static BindingList<Prodej> GetSales()
        {
            return prodeje;
        }

        public static Prodej GetSale(int index)
        {
            return prodeje[index];
        }

        public static void RemoveSale(Prodej p)
        {
            prodeje.Remove(p);
        }

        //5.1 Novy prodej
        public static void Insert(Prodej p)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_INSERT, connection))
                {
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Date,
                        ParameterName = "@Datum",
                        Value = p.Datum
                    });

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@MaID",
                        Value = p.MaID
                    });

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@VID",
                        Value = p.VID
                    });

                    cmd.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@ZID",
                        Value = p.ZID
                    });

                    Int32 Id = (Int32)cmd.ExecuteScalar();
                    p.PID = Id;
                    prodeje.Add(p);
                }
                connection.Close();
            }
        }

        //5.2 Seznam prodeju
        public static void Select()
        {
            prodeje.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Prodej p = new Prodej()
                            {
                                PID = reader.GetInt32(reader.GetOrdinal("PID")),
                                Datum = reader.GetDateTime(reader.GetOrdinal("Datum")),
                                MaID = reader.GetInt32(reader.GetOrdinal("MaID")),
                                VID = reader.GetInt32(reader.GetOrdinal("VID")),
                                ZID = reader.GetInt32(reader.GetOrdinal("ZID")),
                                Vozidlo = reader.GetString(reader.GetOrdinal("Vozidlo")),
                                Zakaznik = reader.GetString(reader.GetOrdinal("Zakaznik")),
                                Manazer = reader.GetString(reader.GetOrdinal("Manazer"))
                            };
                            prodeje.Add(p);
                        }
                    }
                }
                connection.Close();
            }
        }
        
        //5.3 Detail prodeje
        public static Prodej Select_One(int id)
        {
            Prodej p = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT_ONE, connection))
                {
                    cmd.Parameters.AddWithValue("@PID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            p = new Prodej()
                            {
                                PID = reader.GetInt32(reader.GetOrdinal("PID")),
                                Datum = reader.GetDateTime(reader.GetOrdinal("Datum")),
                                MaID = reader.GetInt32(reader.GetOrdinal("MaID")),
                                VID = reader.GetInt32(reader.GetOrdinal("VID")),
                                ZID = reader.GetInt32(reader.GetOrdinal("ZID"))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return p;
        }
        public static Prodej Select_VID(int vid)
        {
            Prodej p = null;
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
                            p = new Prodej()
                            {
                                PID = reader.GetInt32(reader.GetOrdinal("PID")),
                                Datum = reader.GetDateTime(reader.GetOrdinal("Datum")),
                                MaID = reader.GetInt32(reader.GetOrdinal("MaID")),
                                VID = reader.GetInt32(reader.GetOrdinal("VID")),
                                ZID = reader.GetInt32(reader.GetOrdinal("ZID"))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return p;
        }
    }
}
