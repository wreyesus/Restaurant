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
    public class menu
    {

        public DataTable getmenu()
        {
            SqlConnection con = new SqlConnection();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = connectionString;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [menu-product] ORDER BY (CASE [type] WHEN 'Lunch' THEN 1 WHEN 'Voorgerechten' THEN 2 WHEN 'Hoofdgerechten' THEN 3 WHEN 'Desserts' THEN 4 WHEN 'Dranken' THEN 5 ELSE 100 END) ASC ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}