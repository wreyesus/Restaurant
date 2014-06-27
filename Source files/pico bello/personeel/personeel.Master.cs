using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pico_bello.personeel
{
    public partial class personeel : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            classes.loginmanager lm = new classes.loginmanager();
        }
    }
}