using RateMyPlace.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private void OverallOneStarClick( object sender, EventArgs e)
        {
            review.OverallRating = 1;
        }

        private void OverallTwoStarClick( object sender, EventArgs e)
        {
            review.OverallRating = 2;
        }

        private void OverallThreeStarClick(object sender, EventArgs e)
        {
            review.OverallRating = 3;
        }

        private void OverallFourStarClick(object sender, EventArgs e)
        {
            review.OverallRating = 4;
        }

        private void OverallFiveStarClick( object sender, EventArgs e)
        {
            review.OverallRating = 5;
        }

        private void NoiseOneStarClick(object sender, EventArgs e)
        {
            review.NoiseRating = 1;
        }

        private void NoiseTwoStarClick(object sender, EventArgs e)
        {
            review.NoiseRating = 2;
        }

        private void NoiseThreeStarClick(object sender, EventArgs e)
        {
            review.NoiseRating = 3;
        }

        private void NoiseFourStarClick(object sender, EventArgs e)
        {
            review.NoiseRating = 4;
        }

        private void NoiseFiveStarClick(object sender, EventArgs e)
        {
            review.NoiseRating = 5;
        }

        private void SafetyOneStarClick(object sender, EventArgs e)
        {
            review.SafetyRating = 1;
        }

        private void SafetyTwoStarClick(object sender, EventArgs e)
        {
            review.SafetyRating = 2;
        }

        private void SafetyThreeStarClick(object sender, EventArgs e)
        {
            review.SafetyRating = 3;
        }

        private void SafetyFourStarClick(object sender, EventArgs e)
        {
            review.SafetyRating = 4;
        }

        private void SafetyFiveStarClick(object sender, EventArgs e)
        {
            review.SafetyRating = 5;
        }

        private void MaintenanceOneStarClick(object sender, EventArgs e)
        {
            review.MaintenanceRating = 1;
        }

        private void MaintenanceTwoStarClick(object sender, EventArgs e)
        {
            review.MaintenanceRating = 2;
        }

        private void MaintenanceThreeStarClick(object sender, EventArgs e)
        {
            review.MaintenanceRating = 3;
        }

        private void MaintenanceFourStarClick(object sender, EventArgs e)
        {
            review.MaintenanceRating = 4;
        }

        private void MaintenanceFiveStarClick(object sender, EventArgs e)
        {
            review.MaintenanceRating = 5;
        }

        private void StudySpaceClick( object sender, EventArgs e)
        {
            if (review.StudySpace == false)
                review.StudySpace = true;
            else
                review.StudySpace = false;
        }

        private void ShuttleClick(object sender, EventArgs e)
        {
            if (review.Shuttle == false)
                review.Shuttle = true;
            else
                review.Shuttle = false;
        }

        private void WifiClick(object sender, EventArgs e)
        {
            if (review.Wifi == false)
                review.Wifi = true;
            else
                review.Wifi = false;
        }

        private void FurnishedClick(object sender, EventArgs e)
        {
            if (review.Furnished == false)
                review.Furnished = true;
            else
                review.Furnished = false;
        }

        private void TVClick(object sender, EventArgs e)
        {
            if (review.Tv == false)
                review.Tv = true;
            else
                review.Tv = false;
        }

        private void PetClick(object sender, EventArgs e)
        {
            if (review.Pet == false)
                review.Pet = true;
            else
                review.Pet = false;
        }

        private void TrashClick(object sender, EventArgs e)
        {
            if (review.Trash == false)
                review.Trash = true;
            else
                review.Trash = false;
        }

        private void GymClick(object sender, EventArgs e)
        {
            if (review.Gym == false)
                review.Gym = true;
            else
                review.Gym = false;
        }

        private void ParkingClick(object sender, EventArgs e)
        {
            if (review.Parking == false)
                review.Parking = true;
            else
                review.Parking = false;
        }

        private void SubmitClick(object sender, EventArgs e) //When the user accepts their rating as final
        {
            if( /*Distance field is not blank*/ )
            {
                review.Distance = Math.Round( float.Parse( /*Distance field*/, CultureInfo.InvariantCulture.NumberFormat), 2);
            }

            if ( /*Rent field is not blank*/ )
            {
                review.Rent = Math.Round(float.Parse( /*Rent field*/, CultureInfo.InvariantCulture.NumberFormat), 2);
            }

            if ( /*Utilities field is not blank*/ )
            {
                review.Utility = Math.Round(float.Parse( /*Utility field*/, CultureInfo.InvariantCulture.NumberFormat), 2);
            }

            review.Pros = /*Text of pros box*/;
            review.Cons = /*Text of cons box*/;

            if( review.Parking )
            {
                review.ParkingCost = Math.Round(float.Parse( /*Parking field*/, CultureInfo.InvariantCulture.NumberFormat), 2);
            }

            review.SendToDatabase(); 
        }

        private void CancelClick( object sender, EventArgs e)
        {
            //Close the window here
        }
    }
}