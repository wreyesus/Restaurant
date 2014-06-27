using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace pico_bello.personeel
{
    public partial class klant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            pico_bello.classes.klanten db = new pico_bello.classes.klanten();
            gridKlanten.DataSource = db.getcustomers();
            gridKlanten.DataBind();
        }

        protected void gridKlanten_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridKlanten.EditIndex = e.NewEditIndex;
            databind();
        }
        protected void gridKlanten_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            gridKlanten.EditIndex = -1;
            databind();
        }

        protected void gridKlanten_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string id = ((Label)gridKlanten.Rows[e.RowIndex].FindControl("lblid")).Text;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM klant WHERE id=" + Convert.ToInt32(id), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            databind();
            //lblMessage.Text = id.ToString() + " : Row was Deleted.";
        }

        protected void gridKlanten_RowUpdating(object sender, GridViewUpdateEventArgs e)
        { 
           classes.databasemanager dm = new classes.databasemanager();
           string naam = ((TextBox)gridKlanten.Rows[e.RowIndex].FindControl("txtEditNaam")).Text;
           string adres = ((TextBox)gridKlanten.Rows[e.RowIndex].FindControl("txtEditAdres")).Text;
           string telefon = ((TextBox)gridKlanten.Rows[e.RowIndex].FindControl("txtEditTelefoon")).Text;
           string email = ((TextBox)gridKlanten.Rows[e.RowIndex].FindControl("txtEditEmail")).Text;
           dm.updatecustomer(naam, adres, telefon, email);
           gridKlanten.EditIndex = -1;
           databind();
          // lblMessage.Text = lblid.ToString() + " : Row updated"; 
          // email moet altijd the same blijven
        }
    }
}