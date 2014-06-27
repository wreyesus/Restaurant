using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace pico_bello.personeel
{
    public partial class gebruikers : System.Web.UI.Page
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
            pico_bello.classes.gebruiker db = new pico_bello.classes.gebruiker();
            gridGebruiker.DataSource = db.getuser();
            gridGebruiker.DataBind();
        }

        protected void gridGebruiker_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridGebruiker.EditIndex = e.NewEditIndex;
            databind();
        }
        protected void gridGebruiker_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            gridGebruiker.EditIndex = -1;
            databind();
        }

        protected void gridGebruiker_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = ((Label)gridGebruiker.Rows[e.RowIndex].FindControl("lblID")).Text;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM [gebruikers] WHERE id=" + Convert.ToInt32(id), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            databind();
        }

        protected void gridGebruiker_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            classes.databasemanager dm = new classes.databasemanager();
            string id = ((Label)gridGebruiker.Rows[e.RowIndex].FindControl("lblID")).Text;
            string gebruikersnaam = ((TextBox)gridGebruiker.Rows[e.RowIndex].FindControl("txtEditNaam")).Text;
            string wachtwoord = ((TextBox)gridGebruiker.Rows[e.RowIndex].FindControl("txtEditWachtwoord")).Text;
            string klantid = ((TextBox)gridGebruiker.Rows[e.RowIndex].FindControl("txtEditKlantid")).Text;
            string rol = ((TextBox)gridGebruiker.Rows[e.RowIndex].FindControl("txtEditRol")).Text;
            dm.updateuser(id, gebruikersnaam, wachtwoord, klantid, rol);
            gridGebruiker.EditIndex = -1;
            databind();
        }

        protected void gridGebruiker_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                classes.databasemanager dmm = new classes.databasemanager();
                string gebruikersnaam = ((TextBox)gridGebruiker.FooterRow.FindControl("txtAddNaam")).Text;
                string wachtwoord = ((TextBox)gridGebruiker.FooterRow.FindControl("txtAddWachtwoord")).Text;
                string klantid = ((TextBox)gridGebruiker.FooterRow.FindControl("txtAddKlantid")).Text;
                string rol = ((TextBox)gridGebruiker.FooterRow.FindControl("txtAddRol")).Text;
                dmm.insertuser(gebruikersnaam, wachtwoord, klantid, rol);
                databind();
            }
        }
    }
}