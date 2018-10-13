using RateMyPlace.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RateMyPlace.Pages
{
    public partial class ReviewPopup : System.Web.UI.Page
    {
        Review review;

        protected void Page_Load(object sender, EventArgs e)
        {
            review = new Review();
        }

        private void OneStarClick( object sender, EventArgs e)
        {
            review.Rating = 1;
        }

        private void TwoStarClick( object sender, EventArgs e)
        {
            review.Rating = 2;
        }

        private void ThreeStarClick(object sender, EventArgs e)
        {
            review.Rating = 3;
        }

        private void FourStarClick(object sender, EventArgs e)
        {
            review.Rating = 4;
        }

        private void FiveStarClick( object sender, EventArgs e)
        {
            review.Rating = 5;
        }

        private void AcceptClick(object sender, EventArgs e) //When the user accepts their rating as final
        {
            review.SendSQLCommand( "INSERT INTO REVIEWS VALUES (" ); //Need the review table schema for the rest of this. 
        }

        private void CancelClick( object sender, EventArgs e)
        {
            //Close the window here
        }
    }
}