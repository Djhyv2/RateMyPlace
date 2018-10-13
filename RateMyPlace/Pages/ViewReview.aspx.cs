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
        private static DataTable table;

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateReviews();
        }

        public void PopulateReviews()
        {
            table = Connection.RunSQL("SELECT * FROM Reviews");

            string html = "<div style= \"margin-top: 90px;\"><table>";
            html += "<th>Username</th><th>Overall Rating</th><th>Noise Rating</th><th>Safety Rating</th>" +
                "<th>Maintenance</th><th>Lease Start Date</th><th>Lease End Date</th><th>Distance from Campus</th>" +
                "<th>Pros</th><th>Cons</th><th>Study Space</th><th>Shuttle</th><th>Wifi</th>" +
                "<th>Wifi</th><th>Furnished</th><th>Cable</th><th>Trash Services</th>" +
                "<th>Gym</th><th>Parking</th><th>Parking Fee</th><th>Pets</th><th>Pets Fee</th>" +
                "<th>Misc Fees</th><th>Rent</th><th>Utilities</th><th>Housing Complex</th>";

                for ( int row = 0; row < table.Rows.Count; row++)
                {
                    html += "<tr>";

                    for( int col = 1; col < table.Columns.Count; col++)
                    {
                            html += "<td>";

                            html += table.Rows[row][col].ToString();

                            html += "</td>";
                    }

                    html += "</tr>";
                }

            html += "</table></div>";

            LiteralText.Text = html;
        }

    }
}