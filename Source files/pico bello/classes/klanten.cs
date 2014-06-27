using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace pico_bello.classes
{
    public class klanten
    {
        public DataTable getcustomers()
        {
            SqlConnection con = new SqlConnection();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = connectionString;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM klant", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        ///<summary>
        ///<para>Creates customer if email unused</para>
        ///<para>Updates customer info in email known</para>
        ///</summary>
        public bool customerupdate(string name, string adres, string telefon, string email)
        {
            classes.databasemanager dm = new classes.databasemanager();
            bool update = false;

            DataTable user = dm.getdatatablebyquery("select * from klant where email='" + email + "'");
            foreach (DataRow row in user.Rows)
            {
                update = true;
                dm.updatecustomer(name, adres, telefon, email);
            }

            if (update == false)
            {
                dm.insertcustomer(name, adres, telefon, email);
            }

            return true;
        }


        ///<summary>
        ///<para>Finds customer id based on email</para>
        ///<para>Returns id as int(16) or 0 if not found</para>
        ///</summary>
        public int getcustomeridbyemail(string email)
        {
            classes.databasemanager dm = new classes.databasemanager();
            bool update = false;

            DataTable result = dm.getdatatablebyquery("select * from klant where email='" + email + "'");
            foreach (DataRow row in result.Rows)
            {
                update = true;
                int id = Convert.ToInt16(row["id"]);
                return id;
            }

            if (update == false)
            {
                return 0;
            }
            return 0;
        }

        ///<summary>
        ///<para>Finds customer id based on login</para>
        ///<para>Returns id as int(16) or 0 if not found</para>
        ///</summary>
        public int getcustomeridbylogin()
        {
            classes.databasemanager dm = new classes.databasemanager();
            bool update = false;

            string username = (string)HttpContext.Current.Session["username"];

            DataTable result = dm.getdatatablebyquery("select * from gebruikers where gebruikersnaam='" + username + "'");
            foreach (DataRow row in result.Rows)
            {
                update = true;
                int id = Convert.ToInt16(row["klantid"]);
                return id;
            }

            if (update == false)
            {
                return 0;
            }
            return 0;
        }
    }
}