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
    public class gebruiker
    {
        public DataTable getuser()
        {
            SqlConnection con = new SqlConnection();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = connectionString;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [gebruikers]", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}