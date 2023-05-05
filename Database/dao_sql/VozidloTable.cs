using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdejnaVozidel.Database.dao_sqls
{
    class VozidloTable
    {
        private static List<Vozidlo> allVehicles = new List<Vozidlo>();
        private static List<Vozidlo> unsoldVehicles = new List<Vozidlo>();
        private static List<Vozidlo> reservedVehicles = new List<Vozidlo>();
        private static List<Vozidlo> soldVehicles = new List<Vozidlo>();
        private static List<Vozidlo> searchVehicles = new List<Vozidlo>();
        private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringMsSql"].ToString();
        private static string SQL_SELECT = "SELECT * FROM \"Vozidlo\"";
        private static string SQL_SELECT_ONE = "SELECT * FROM \"Vozidlo\" WHERE VID=@VID";
        //private static string SQL_SELECT_SEARCH = "SELECT * FROM \"Vozidlo\" WHERE 1=1";
        //private static string SQL_INSERT = "INSERT INTO \"Vozidlo\" (Znacka, Model, Rok, Tachometr, Motor, Prevodovka, Karoserie, Palivo, Barva, Cena) OUTPUT INSERTED.VID VALUES (@Znacka, @Model, @Rok, @Tachometr, @Motor, @Prevodovka, @Karoserie, @Palivo, @Barva, @Cena)";
        private static string SQL_UPDATE = "UPDATE \"Vozidlo\" SET Znacka=@Znacka, Model=@Model, Rok=@Rok, Tachometr=@Tachometr, Motor=@Motor, Prevodovka=@Prevodovka, Karoserie=@Karoserie, Palivo=@Palivo, Barva=@Barva, Cena=@Cena, Stav=@Stav, MeID=@MeID WHERE VID=@VID";
        private static string SQL_DELETE = "DELETE FROM \"Vozidlo\" WHERE VID=@VID";
        private static string SQL_COUNT_CENA = "SELECT COUNT(*) FROM \"Cena\" WHERE VID=@VID";

        private static List<Cena> vyvoj_ceny = new List<Cena>();
        private static string SQL_SELECT_CENA = "SELECT * FROM \"Cena\" WHERE VID=@VID;";

        public static List<Vozidlo> GetAllVehicles()
        {
            return allVehicles;
        }

        public static Vozidlo GetVehicleFromAll(int index)
        {
            return allVehicles[index];
        }
        public static void RemoveVehicleFromAll(Vozidlo v)
        {
            allVehicles.Remove(v);
        }

        public static Vozidlo GetVehicleFromAllById(int id)
        {
            return allVehicles.Where(i => i.VID == id).FirstOrDefault();
        }
        public static int GetVehiclesCount()
        {
            return allVehicles.Count();
        }

        public static List<Vozidlo> GetUnsoldVehicles()
        {
            return unsoldVehicles;
        }

        public static Vozidlo GetVehicleFromUnsold(int index)
        {
            return unsoldVehicles[index];
        }
        public static void RemoveVehicleFromUnsold(Vozidlo v)
        {
            unsoldVehicles.Remove(v);
        }

        public static Vozidlo GetVehicleFromUnsoldById(int id)
        {
            return unsoldVehicles.Where(i => i.VID == id).FirstOrDefault();
        }

        public static int GetVehiclesUnsoldCount()
        {
            return unsoldVehicles.Count();
        }

        public static List<Vozidlo> GetReservedVehicles()
        {
            return reservedVehicles;
        }

        public static Vozidlo GetVehicleFromReserved(int index)
        {
            return reservedVehicles[index];
        }
        public static void AddVehicleToReserved(Vozidlo v)
        {
            reservedVehicles.Add(v);
        }
        public static void RemoveVehicleFromReserved(Vozidlo v)
        {
            reservedVehicles.Remove(v);
        }

        public static Vozidlo GetVehicleReservedById(int id)
        {
            return reservedVehicles.Where(i => i.VID == id).FirstOrDefault();
        }

        public static List<Vozidlo> GetSoldVehicles()
        {
            return soldVehicles;
        }

        public static void AddVehicleToSold(Vozidlo v)
        {
            soldVehicles.Add(v);
        }

        public static Vozidlo GetVehicleFromSold(int index)
        {
            return soldVehicles[index];
        }
        public static void RemoveVehicleFromSold(Vozidlo v)
        {
            soldVehicles.Remove(v);
        }

        public static Vozidlo GetVehicleFromSoldById(int id)
        {
            return soldVehicles.Where(i => i.VID == id).FirstOrDefault();
        }

        //3.1 Nove vozidlo
        public static string Insert(Vozidlo v)
        {
            string returnValue;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("NoveVozidlo", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@p_znacka", v.Znacka);
                    cmd.Parameters.AddWithValue("@p_model", v.Model);
                    cmd.Parameters.AddWithValue("@p_rok", (object)v.Rok ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_tachometr", (object)v.Tachometr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_motor", (object)v.Motor ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_prevodovka", (object)v.Prevodovka ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_karoserie", (object)v.Karoserie ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_palivo", (object)v.Palivo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_barva", (object)v.Barva ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@p_cena", v.Cena);
                    if (v.MeID == 0)
                    {
                        cmd.Parameters.AddWithValue("@p_meID", DBNull.Value);
                    }
                    else 
                    {
                        cmd.Parameters.AddWithValue("@p_meID", v.MeID);
                    }
                    
           
                    SqlParameter result = new SqlParameter("@p_return", SqlDbType.NVarChar, 30);
                    result.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(result);

                    SqlParameter inserted_ID = new SqlParameter("@p_insertedID", SqlDbType.Int);
                    inserted_ID.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(inserted_ID);

                    cmd.ExecuteNonQuery();
                    
                    v.VID = Convert.ToInt32(cmd.Parameters["@p_insertedID"].Value);
                    allVehicles.Add(v);
                    unsoldVehicles.Add(v);
                    returnValue = Convert.ToString(result.Value);
                }
                connection.Close();
            }
            return returnValue;
        }

        //3.2 Seznam vozidel
        public static void Select()
        {
            allVehicles.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vozidlo v = new Vozidlo()
                            {
                                VID = reader.GetInt32(reader.GetOrdinal("VID")),
                                Znacka = reader.GetString(reader.GetOrdinal("Znacka")),
                                Model = reader.GetString(reader.GetOrdinal("Model")),
                                Rok = reader.GetInt32(reader.GetOrdinal("Rok")),
                                Tachometr = reader.IsDBNull(reader.GetOrdinal("Tachometr")) ? 0 : reader.GetInt32(reader.GetOrdinal("Tachometr")),
                                Motor = reader.IsDBNull(reader.GetOrdinal("Motor")) ? null : reader.GetString(reader.GetOrdinal("Motor")),
                                Prevodovka = reader.IsDBNull(reader.GetOrdinal("Prevodovka")) ? null : reader.GetString(reader.GetOrdinal("Prevodovka")),
                                Karoserie = reader.IsDBNull(reader.GetOrdinal("Karoserie")) ? null : reader.GetString(reader.GetOrdinal("Karoserie")),
                                Palivo = reader.IsDBNull(reader.GetOrdinal("Palivo")) ? null : reader.GetString(reader.GetOrdinal("Palivo")),
                                Barva = reader.IsDBNull(reader.GetOrdinal("Barva")) ? null : reader.GetString(reader.GetOrdinal("Barva")),
                                Cena = reader.GetDecimal(reader.GetOrdinal("Cena")),
                                Stav = reader.GetInt32(reader.GetOrdinal("Stav")),
                                MeID = reader.IsDBNull(reader.GetOrdinal("MeID")) ? 0 : reader.GetInt32(reader.GetOrdinal("MeID"))
                            };
                            allVehicles.Add(v);
                            if (v.Stav == 0) unsoldVehicles.Add(v);
                            if (v.Stav == 1) reservedVehicles.Add(v);
                            if (v.Stav == 2) soldVehicles.Add(v);
                        }
                    }
                }
                connection.Close();
            }
        }

        //3.3 Detail vozidla
        public static Vozidlo Select_One(int id)
        {
            Vozidlo v = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT_ONE, connection))
                {
                    cmd.Parameters.AddWithValue("@VID", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            v = new Vozidlo()
                            {
                                VID = reader.GetInt32(reader.GetOrdinal("VID")),
                                Znacka = reader.GetString(reader.GetOrdinal("Znacka")),
                                Model = reader.GetString(reader.GetOrdinal("Model")),
                                Rok = reader.GetInt32(reader.GetOrdinal("Rok")),
                                Tachometr = reader.IsDBNull(reader.GetOrdinal("Tachometr")) ? 0 : reader.GetInt32(reader.GetOrdinal("Tachometr")),
                                Motor = reader.IsDBNull(reader.GetOrdinal("Motor")) ? null : reader.GetString(reader.GetOrdinal("Motor")),
                                Prevodovka = reader.IsDBNull(reader.GetOrdinal("Prevodovka")) ? null : reader.GetString(reader.GetOrdinal("Prevodovka")),
                                Karoserie = reader.IsDBNull(reader.GetOrdinal("Karoserie")) ? null : reader.GetString(reader.GetOrdinal("Karoserie")),
                                Palivo = reader.IsDBNull(reader.GetOrdinal("Palivo")) ? null : reader.GetString(reader.GetOrdinal("Palivo")),
                                Barva = reader.IsDBNull(reader.GetOrdinal("Barva")) ? null : reader.GetString(reader.GetOrdinal("Barva")),
                                Cena = reader.GetDecimal(reader.GetOrdinal("Cena")),
                                Stav = reader.GetInt32(reader.GetOrdinal("Stav")),
                                MeID = reader.IsDBNull(reader.GetOrdinal("MeID")) ? 0 : reader.GetInt32(reader.GetOrdinal("MeID"))
                            };
                        }
                    }
                }
                connection.Close();
            }
            return v;
        }

        //3.4 Aktualizace vozidla
        public static void Update(Vozidlo v)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_UPDATE, connection))
                {
                    //cmd.Parameters.AddWithValue("@Jmeno", DbType.String).Value = z.Jmeno;
                    cmd.Parameters.AddWithValue("@VID", DbType.Int32).Value = v.VID;
                    cmd.Parameters.AddWithValue("@Znacka", DbType.String).Value = v.Znacka;
                    cmd.Parameters.AddWithValue("@Model", DbType.String).Value = v.Model;
                    cmd.Parameters.AddWithValue("@Rok", DbType.Int32).Value = v.Rok;

                    if (v.Tachometr == null)
                    {
                        cmd.Parameters.AddWithValue("@Tachometr", DbType.Int32).Value = DBNull.Value;
                    }
                    else 
                    {
                        cmd.Parameters.AddWithValue("@Tachometr", DbType.Int32).Value = v.Tachometr;
                    }

                    if (v.Motor == null)
                    {
                        cmd.Parameters.AddWithValue("@Motor", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Motor", DbType.String).Value = v.Motor;
                    }

                    if (v.Prevodovka == null)
                    {
                        cmd.Parameters.AddWithValue("@Prevodovka", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Prevodovka", DbType.String).Value = v.Prevodovka;
                    }

                    if (v.Karoserie == null)
                    {
                        cmd.Parameters.AddWithValue("@Karoserie", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Karoserie", DbType.String).Value = v.Karoserie;
                    }

                    if (v.Palivo == null)
                    {
                        cmd.Parameters.AddWithValue("@Palivo", DbType.Int32).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Palivo", DbType.Int32).Value = v.Palivo;
                    }

                    if (v.Barva == null)
                    {
                        cmd.Parameters.AddWithValue("@Barva", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Barva", DbType.String).Value = v.Barva;
                    }

                    cmd.Parameters.AddWithValue("@Cena", DbType.Decimal).Value = v.Cena;
                    cmd.Parameters.AddWithValue("@Stav", DbType.Int32).Value = v.Stav;

                    if (v.MeID == 0)
                    {
                        cmd.Parameters.AddWithValue("@MeID", DbType.String).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@MeID", DbType.String).Value = v.MeID;
                    }

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //3.5 Smazani vzoidla
        public static void Delete(Vozidlo v)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_DELETE, connection))
                {
                    cmd.Parameters.Add(new SqlParameter()
                    {
                        DbType = System.Data.DbType.Int32,
                        ParameterName = "@VID",
                        Value = v.VID
                    });

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            RemoveVehicleFromAll(v);
            RemoveVehicleFromUnsold(v);
        }

        //3.6 Nova cena
        public static void NovaCena(int vID, decimal cena_nova)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("NovaCena", connection) { CommandType = System.Data.CommandType.StoredProcedure })
                {
                    cmd.Parameters.AddWithValue("@p_vid", vID);
                    cmd.Parameters.AddWithValue("@p_cena_nova", cena_nova);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //3.7 Historie ceny
        public static List<Cena> Select_cena(int id)
        {
            vyvoj_ceny.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT_CENA, connection))
                {

                    cmd.Parameters.AddWithValue("@VID", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cena c = new Cena()
                            {
                                CID = reader.GetInt32(reader.GetOrdinal("cID")),
                                Cena_predchozi = reader.GetDecimal(reader.GetOrdinal("Cena_predchozi")),
                                Cena_nova = reader.GetDecimal(reader.GetOrdinal("Cena_nova")),
                                Datum_zmeny = reader.GetDateTime(reader.GetOrdinal("Datum_zmeny")),
                                VID = reader.GetInt32(reader.GetOrdinal("vID"))
                            };
                            vyvoj_ceny.Add(c);
                        }
                    }
                }
                connection.Close();
            }

            return vyvoj_ceny;
        }

        public static List<Vozidlo> Select_Search(string znacka, string model, int rok, int tachometr)
        {
            Vozidlo v = null;
            searchVehicles.Clear();
            string SQL_SELECT_SEARCH = "SELECT * FROM \"Vozidlo\" WHERE 1=1";
            if (znacka.Length > 0) SQL_SELECT_SEARCH += " AND Znacka=@Znacka";
            if (model.Length > 0) SQL_SELECT_SEARCH += " AND Model=@Model";
            if (rok != 0) SQL_SELECT_SEARCH += " AND Rok>=@Rok";
            if (tachometr != 0) SQL_SELECT_SEARCH += " AND Tachometr<=@Tachometr";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_SELECT_SEARCH, connection))
                {
                    if (znacka.Length > 0) cmd.Parameters.AddWithValue("@Znacka", znacka);
                    if (model.Length > 0) cmd.Parameters.AddWithValue("@Model", model);
                    if (rok != 0) cmd.Parameters.AddWithValue("@Rok", rok);
                    if (tachometr != 0) cmd.Parameters.AddWithValue("@Tachometr", tachometr);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            v = new Vozidlo()
                            {
                                VID = reader.GetInt32(reader.GetOrdinal("VID")),
                                Znacka = reader.GetString(reader.GetOrdinal("Znacka")),
                                Model = reader.GetString(reader.GetOrdinal("Model")),
                                Rok = reader.GetInt32(reader.GetOrdinal("Rok")),
                                Tachometr = reader.IsDBNull(reader.GetOrdinal("Tachometr")) ? 0 : reader.GetInt32(reader.GetOrdinal("Tachometr")),
                                Motor = reader.IsDBNull(reader.GetOrdinal("Motor")) ? null : reader.GetString(reader.GetOrdinal("Motor")),
                                Prevodovka = reader.IsDBNull(reader.GetOrdinal("Prevodovka")) ? null : reader.GetString(reader.GetOrdinal("Prevodovka")),
                                Karoserie = reader.IsDBNull(reader.GetOrdinal("Karoserie")) ? null : reader.GetString(reader.GetOrdinal("Karoserie")),
                                Palivo = reader.IsDBNull(reader.GetOrdinal("Palivo")) ? null : reader.GetString(reader.GetOrdinal("Palivo")),
                                Barva = reader.IsDBNull(reader.GetOrdinal("Barva")) ? null : reader.GetString(reader.GetOrdinal("Barva")),
                                Cena = reader.GetDecimal(reader.GetOrdinal("Cena")),
                                Stav = reader.GetInt32(reader.GetOrdinal("Stav")),
                                MeID = reader.IsDBNull(reader.GetOrdinal("MeID")) ? 0 : reader.GetInt32(reader.GetOrdinal("MeID"))
                            };
                            searchVehicles.Add(v);
                        }
                    }
                }
                connection.Close();
            }
            return searchVehicles;
        }

        public static int Count_cena(int id)
        {
            int count = 0 ;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(SQL_COUNT_CENA, connection))
                {

                    cmd.Parameters.AddWithValue("@VID", id);
                    count = (int)cmd.ExecuteScalar();
                }
                connection.Close();
            }

            return count;
        }
    }
}