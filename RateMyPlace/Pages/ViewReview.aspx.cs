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
        private static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public static string PopulateReviews()
        {
            dt = Connection.RunSQL("SELECT * FROM Reviews");

            string html = "<table>";
            //add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            }
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                }
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }

    }
}