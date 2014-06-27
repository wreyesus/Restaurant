using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace pico_bello.classes
{
    public class bestelling
    {
        ///<summary>
        ///<para>Finds customer id based on email</para>
        ///<para>Returns id as int(16) or 0 if not found</para>
        ///</summary>
        public int getorderbyreservationid(int id)
        {
            classes.databasemanager dm = new classes.databasemanager();
            bool update = false;

            string tempid = id.ToString();

            DataTable result = dm.getdatatablebyquery("select * from bestelling where reservering='" + tempid + "'");
            foreach (DataRow row in result.Rows)
            {
                update = true;
                int idtemp = Convert.ToInt16(row["id"]);
                return idtemp;
            }

            if (update == false)
            {
                return 0;
            }
            return 0;
        }

        public bool insertorder(string menuid, string reservation)
        {
            classes.databasemanager dm = new classes.databasemanager();
            dm.insertorder(reservation, menuid);
            return true;
        }
        
    }
}