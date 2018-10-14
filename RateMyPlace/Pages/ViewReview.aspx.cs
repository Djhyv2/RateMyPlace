using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static RateMyPlace.Classes.Review;

namespace RateMyPlace.Pages
{
    public partial class SearchResults : System.Web.UI.Page
    {
        //Needs complex, overall rating, average rent cost, pet, furnished, parking, study spaces, shuttle, gym

        System.Web.UI.WebControls.Button btn;

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateReviews("SELECT * FROM Reviews");
        }

        public void PopulateReviews( string statement )
        {
            DataTable table = Connection.RunSQL( statement );

            string html = GetHTMLTable("SELECT HousingComplex, OverallRating, Rent, Pets, Furnished, Parking, StudySpace, Shuttle, Gym FROM Reviews",
                "<th>Complex</th><th>Overall Rating</th><th>Rent</th><th>Pets</th><th>Furnished</th><th>Parking</th><th>StudySpace</th><th>Shuttle</th><th>Gym</th><th>Details</th>", true, 1, "DetailReviewClick");

            LiteralText.Text = "<div class=\"TableDiv\">" + html + "</div>";
        }

    }
}