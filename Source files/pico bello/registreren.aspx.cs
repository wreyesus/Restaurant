using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pico_bello
{
    public partial class registreren : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            classes.loginmanager lm = new classes.loginmanager();

            #region register form handling
            if (!string.IsNullOrEmpty(Request.Form["naam"]) && !string.IsNullOrEmpty(Request.Form["adres"]) && !string.IsNullOrEmpty(Request.Form["email"]) && !string.IsNullOrEmpty(Request.Form["telefoonnummer"]) && !string.IsNullOrEmpty(Request.Form["wachtwoord"]))
            {
                error.Visible = true;
                error.Text = lm.createaccount(Request.Form["email"], Request.Form["wachtwoord"], Request.Form["naam"], Request.Form["adres"], Request.Form["telefoonnummer"]);
            }
            else if (!string.IsNullOrEmpty(Request.Form["naam"]) || !string.IsNullOrEmpty(Request.Form["adres"]) || !string.IsNullOrEmpty(Request.Form["email"]) || !string.IsNullOrEmpty(Request.Form["telefoonnummer"]) || !string.IsNullOrEmpty(Request.Form["wachtwoord"]))
            {
                error.Visible = true;
                error.Text = "Alle velden invullen.";
            }
            #endregion
        }
    }
}