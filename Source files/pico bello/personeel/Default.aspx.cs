using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pico_bello.personeel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            classes.loginmanager lm = new classes.loginmanager();

            #region inlog form handling
            if (!string.IsNullOrEmpty(Request.Form["username"]) && !string.IsNullOrEmpty(Request.Form["password"]))
            {
                lm.performlogin(Request.Form["username"], Request.Form["password"]);
            }
            #endregion
        }
    }
}