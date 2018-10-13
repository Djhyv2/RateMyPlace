using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RateMyPlace.Pages
{
    public partial class SearchResults : System.Web.UI.Page
    {
        //Needs complex, overall rating, average rent cost, pet, furnished, parking, study spaces, shuttle, gym
        private static DataTable table;
        private string complex;
        private float rating = 0;
        private float rent = 0;
        private string pet = "";
        private string furnished = "";
        private string parking = "";
        private string studySpaces = "";
        private string shuttle = "";
        private string gym = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateReviews();
        }

        public void PopulateReviews()
        {
            table = Connection.RunSQL("SELECT * FROM Reviews");

            string html = "<div style= \"margin-top: 90px;\">";

            for ( int row = 0; row < table.Rows.Count; row++) //For each review
            {
                for( int col = 0; col < table.Columns.Count; col++)
                {
                    //Needs complex, overall rating, average rent cost, pet, furnished, parking, study spaces, shuttle, gym
                    switch ( col )
                    {
                        case 25:
                            complex = table.Rows[row][col].ToString();
                            break;
                        case 11:
                            if (table.Rows[row][col].ToString() == "True")
                                studySpaces = "X";
                            break;
                        case 12:
                            if (table.Rows[row][col].ToString() == "True")
                                shuttle = "X";
                            break;
                        case 14:
                            if (table.Rows[row][col].ToString() == "True")
                                furnished = "X";
                            break;
                        case 20:
                            if (table.Rows[row][col].ToString() == "True")
                                pet = "X";
                            break;
                        case 18:
                            if (table.Rows[row][col].ToString() == "True")
                                parking = "X";
                            break;
                        case 17:
                            if (table.Rows[row][col].ToString() == "True")
                                gym = "X";
                            break;
                    }
                }

                if (complex != null && rent == 0 )
                {
                    DataTable temp = Connection.RunSQL("SELECT OverallRating FROM Reviews WHERE HousingComplex = '" + complex + "';");
                    float.TryParse(temp.Rows[row][0].ToString(), out rating);

                    temp = Connection.RunSQL("SELECT Rent FROM Reviews WHERE HousingComplex = '" + complex + "';" );
                    float.TryParse(temp.Rows[row][0].ToString(), out rent);
                }

                //Needs complex, overall rating, average rent cost, pet, furnished, parking, study spaces, shuttle, gym
                html += "<table class=\"ReviewDisplay.css\">" +
                    "<th>Complex Name</th><th>Overall Rating</th><th>Average Rent</th><th>Pet Friendly</th><th>Pre-Furnished</th><th>Available Parking</th><th>Study Spaces</th><th>Free Shuttle</th><th>Free Gym</th>" +
                    "<tr><td>" + complex + "</td>" + "<td>" + rating.ToString() + "</td>" + "<td>" + rent.ToString() + "</td>" + "<td>" + pet + "</td>" + "<td>" + furnished + "</td>" +
                    "<td>" + parking + "</td>" + "<td>" + studySpaces + "</td>" + "<td>" + shuttle + "</td>" + "<td>" + gym + "</td></tr>" +
                    "</table>";
            }

            html += "</div>";

            LiteralText.Text = html;
        }

    }
}