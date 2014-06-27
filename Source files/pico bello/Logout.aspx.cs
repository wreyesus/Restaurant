using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pico_bello
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            classes.loginmanager lg = new classes.loginmanager();
            lg.destroy();
            Response.Redirect("/Default.aspx");
        }
    }
}