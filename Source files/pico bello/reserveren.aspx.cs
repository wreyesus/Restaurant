using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;

namespace pico_bello
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            classes.loginmanager lm = new classes.loginmanager();

            reserveererror.Text = "";

            #region inlog form handling
            if (!string.IsNullOrEmpty(Request.Form["username"]) && !string.IsNullOrEmpty(Request.Form["password"]))
            {
                lm.performlogin(Request.Form["username"], Request.Form["password"]);
            }
            #endregion

            #region reserveer form handling
            if (!string.IsNullOrEmpty(Request.Form["gasten"]) && !string.IsNullOrEmpty(Request.Form["datum"]))
            {

                classes.databasemanager dm = new classes.databasemanager();

                string name = Request.Form["naam"];
                string email = Request.Form["email"];
                string adres = Request.Form["adres"];
                string telefon = Request.Form["telefoonnummer"];

                string guests = Request.Form["gasten"];
                string date = Request.Form["datum"];

                if (lm.checklogin() == false) // we need to validate user inputs if theres no user
                {
                    // some borrowed code from loginmanager.cs, oops well there goes D.R.Y. #whatever
                    #region no account data validation
                    if (!string.IsNullOrEmpty(Request.Form["email"]) && !string.IsNullOrEmpty(Request.Form["naam"]) && !string.IsNullOrEmpty(Request.Form["adres"]) && !string.IsNullOrEmpty(Request.Form["telefoonnummer"]))
                    {
                        

                        #region gebruikersnaam
                        DataTable user = dm.getdatatablebyquery("select * from gebruikers where gebruikersnaam='" + email + "'");
                        foreach (DataRow row in user.Rows)
                        {
                            reserveererror.Text = reserveererror.Text + " " + "Gebruiker heeft een account.";
                            // deze werkt optimaal hier kom je niet omheen.
                        }
                        #endregion

                        #region adres
                        if (!Regex.IsMatch(adres, @"[^0-9a-zA-Z]"))
                        {
                            reserveererror.Text = reserveererror.Text + " " + "Adres moet uit straatnaam en nummer bestaan.";
                            // je addres kan zo wel "a9" zijn,
                            // deze regular expression is niet ideaal.
                        }
                        #endregion

                        #region relefoonnummer
                        if (!Regex.IsMatch(telefon, @"(\s*(\S)\s*){7,}"))
                        {
                            reserveererror.Text = reserveererror.Text + " " + "Telefoonnummer moet minimaal uit 8 characters bestaan.";
                        }

                        try
                        {
                            int telefonnumber = Convert.ToInt32(telefon);
                            // moet toch een int naar de database,
                            // kunnen we wel gelijk als validatie gebruiken.
                        }
                        catch (FormatException)
                        {
                            reserveererror.Text = reserveererror.Text + " " + "Telefoonnummer kan alleen uit getallen bestaan.";
                        }
                        catch (OverflowException)
                        {
                            reserveererror.Text = reserveererror.Text + " " + "Telefoonnummer kan nooit zo lang zijn.";
                        }
                        #endregion
                    }
                    #endregion
                }

                #region form data validation
                try
                {
                    int gasten = Convert.ToInt32(Request.Form["gasten"]);
                    if (gasten > 12)
                    {
                        reserveererror.Text = reserveererror.Text + " " + "Reserveringen met meer dan 12 gasten dienen telefonisch te worden afgenomen.";
                    }
                }
                catch (FormatException)
                {
                    reserveererror.Text = reserveererror.Text + " " + "Gasten moet een aantal zijn.";
                }

                if (string.IsNullOrEmpty(Request.Form["voorwaarden"]) && Request.Form["voorwaarden"] != "on")
                {
                    reserveererror.Text = reserveererror.Text + " " + "Je moet de voorwaarden accepteren.";
                }

                try
                {
                    DateTime datetm = new DateTime();
                    DateTime.TryParse(Request.Form["datum"], out datetm);

                    //new System.Globalization.CultureInfo("en-US")
                    // MM/dd/yyyy hh:mm tt
                    //reserveererror.Text = date.ToString();
                }
                catch (FormatException)
                {
                    reserveererror.Text = reserveererror.Text + " " + "Het datum en tijd format zijn invalide.";
                }
                #endregion  

                bool bestellen = true;

                if (string.IsNullOrEmpty(Request.Form["bestellen"]) && Request.Form["bestellen"] != "on")
                {
                    bestellen = false;
                }

                if (reserveererror.Text == "") // quirky no error validation
                {
                    if (lm.checklogin() == false)
                    {
                        classes.reserveren res = new classes.reserveren();
                        classes.klanten knt = new classes.klanten();
                        classes.bestelling bes = new classes.bestelling();

                        knt.customerupdate(name, adres, telefon, email);
                        int kntid = knt.getcustomeridbyemail(email);
                        int order = res.createreservation(guests, date, kntid);
                        orders(bestellen, order);
                        if (bes.getorderbyreservationid(order) == 0) // returns only 0 when no orders
                        {
                            DateTime datetm = new DateTime();
                            DateTime.TryParse(res.getreservationstarttime(order.ToString()), out datetm);
                            datetm = datetm.AddHours(2);
                            datetm = datetm.AddMinutes(30);
                            string datecomplete = datetm.ToString();
                            res.setreservationendtime(order.ToString(), datecomplete);
                        }
                        else
                        {
                            DateTime datetm = new DateTime();
                            DateTime.TryParse(res.getreservationstarttime(order.ToString()), out datetm);
                            datetm = datetm.AddHours(2);
                            datetm = datetm.AddMinutes(30);
                            string datecomplete = datetm.ToString();
                            res.setreservationendtime(order.ToString(), datecomplete);
                        }
                    }
                    else
                    {
                        classes.reserveren res = new classes.reserveren();
                        classes.klanten knt = new classes.klanten();
                        classes.bestelling bes = new classes.bestelling();

                        int kntid = knt.getcustomeridbylogin();
                        int order = res.createreservation(guests, date, kntid);
                        orders(bestellen, order);
                        if (bes.getorderbyreservationid(order) == 0) // returns only 0 when no orders
                        {
                            DateTime datetm = new DateTime();
                            DateTime.TryParse(res.getreservationstarttime(order.ToString()), out datetm);
                            datetm = datetm.AddHours(2);
                            datetm = datetm.AddMinutes(30);
                            string datecomplete = datetm.ToString();
                            res.setreservationendtime(order.ToString(), datecomplete);
                        }
                        else
                        {
                            DateTime datetm = new DateTime();
                            DateTime.TryParse(res.getreservationstarttime(order.ToString()), out datetm);
                            datetm = datetm.AddHours(2);
                            datetm = datetm.AddMinutes(30);
                            string datecomplete = datetm.ToString();
                            res.setreservationendtime(order.ToString(), datecomplete);
                        }
                    }
                    reserveererror.Text = "U reservering is opgeslagen";
                    Response.Write("<script>alert('Je hebt gereserveerd!!!')</script>");
                }
            }
            #endregion
        }

        private void orders(bool order, int orderid)
        {
            if (order == true)
            {
                try
                {
                    int temprow = 0;
                    int rows = Convert.ToInt16(Request.Form["numberrows"]);
                    classes.bestelling bes = new classes.bestelling();
                    while (temprow <= rows)
                    {
                        temprow = temprow + 1;
                        Regex regex = new Regex("[0-9]");
                        foreach (string s in Request.Params.Keys )     
                        {
                            if (regex.IsMatch(s))
                            {
                                if (s == temprow.ToString())
                                {
                                    if (Request.Form[temprow.ToString()] != "")
                                    {
                                        if (regex.IsMatch(Request.Form[temprow.ToString()]))
                                        {
                                            if (Convert.ToInt16(Request.Form[temprow.ToString()]) > 0)
                                            {
                                                int tempinsert = 0;
                                                while (tempinsert < Convert.ToInt16(Request.Form[temprow.ToString()]))
                                                {
                                                    tempinsert = tempinsert + 1;
                                                    bes.insertorder(temprow.ToString(), orderid.ToString());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    reserveererror.Text = reserveererror.Text + "Error met verwerken van bestellingen";
                } 
            }
        }
    }
}
