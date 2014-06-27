using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace pico_bello.personeel
{
    public partial class wijzigres : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Form["id"]) && !string.IsNullOrEmpty(Request.Form["datumstart"]) && !string.IsNullOrEmpty(Request.Form["datumeind"]) && !string.IsNullOrEmpty(Request.Form["personen"]) && !string.IsNullOrEmpty(Request.Form["klant"]))
            {
                classes.reserveren res = new classes.reserveren();

                string datumstart = Request.Form["datumstart"];
                string datumeind = Request.Form["datumeind"];
                string personen = Request.Form["personen"];
                string klant = Request.Form["klant"];
                string id = Request.Form["id"];

                try
                {
                    int temp = Convert.ToInt32(id);
                    id = temp.ToString();
                }
                catch (FormatException)
                {
                    reserveererror.Text = "Ja je moet niet met hidden fields kloten LUL!";
                }

                try
                {
                    int temp = Convert.ToInt32(personen);
                    id = temp.ToString();
                }
                catch (FormatException)
                {
                    reserveererror.Text = "Personen dient nummer te zijn";
                }

                try
                {
                    int temp = Convert.ToInt32(klant);
                    id = temp.ToString();
                }
                catch (FormatException)
                {
                    reserveererror.Text = "Klant id dient nummer te zijn";
                }

                DateTime datestart;
                try
                {

                    DateTime.TryParseExact(datumstart, "MM-dd-yyyy HH:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out datestart);

                    DateTime dateend;
                    try
                    {

                        DateTime.TryParseExact(datumeind, "MM-dd-yyyy HH:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateend);

                        if (reserveererror.Text == "")
                        {
                            res.updatereservation(id, datumstart, datumeind, personen, klant, 0, 0);
                            reserveererror.Text = "upgedate";
                        }
                    }
                    catch (Exception)
                    {
                        reserveererror.Text = "Geen geldige datum voor eind";
                    }
                }
                catch (Exception)
                {
                    reserveererror.Text = "Geen geldige datum voor start";
                }                
            }
        }
    }
}