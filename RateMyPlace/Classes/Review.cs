using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace RateMyPlace.Classes
{
    public class Review
    {
        private int id;
        private User user;
        private int overallRating;
        private int noiseRating;
        private int safetyRating;
        private int maintenanceRating;
        private string leaseStart;
        private string leaseEnd;
        private float rent;
        private float utility;
        private float distance;
        private string pros;
        private string cons;
        private bool studySpace;
        private bool shuttle;
        private bool wifi;
        private bool furnished;
        private bool tv;
        private bool pet;
        private bool trash;
        private bool gym;
        private bool parking;
        private float parkingCost;
        private float petFee;
        private float miscFee;

        public Review()
        {
            studySpace = false;
            shuttle = false;
            wifi = false;
            furnished = false;
            tv = false;
            pet = false;
            trash = false;
            gym = false;
            parking = false;
        }

        /* HOW TO USE: GetHTMLTable
         * 
         * If you would not like a button or checkbox in your resulting table, use first consctructor.
         * For the first constructor, pass your sql statement and the headers for the table in HTML. The
         * The first column in the table MUST be the primary key id.
         * For example:
         * 
         *  GetHTMLTable( SELECT id, name, age FROM table, <th>Name</th><th>Age</th>)
         *  
         * If you would like to have buttons or checkboxes included, there are a few more parameters.
         * bool button is for whether you want a button or a checkbox (true for button, false for checkbox).
         * int num is the number of buttons or checkboxes on each row
         * string interactWith is for the name of the button function in the javascript file.
         * The first column in the table MUsT be the primary key id.
         * For example:
         *  GetHTMLTable( SELECT id, name, age FROM table, <th>Name</th><th>Age</th>, true, 2, MyClickFunction ) 
         * 
         */

        public static string GetHTMLTable( string sqlStatement, string headers )
        {
            string html = "";
            DataTable table = new DataTable();

            table = Connection.RunSQL(sqlStatement);

            html += "<table class=\"ReviewStyle.css\">" + headers; 

            for( int row = 0; row < table.Rows.Count; row++)
            {
                html += "<tr>";

                for( int col = 0; col < table.Columns.Count; col++)
                {
                    html += "<td>" + table.Rows[row][col].ToString() + "</td>";
                }

                html += "</tr>";
            }

            html += "</table>";

            return html;
        }

        public static string GetHTMLTable(string sqlStatement, string headers, bool button, int num, string interactWith ) //button = true if button is to be shown, false if a checkbox. num is the number of buttons to add. interactWith is the name of the element being interacted with in the .js file.
        {
            string html = "";
            DataTable table = new DataTable();

            table = Connection.RunSQL(sqlStatement);

            html += "<table class=\"ReviewStyle.css\">" + headers;

            for (int row = 0; row < table.Rows.Count; row++)
            {
                html += "<tr>";

                for (int col = 1; col < table.Columns.Count; col++)
                {
                    html += "<td>" + table.Rows[row][col].ToString() + "</td>";
                }

                if (button)
                {
                    for( int i = 0; i < num; i++ )
                        html += "<td><button id=\'" + row.ToString() + "\' class=\'AdditionalReviewInfo\' onclick=\'" + interactWith + "(" + row.ToString() + ")\'>...</button></td>";
                }
                else if( !button)
                {
                    for (int i = 0; i < num; i++)
                        html += "<td><input type=\'checkbox\' name=\'Compare\' value=\'\'></td>";
                }

                html += "</tr>";
            }

            html += "</table>";

            return html;
        }

        public void SendToDatabase() //Sends everything to the database as a new entry from anonymous user.
        {
            //RunNonQuerySQL( SQL statement )
            DataTable table = new DataTable();

            table = Connection.RunSQL( "INSERT INTO Reviews (overallrating, noiserating, safetyrating, maintenancerating, " +
                "leasestart, leaseend, rent, utility, distance, pros, cons, studyspace, shuttle, wifi, furnished, tv, pet, " +
                "trash, gym, parking, parkingcost, petfee, miscfee) VALUES (" + overallRating.ToString() +
                ", " + noiseRating.ToString() + ", " + safetyRating.ToString() + ", " + maintenanceRating.ToString() + ", " + leaseStart.ToString() +
                ", " + leaseEnd.ToString() + ", " + rent.ToString() + ", " + utility.ToString() + ", " + distance.ToString() + ", " + 
                pros + ", " + cons + ", " + studySpace.ToString() + ", " + shuttle.ToString() + ", " + wifi.ToString() + ", " + furnished.ToString() +
                ", " + tv.ToString() + ", " + pet.ToString() + ", " + trash.ToString() + ", " + gym.ToString() + ", " + 
                parking.ToString() + ", " + parkingCost.ToString() + ", " + petFee.ToString() + ", " + miscFee.ToString() + ")" );

            string tableId = table.Rows[0]["id"].ToString();
            Int32.TryParse(tableId, out this.id);
        }

        public void SendToDatabase( User user ) //Sends everything to the database as a new entry from a logged in user.
        {
            DataTable table = new DataTable();
            //Send to database logic here
            table = Connection.RunSQL("INSERT INTO Reviews (id, overallrating, noiserating, safetyrating, maintenancerating, " +
               "leasestart, leaseend, rent, utility, distance, pros, cons, studyspace, shuttle, wifi, furnished, tv, pet, " +
               "trash, gym, parking, parkingcost, petfee, miscfee, user) VALUES (" + id.ToString() + ", " + overallRating.ToString() +
               ", " + noiseRating.ToString() + ", " + safetyRating.ToString() + ", " + maintenanceRating.ToString() + ", " + leaseStart.ToString() +
               ", " + leaseEnd.ToString() + ", " + rent.ToString() + ", " + utility.ToString() + ", " + distance.ToString() + ", " +
               pros + ", " + cons + ", " + studySpace.ToString() + ", " + shuttle.ToString() + ", " + wifi.ToString() + ", " + furnished.ToString() +
               ", " + tv.ToString() + ", " + pet.ToString() + ", " + trash.ToString() + ", " + gym.ToString() + ", " +
               parking.ToString() + ", " + parkingCost.ToString() + ", " + petFee.ToString() + ", " + miscFee.ToString() + 
               ", " + user.Username + ")");

            //Set review id generated by the table to id
            string tableId = table.Rows[0]["id"].ToString();
            Int32.TryParse(tableId, out this.id);
        }

        public DataTable GetTable() //Gets the datatable from the database for this review
        {
            return Connection.RunSQL( "SELECT * FROM Reviews WHERE id = " + id.ToString() ); 
        }

        public int OverallRating { get => overallRating; set => overallRating = value; }
        public int NoiseRating { get => noiseRating; set => noiseRating = value; }
        public int SafetyRating { get => safetyRating; set => safetyRating = value; }
        public int MaintenanceRating { get => maintenanceRating; set => maintenanceRating = value; }
        public string LeaseStart { get => leaseStart; set => leaseStart = value; }
        public string LeaseEnd { get => leaseEnd; set => leaseEnd = value; }
        public float Rent { get => rent; set => rent = value; }
        public float Utility { get => utility; set => utility = value; }
        public float Distance { get => distance; set => distance = value; }
        public string Cons { get => cons; set => cons = value; }
        public string Pros { get => pros; set => pros = value; }
        public bool Shuttle { get => shuttle; set => shuttle = value; }
        public bool StudySpace { get => studySpace; set => studySpace = value; }
        public bool Wifi { get => wifi; set => wifi = value; }
        public bool Furnished { get => furnished; set => furnished = value; }
        public bool Tv { get => tv; set => tv = value; }
        public bool Pet { get => pet; set => pet = value; }
        public bool Trash { get => trash; set => trash = value; }
        public bool Gym { get => gym; set => gym = value; }
        public float ParkingCost { get => parkingCost; set => parkingCost = value; }
        public bool Parking { get => parking; set => parking = value; }
        public float PetFee { get => petFee; set => petFee = value; }
        public float MiscFee { get => miscFee; set => miscFee = value; }
    }
}