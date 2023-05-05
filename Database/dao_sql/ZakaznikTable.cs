using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel.Database.dao_sqls
{
    class ZakaznikTable
    {
        private static BindingList<Zakaznik> zakaznici = new BindingList<Zakaznik>();
        private static BindingList<Zakaznik> zakazniciReservation = new BindingList<Zakaznik>();
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ToString();
        private static string SQL_SELECT = "SELECT * FROM \"Zakaznik\";";
        private static string SQL_SELECT_ONE = "SELECT * FROM \"Zakaznik\" WHERE Zid=@Zid;";
        private static string SQL_INSERT = "INSERT INTO \"Zakaznik\" (Jmeno, Prijmeni, Email, Telefon, Ulice, Mesto, Psc) OUTPUT INSERTED.ZID VALUES (@Jmeno, @Prijmeni, @Email, @Telefon, @Ulice, @Mesto, @Psc);";
        private static string SQL_INSERT_HESLO = "INSERT INTO \"Zakaznik\" (Jmeno, Prijmeni, Email, Telefon, Ulice, Mesto, Psc, Heslo) OUTPUT INSERTED.ZID VALUES (@Jmeno, @Prijmeni, @Email, @Telefon, @Ulice, @Mesto, @Psc, @Heslo);";
        private static string SQL_UPDATE = "UPDATE \"Zakaznik\" SET Jmeno=@Jmeno, Prijmeni=@Prijmeni, Email=@Email, Telefon=@Telefon, Ulice=@Ulice, Mesto=@Mesto, Psc=@Psc, Heslo=@Heslo, Stav=@Stav WHERE Zid=@Zid;";
        private static string SQL_DELETE = "DELETE FROM \"Zakaznik\" WHERE Zid=@Zid;";

        public static BindingList<Zakaznik> GetCustomers()
        {
            return zakaznici;
        }

        public static Zakaznik GetCustomer(int index)
        {
            return zakaznici[index];
        }
        public static void RemoveCustomer(Zakaznik z)
        {
            zakaznici.Remove(z);
        }

        public static BindingList<Zakaznik> GetCustomersReservation()
        {
            return zakazniciReservation;
        }

        public static void RemoveCustomerReservation(Zakaznik z)
        {
            zakazniciReservation.Remove(z);
        }

        public static Zakaznik GetCustomerById(int id)
        {
            return zakaznici.Where(i => i.ZID == id).FirstOrDefault();
        }

        //1.1 Novy zakaznik
        public static void Insert(Zakaznik z)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(z.Heslo is null ? SQL_INSERT : SQL_INSERT_HESLO, connection))
                {
                    cmd.Parameters.AddWithValue("@Jmeno", DbType.String).Value = z.Jmeno;
                    cmd.Parameters.AddWithValue("@Prijmeni", DbType.String).Value = z.Prijmeni;
                    cmd.Parameters.AddWithValue("@Email", DbType.String).Value = z.Email;
                    cmd.Parameters.AddWithValue("@Telefon", DbType.String).Value = z.Telefon;

                    if (z.Ulice == null)
                    {
                        cmd.Parameters.AddWithValue("@Ulice", DbType.String).Value = DBNull.Value;
                    }
                    else 
                    {
                        cmd.Parameters.AddWithValue("@Ulice", DbType.String).Value = z.Ulice;
                    }

                    if (z.Mesto == null)
                    {
                        cmd.Parameters.AddWithValue("@Mesto", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Mesto", DbType.String).Value = z.Mesto;
                    }

                    if (z.Psc == null)
                    {
                        cmd.Parameters.AddWithValue("@Psc", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Psc", DbType.String).Value = z.Psc;
                    }

                    if (z.Heslo != null)
                    {
                        cmd.Parameters.Add(new SqlParameter()
                        {
                            DbType = System.Data.DbType.String,
                            ParameterName = "@Heslo",
                            Value = z.Heslo
                        });
                    }

                    Int32 Id = (Int32)cmd.ExecuteScalar();
                    z.ZID = Id;
                    z.Stav = 0;
                    zakaznici.Add(z);
                }       
                connection.Close();
            }
        }
        // 1.2 Seznam zakazniku
        public static void Select()
        {
            zakaznici.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Zakaznik z = new Zakaznik()
                            {
                                ZID = reader.GetInt32(reader.GetOrdinal("ZID")),
                                Jmeno = reader.GetString(reader.GetOrdinal("Jmeno")),
                                Prijmeni = reader.GetString(reader.GetOrdinal("Prijmeni")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Telefon = reader.GetString(reader.GetOrdinal("Telefon")),
                                Ulice = reader.IsDBNull(reader.GetOrdinal("Ulice")) ? null : reader.GetString(reader.GetOrdinal("Ulice")),
                                Mesto = reader.IsDBNull(reader.GetOrdinal("Mesto")) ? null : reader.GetString(reader.GetOrdinal("Mesto")),
                                Psc = reader.IsDBNull(reader.GetOrdinal("Psc")) ? null : reader.GetString(reader.GetOrdinal("Psc")),
                                Heslo = reader.GetString(reader.GetOrdinal("Heslo")),
                                Stav = reader.GetInt32(reader.GetOrdinal("Stav")),
                                FullName = reader.GetString(reader.GetOrdinal("Jmeno")) + " " + reader.GetString(reader.GetOrdinal("Prijmeni"))
                            };
                            zakaznici.Add(z);
                            if (z.Stav != 1) zakazniciReservation.Add(z);
                        }
                    }
                }
                connection.Close();
            }
        }

        //1.3 Detail zakaznika
        public static Zakaznik Select_One(int id)
        {
            Zakaznik z = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT_ONE, connection))
                {
                    cmd.Parameters.AddWithValue("@ZID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            z = new Zakaznik()
                            {
                                ZID = reader.GetInt32(reader.GetOrdinal("ZID")),
                                Jmeno = reader.GetString(reader.GetOrdinal("Jmeno")),
                                Prijmeni = reader.GetString(reader.GetOrdinal("Prijmeni")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Telefon = reader.GetString(reader.GetOrdinal("Telefon")),
                                Ulice = reader.IsDBNull(reader.GetOrdinal("Ulice")) ? null : reader.GetString(reader.GetOrdinal("Ulice")),
                                Mesto = reader.IsDBNull(reader.GetOrdinal("Mesto")) ? null : reader.GetString(reader.GetOrdinal("Mesto")),
                                Psc = reader.IsDBNull(reader.GetOrdinal("Psc")) ? null : reader.GetString(reader.GetOrdinal("Psc")),
                                Heslo = reader.GetString(reader.GetOrdinal("Heslo")),
                                Stav = reader.GetInt32(reader.GetOrdinal("Stav")),
                                FullName = reader.GetString(reader.GetOrdinal("Jmeno")) + " " + reader.GetString(reader.GetOrdinal("Prijmeni"))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return z;
        }

        //1.4 Aktualizace zakaznika
        public static void Update(Zakaznik z)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_UPDATE, connection))
                {
                    cmd.Parameters.AddWithValue("@ZID", DbType.String).Value = z.ZID;
                    cmd.Parameters.AddWithValue("@Jmeno", DbType.String).Value = z.Jmeno;
                    cmd.Parameters.AddWithValue("@Prijmeni", DbType.String).Value = z.Prijmeni;
                    cmd.Parameters.AddWithValue("@Email", DbType.String).Value = z.Email;
                    cmd.Parameters.AddWithValue("@Telefon", DbType.String).Value = z.Telefon;

                    if (z.Ulice == null)
                    {
                        cmd.Parameters.AddWithValue("@Ulice", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Ulice", DbType.String).Value = z.Ulice;
                    }

                    if (z.Mesto == null)
                    {
                        cmd.Parameters.AddWithValue("@Mesto", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Mesto", DbType.String).Value = z.Mesto;
                    }

                    if (z.Psc == null)
                    {
                        cmd.Parameters.AddWithValue("@Psc", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Psc", DbType.String).Value = z.Psc;
                    }

                    cmd.Parameters.AddWithValue("@Heslo", DbType.String).Value = z.Heslo;
                    cmd.Parameters.AddWithValue("@Stav", DbType.String).Value = z.Stav;

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //1.5 Smazani zakaznika
        public static void Delete(Zakaznik z)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_DELETE, connection))
                {
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@ZID",
                        Value = z.ZID
                    });

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            RemoveCustomer(z);
        }
    }
}
