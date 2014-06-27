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
    public partial class menu : System.Web.UI.Page
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
            pico_bello.classes.menu db = new pico_bello.classes.menu();
            gridMenu.DataSource = db.getmenu();
            gridMenu.DataBind();
        }

        protected void gridMenu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridMenu.EditIndex = e.NewEditIndex;
            databind();
        }
        protected void gridMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            e.Cancel = true;
            gridMenu.EditIndex = -1;
            databind();
        }

        protected void gridMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = ((Label)gridMenu.Rows[e.RowIndex].FindControl("lblID")).Text;
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            SqlConnection con = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM [menu-product] WHERE id=" + Convert.ToInt32(id), con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            databind();
        }

        protected void gridMenu_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            classes.databasemanager dm = new classes.databasemanager();
            string id = ((Label)gridMenu.Rows[e.RowIndex].FindControl("lblID")).Text;
            string type = ((TextBox)gridMenu.Rows[e.RowIndex].FindControl("txtEditType")).Text;
            string naam = ((TextBox)gridMenu.Rows[e.RowIndex].FindControl("txtEditNaam")).Text;
            string omschrijving = ((TextBox)gridMenu.Rows[e.RowIndex].FindControl("txtEditOmschrijving")).Text;
            string prijs = ((TextBox)gridMenu.Rows[e.RowIndex].FindControl("txtEditPrijs")).Text;
            string beschikbaar = ((TextBox)gridMenu.Rows[e.RowIndex].FindControl("txtEditBeschikbaar")).Text;
            dm.updatemenu(id, type, naam, omschrijving, prijs, beschikbaar);
            gridMenu.EditIndex = -1;
            databind();
            // lblMessage.Text = lblid.ToString() + " : Row updated"; 
            // email moet altijd the same blijven
        }

        protected void gridMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                classes.databasemanager dmm = new classes.databasemanager();
                string name = ((TextBox)gridMenu.FooterRow.FindControl("txtAddNaam")).Text;
                string type = ((TextBox)gridMenu.FooterRow.FindControl("txtAddType")).Text;
                string omschrijving = ((TextBox)gridMenu.FooterRow.FindControl("txtAddOmschrijving")).Text;
                string prijs = ((TextBox)gridMenu.FooterRow.FindControl("txtAddPrijs")).Text;
                string beschikbaar = ((TextBox)gridMenu.FooterRow.FindControl("txtAddPrijs")).Text;


                bool motherfuckingbeschikbaar;
                if (beschikbaar == "True")
                {
                    motherfuckingbeschikbaar = true;
                }
                else
                {
                    motherfuckingbeschikbaar = false;
                }

                dmm.insertmenu(name, type, omschrijving, prijs, motherfuckingbeschikbaar);
                databind();
            }
        }
    }
}