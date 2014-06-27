using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace pico_bello.classes
{
    public class reserveren
    {
        public int createreservation(string guests, string datestart, int kntid)
        {
            classes.databasemanager dm = new classes.databasemanager();

            int id = dm.insertreservation(guests, datestart, kntid);

            // achterhalen datumeind is onderdeel van 4-step process als voor gelijk bestellen van eten is gekozen
            // standaard tijd indien geen menus zijn gekozen = (aantal personen * 0.02 + 1) * 150

            // *** 4 step process *** //
            // 1: maak reservatie aan en vul alleen datumstart, aantal personen en klant in
            // 2: maak bestellingen op basis van de aangemaakte reservatie id in stap 1
            // 3: calculeer datumeind doormiddel van bestelling met foreign key van reservatie id
            // 4: update reservatie met nieuwe data en finish.

            // 4 step process word in volgorde aangeroepen door het script dat de reservatie wil toevoegen
            // de methodes worden verzorgd door reserveren.cs en bestelling.cs

            // *** calculatie tijd voor eten *** //
            // base tijd = bt
            // bt = 90 minuten
            // aantal personen = p
            // aantal gangen = ag
            // gemideld aantal gangen = gag 
            // gag = ag / p
            // (p * 0.02 + 1) + (gag * 0.15 + 1) * bt
            // (aantal personen * 0.02 + 1) + (gemideld aantal gangen * 0.15 + 1) * 90 = aantal minuten 

            return id;
        }

        public bool updatereservation(string id, string datestart, string dateend, string guests, string kntid, int bill, int servant)
        {

            classes.databasemanager dm = new classes.databasemanager();

            dm.updatereservation(id, datestart, dateend, guests, kntid, bill, servant);

            return true;
        }

        public bool setreservationendtime(string reservationid, string dateend)
        {
            classes.databasemanager dm = new classes.databasemanager();

            dm.updatereservationendtime(reservationid, dateend);

            return true;
        }

        public string getreservationstarttime(string reservationid)
        {
            classes.databasemanager dm = new classes.databasemanager();

            DataTable result = dm.getdatatablebyquery("select * from reservering where id='" + reservationid + "'");

            foreach (DataRow row in result.Rows)
            {
                return row["datumstart"].ToString();
            }
            return "";
        }

    }
}