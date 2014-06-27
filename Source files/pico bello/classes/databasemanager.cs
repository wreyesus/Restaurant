using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace pico_bello.classes
{
    public class databasemanager
    {
        #region Select methods
		
            public DataTable getdatatablebyquery(string query)
            {
                SqlConnection con = new SqlConnection();
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                con.ConnectionString = connectionString;

                try
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    return dt;
                }
                catch (NullReferenceException)
                {
                    DataTable empty = new DataTable();
                    return empty;
                }
                catch (SqlException)
                {
                    DataTable empty = new DataTable();
                    return empty;
                }
            }

            public DataTable getarraybyquery(string query)
        {
            SqlConnection con = new SqlConnection();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = connectionString;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                con.Open();
                return dt;
            }
            catch (NullReferenceException)
            {
                DataTable empty = new DataTable();
                return empty;
            }
            catch (SqlException)
            {
                DataTable empty = new DataTable();
                return empty;
            }
        }

        #endregion

        #region Insert methods

            public bool insertaccount(string name, string password, string customerid, string role)
        {
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                string sql = "insert into gebruikers ([gebruikersnaam], [wachtwoord], [klantid], [rol]) values(@name,@password,@customerid,@role)";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@customerid", customerid);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

            public bool insertcustomer(string name, string adres, string telefon, string email)
        {
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                string sql = "INSERT into klant ([naam], [adres], [telefoonnummer], [email]) values(@name,@adres,@telefon,@email)";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@adres", adres);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

            public bool insertmenu(string name, string type, string omschrijving, string prijs, bool beschikbaar)
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    string sql = "INSERT into [menu-product] ([naam], [type], [omschrijving], [prijs], [beschikbaar]) values(@name,@type,@omschrijving,@prijs,@beschikbaar)";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@omschrijving", omschrijving);
                        cmd.Parameters.AddWithValue("@prijs", prijs);
                        cmd.Parameters.AddWithValue("@beschikbaar", beschikbaar);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }

            public int insertreservation(string guests, string datestart, int kntid)
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    string sql = "INSERT into reservering ([personen], [datumstart], [klant]) values(@guests,@datestart,@kntid)";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@guests", guests);
                        cmd.Parameters.AddWithValue("@datestart", datestart);
                        cmd.Parameters.AddWithValue("@kntid", kntid);
                        cmd.ExecuteNonQuery();

                        DataTable result = getdatatablebyquery("select * from reservering where personen='" + guests + "' AND datumstart='" + datestart + "' AND klant='" + kntid + "'");
                        foreach (DataRow row in result.Rows)
                        {
                            int idtemp = Convert.ToInt16(row["id"]);
                            return idtemp;
                        }
                        return 0;
                    }
                }
            }

            public bool insertorder(string reservation, string menu)
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    string sql = "INSERT into bestelling ([reservering], [menu]) values(@reservation,@menu)";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@reservation", reservation);
                        cmd.Parameters.AddWithValue("@menu", menu);
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }

            public bool insertuser(string gebruikersnaam, string wachtwoord, string klantid, string rol)
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    string sql = "INSERT into [gebruikers] ([gebruikersnaam], [wachtwoord], [klantid], [rol]) values(@gebruikersnaam,@wachtwoord,@klantid,@rol)";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
                        cmd.Parameters.AddWithValue("@wachtwoord", wachtwoord);
                        cmd.Parameters.AddWithValue("@klantid", klantid);
                        cmd.Parameters.AddWithValue("@rol", rol);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }

        #endregion  

        #region Update methods

            public bool updatecustomer(string name, string adres, string telefon, string email)
        {
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                string sql = "UPDATE klant SET [naam]=@name,[adres]=@adres,[telefoonnummer]=@telefon WHERE [email]=@email";
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@adres", adres);
                    cmd.Parameters.AddWithValue("@telefon", telefon);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
        }

            public bool updatemenu(string id,string naam, string type, string omschrijving, string prijs, string beschikbaar)
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    string sql = "UPDATE [menu-product] SET [naam]=@naam,[type]=@type, [omschrijving]=@omschrijving,[prijs]=@prijs,[beschikbaar]=@beschikbaar WHERE [id]=@id";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@type", type);
                        cmd.Parameters.AddWithValue("@naam", naam);
                        cmd.Parameters.AddWithValue("@omschrijving", omschrijving);
                        cmd.Parameters.AddWithValue("@prijs", prijs);
                        cmd.Parameters.AddWithValue("@beschikbaar", beschikbaar);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }

            public bool updatereservationendtime(string reservationid, string dateend)
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {

                    DateTime datest = new DateTime();
                    DateTime.TryParse(dateend, out datest);
                    string datestartsemifinal = datest.ToString("yyyy-MM-dd HH:mm:ss tt");

                    string sql = "UPDATE reservering SET [datumeind]=@dateend WHERE [id]=@id";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@id", reservationid);
                        cmd.Parameters.AddWithValue("@dateend", datestartsemifinal);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }

            public bool updatereservation(string id, string datestart, string dateend, string guests, string kntid, int bill, int servant)
            {
                //DateTime datetm = new DateTime();
                //DateTime.TryParse(dateend, out datetm);
                //string dateendsemifinal = datetm.ToString("yyyy-MM-dd HH:mm:00 tt");
                //DateTime dateendfinal = new DateTime();
                //DateTime.TryParse(dateendsemifinal, out dateendfinal);

                //DateTime datest = new DateTime();
                //DateTime.TryParse(datestart, out datest);
                //string datestartsemifinal = datest.ToString("yyyy-MM-dd HH:mm:00 tt");
                //DateTime datestartfinal = new DateTime();
                //DateTime.TryParse(datestartsemifinal, out datestartfinal);

                // zoveel getyf voor deze shit en uiteindelijk had het er geen scheit mee te maken lekker
                // lekker nachten doorhalen voor asp.net gezeik en het nog niet af hebben
                // lekker een shit taal leren die NIEMAND meer gebruikt want het is allemaal asp.net MVC tegenwoordig!!!

                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    string sql = "UPDATE reservering SET [datumstart]=@datestart, [datumeind]=@dateend, [personen]=@guests, [klant]=@kntid, [rekening]=@bill, [bediende]=@servant WHERE [id]=@id";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@datestart", datestart);
                        cmd.Parameters.AddWithValue("@dateend", dateend);
                        cmd.Parameters.AddWithValue("@guests", guests);
                        cmd.Parameters.AddWithValue("@kntid", kntid);
                        cmd.Parameters.AddWithValue("@bill", bill);
                        cmd.Parameters.AddWithValue("@servant", servant);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }

            public bool updateuser(string id, string gebruikersnaam, string wachtwoord, string klantid, string rol)
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    string sql = "UPDATE [gebruikers] SET [gebruikersnaam]=@gebruikersnaam,[wachtwoord]=@wachtwoord, [klantid]=@klantid,[rol]=@rol WHERE [id]=@id";
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
                        cmd.Parameters.AddWithValue("@wachtwoord", wachtwoord);
                        cmd.Parameters.AddWithValue("@klantid", klantid);
                        cmd.Parameters.AddWithValue("@rol", rol);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }

        #endregion   
    }
}