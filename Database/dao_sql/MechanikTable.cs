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
    class MechanikTable
    {
        private static BindingList<Mechanik> mechanics = new BindingList<Mechanik>();
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ToString();
        private static string SQL_SELECT = "SELECT * FROM \"Mechanik\";";
        private static string SQL_SELECT_ONE = "SELECT * FROM \"Mechanik\" WHERE MeID=@MeID;";
        private static string SQL_INSERT = "INSERT INTO \"Mechanik\" (Jmeno, Prijmeni, Email, Telefon, Ulice, Mesto, Psc) OUTPUT INSERTED.MeID VALUES (@Jmeno, @Prijmeni, @Email, @Telefon, @Ulice, @Mesto, @Psc);";
        private static string SQL_UPDATE = "UPDATE \"Mechanik\" SET Jmeno=@Jmeno, Prijmeni=@Prijmeni, Email=@Email, Telefon=@Telefon, Ulice=@Ulice, Mesto=@Mesto, Psc=@Psc WHERE MeID=@MeID;";
        private static string SQL_DELETE = "DELETE FROM \"Mechanik\" WHERE MeID=@MeID;";

        public static BindingList<Mechanik> GetMechanics()
        {
            return mechanics;
        }

        public static Mechanik GetMechanic(int index)
        {
            return mechanics[index];
        }
        public static void RemoveMechanic(Mechanik m)
        {
            mechanics.Remove(m);
        }

        public static Mechanik GetMechanicById(int id)
        {
            return mechanics.Where(i => i.MeID == id).FirstOrDefault();
        }

        //2.1 Novy mechanik
        public static void Insert(Mechanik m)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_INSERT, connection))
                {
                    cmd.Parameters.AddWithValue("@Jmeno", DbType.String).Value = m.Jmeno;
                    cmd.Parameters.AddWithValue("@Prijmeni", DbType.String).Value = m.Prijmeni;
                    cmd.Parameters.AddWithValue("@Email", DbType.String).Value = m.Email;
                    cmd.Parameters.AddWithValue("@Telefon", DbType.String).Value = m.Telefon;

                    if (m.Ulice == null)
                    {
                        cmd.Parameters.AddWithValue("@Ulice", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Ulice", DbType.String).Value = m.Ulice;
                    }

                    if (m.Mesto == null)
                    {
                        cmd.Parameters.AddWithValue("@Mesto", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Mesto", DbType.String).Value = m.Mesto;
                    }

                    if (m.Psc == null)
                    {
                        cmd.Parameters.AddWithValue("@Psc", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Psc", DbType.String).Value = m.Psc;
                    }

                    Int32 Id = (Int32)cmd.ExecuteScalar();
                    m.MeID = Id;
                    mechanics.Add(m);
                }
                
                connection.Close();
            }
        }
        //2.2 Seznam mechaniku
        public static void Select()
        {
            mechanics.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Mechanik m = new Mechanik()
                            {
                                MeID = reader.GetInt32(reader.GetOrdinal("MeID")),
                                Jmeno = reader.GetString(reader.GetOrdinal("Jmeno")),
                                Prijmeni = reader.GetString(reader.GetOrdinal("Prijmeni")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Telefon = reader.GetString(reader.GetOrdinal("Telefon")),
                                Ulice = reader.IsDBNull(reader.GetOrdinal("Ulice")) ? null : reader.GetString(reader.GetOrdinal("Ulice")),
                                Mesto = reader.IsDBNull(reader.GetOrdinal("Mesto")) ? null : reader.GetString(reader.GetOrdinal("Mesto")),
                                Psc = reader.IsDBNull(reader.GetOrdinal("Psc")) ? null : reader.GetString(reader.GetOrdinal("Psc")),
                                FullName = reader.GetString(reader.GetOrdinal("Jmeno")) + " " + reader.GetString(reader.GetOrdinal("Prijmeni"))
                            };
                            mechanics.Add(m);
                        }
                    }
                }
                connection.Close();
            }
        }

        //2.3 Detail mechanika
        public static Mechanik Select_One(int id)
        {
            Mechanik m = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT_ONE, connection))
                {
                    cmd.Parameters.AddWithValue("@MeID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            m = new Mechanik()
                            {
                                MeID = reader.GetInt32(reader.GetOrdinal("MeID")),
                                Jmeno = reader.GetString(reader.GetOrdinal("Jmeno")),
                                Prijmeni = reader.GetString(reader.GetOrdinal("Prijmeni")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Telefon = reader.GetString(reader.GetOrdinal("Telefon")),
                                Ulice = reader.IsDBNull(reader.GetOrdinal("Ulice")) ? null : reader.GetString(reader.GetOrdinal("Ulice")),
                                Mesto = reader.IsDBNull(reader.GetOrdinal("Mesto")) ? null : reader.GetString(reader.GetOrdinal("Mesto")),
                                Psc = reader.IsDBNull(reader.GetOrdinal("Psc")) ? null : reader.GetString(reader.GetOrdinal("Psc")),
                                FullName = reader.GetString(reader.GetOrdinal("Jmeno")) + " " + reader.GetString(reader.GetOrdinal("Prijmeni"))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return m;
        }

        //2.4 Aktualizace mechanika
        public static void Update(Mechanik m)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_UPDATE, connection))
                {
                    cmd.Parameters.AddWithValue("@MeID", DbType.String).Value = m.MeID;
                    cmd.Parameters.AddWithValue("@Jmeno", DbType.String).Value = m.Jmeno;
                    cmd.Parameters.AddWithValue("@Prijmeni", DbType.String).Value = m.Prijmeni;
                    cmd.Parameters.AddWithValue("@Email", DbType.String).Value = m.Email;
                    cmd.Parameters.AddWithValue("@Telefon", DbType.String).Value = m.Telefon;

                    if (m.Ulice == null)
                    {
                        cmd.Parameters.AddWithValue("@Ulice", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Ulice", DbType.String).Value = m.Ulice;
                    }

                    if (m.Mesto == null)
                    {
                        cmd.Parameters.AddWithValue("@Mesto", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Mesto", DbType.String).Value = m.Mesto;
                    }

                    if (m.Psc == null)
                    {
                        cmd.Parameters.AddWithValue("@Psc", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Psc", DbType.String).Value = m.Psc;
                    }

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //2.5 Smazani mechanika
        public static void Delete(Mechanik m)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SmazatMechanika", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@p_meID", m.MeID);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            RemoveMechanic(m);
        }
    }
}
