using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;

namespace pico_bello.classes
{
    public class loginmanager
    {
        public loginmanager()
        {
            try
            {
                if ((int)HttpContext.Current.Session["role"] == 0)
                {
                }
            }
            catch (NullReferenceException)
            {
                HttpContext.Current.Session["role"] = 0;
            }
        }

        public bool performlogin(string username, string password)
        {
            classes.databasemanager dm = new classes.databasemanager();
            DataTable result = dm.getdatatablebyquery("select * from gebruikers where gebruikersnaam='" + username + "' and wachtwoord='" + password + "'");

            foreach (DataRow row in result.Rows)
            {
                HttpContext.Current.Session.Add("username", row["gebruikersnaam"].ToString());
                HttpContext.Current.Session["role"] = (int)row["rol"];
            }
            return false;
        }

        public string createaccount(string email, string password, string name, string adres, string telefon)
        {
            classes.databasemanager dm = new classes.databasemanager();

            // some impressive input validation
            #region gebruikersnaam
            DataTable user = dm.getdatatablebyquery("select * from gebruikers where gebruikersnaam='" + email + "'");
            foreach (DataRow row in user.Rows)
            {
                return "Gebruikersnaam bestaat al.";
                // deze werkt optimaal hier kom je niet omheen.
            }
            #endregion

            #region adres
            if (!Regex.IsMatch(adres, @"[^0-9a-zA-Z]"))
            {
                return "Adres moet uit straatnaam en nummer bestaan.";
                // je addres kan zo wel "a9" zijn,
                // deze regular expression is niet ideaal.
            }
            #endregion

            #region relefoonnummer
            if (!Regex.IsMatch(telefon, @"(\s*(\S)\s*){7,}"))
            {
                return "Telefoonnummer moet minimaal uit 8 characters bestaan.";
            }

            try
            {
                int telefonnumber = Convert.ToInt32(telefon);
                // moet toch een int naar de database,
                // kunnen we wel gelijk als validatie gebruiken.
            }
            catch(FormatException)
            {
                return "Telefoonnummer kan alleen uit getallen bestaan.";
            }
            #endregion

            #region wachtwoord
            if (!Regex.IsMatch(password, @"(\s*(\S)\s*){7,}"))
            {
                return "Wachtwoord moet minimaal uit 8 characters bestaan.";
            }
            #endregion

            #region aanmaken account

            dm.insertcustomer(name, adres, telefon, email);

            DataTable customerid = dm.getdatatablebyquery("SELECT id FROM klant WHERE email='" + email + "'");
            foreach (DataRow row in customerid.Rows)
            {
                string customer = row["id"].ToString();
                dm.insertaccount(email, password, customer, "2");
            }
            #endregion

            return "Account geregistreerd.";
        }

        #region checks and controls

        ///<summary>
        ///<para>True if logged in</para>
        ///<para>Otherwise false</para>
        ///</summary>
        public bool checklogin()
        {
            try
            {
                if (HttpContext.Current.Session["username"] == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        ///<summary>
        ///<para>Returns role level as int</para>
        ///</summary>
        public int checkrole()
        {
            return (int)HttpContext.Current.Session["role"];
        }

        #endregion

        public void destroy()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}