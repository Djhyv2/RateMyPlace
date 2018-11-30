//Created by: Dustin Hengel
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RateMyPlace.Pages
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["Page"])
            {
                case "Complex"://If viewing a complex
                    DisplayComplex();
                    break;
                case "Review"://If viewing a page
                    DisplayReview();
                    break;
                default://If nothing specified, there is no default items to compare
                    DisplayNothing();
                    break;
            }//Switch on different page types
        }

        private void DisplayNothing()
        {
            lblError.Text = "Nothing selected to view, Please try again from the beginning";
            lblError.Visible = true;
            Page.Title = "View Error";
            return;
        }//Errors if nothing to compare

        private void DisplayReview()
        {
            if (null == Session["Viewed"])
            {
                DisplayNothing();
                return;
            }//If invalid session data

            Page.Title = "View Review";
            repeaterViewReview.Visible = true;//Make correct repeater visible
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@ReviewID", Session["Viewed"]));//Adds Viewed Review as parameter
            DataTable Review = Connection.RunSQL("SELECT * FROM Reviews WHERE PK_ReviewID = @ReviewID",
Parameters);//Gets selected review from database
            repeaterViewReview.DataSource = Review;
            repeaterViewReview.DataBind();//Binds SQL Return to Repeater
        }

        private void DisplayComplex()
        {
            if (null == Session["Viewed"])
            {
                DisplayNothing();
                return;
            }//If invalid session data

            Page.Title = "View Complex";
            repeaterViewComplex.Visible = true;//Make correct repeater visible
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@HousingComplex", Session["Viewed"]));//Adds Viewed Review as parameter
            DataTable Complexes = Connection.RunSQL(@"SELECT HousingComplex,
ROUND(AVG(OverallRating),2) AS 'OverallRating',
ROUND(AVG(Rent),2) AS 'Rent',
ROUND(AVG(Utilities),2) AS 'Utilities',
ROUND(AVG(Noise),2) AS 'Noise',
ROUND(AVG(Safety),2) AS 'Safety',
ROUND(AVG(Maintenance),2) AS 'Maintenance',
ROUND(AVG(Location),2) AS 'Location',
ROUND(AVG(CampusDistance),2) AS 'CampusDistance',
ROUND(AVG(SquareFootage),2) AS 'SquareFootage',
ROUND(AVG(CAST(StudySpace AS INT)),0) AS 'StudySpace',
ROUND(AVG(CAST(Shuttle AS INT)),0) AS 'Shuttle',
ROUND(AVG(CAST(Wifi AS INT)),0) AS 'Wifi',
ROUND(AVG(CAST(Furnished AS INT)),0) AS 'Furnished',
ROUND(AVG(CAST(TV AS INT)),0) AS 'TV',
ROUND(AVG(CAST(TrashService AS INT)),0) AS 'TrashService',
ROUND(AVG(CAST(Gym AS INT)),0) AS 'Gym',
ROUND(AVG(CAST(Parking AS INT)),0) AS 'Parking',
ROUND(AVG(ParkingFee),2) AS 'ParkingFee',
ROUND(AVG(CAST(Pets AS INT)),0) AS 'Pets',
ROUND(AVG(PetsFee),2) AS 'PetsFee',
ROUND(AVG(MiscFee),2) AS 'MiscFee'
FROM Reviews 
WHERE HousingComplex = @HousingComplex
GROUP BY HousingComplex", Parameters);//Gets selected complex from database
            repeaterViewComplex.DataSource = Complexes;
            repeaterViewComplex.DataBind();//Binds SQL Return to Repeater
        }


        protected void repeaterViewReview_DataBinding(object sender, EventArgs e)
        {

        }
    }
}