using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace RateMyPlace.Pages
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["Page"])
            {
                case "User":
                    break;
                case "AllComplex":
                    break;
                case "SpecificComplex":
                    break;
                default: //Default is All Reviews
                    DisplayAll();
                    break;
            }//Switch on what list to display
        }

        private void DisplayAll()
        {
            DataTable Reviews = Connection.RunSQL("SELECT PK_ReviewID, FK_Username, OverallRating, Noise, Safety, Maintenance, LeaseStartDate, LeaseEndDate, CampusDistance, StudySpace, Shuttle, Wifi, Furnished, TV, TrashService, Gym, Parking, ParkingFee, Pets, PetsFee, MiscFee, Rent, Utilities, HousingComplex FROM Reviews ORDER BY LeaseEndDate DESC, PK_ReviewID DESC;");//Gets all reviews from database
            repeaterList.DataSource = Reviews;
            repeaterList.DataBind();//Binds SQL Return to Repeater
        }

        protected void repeaterList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(ListItemType.Header == e.Item.ItemType || ListItemType.Footer == e.Item.ItemType)
            {
                return;
            }//No data to specifically bind on header or footer

            Label overallRating = (Label)e.Item.FindControl("lblOverallRating");//Finds overallRating in specific list element
            
            //Replaces the integer with out of 5 stars
            int iterations;
            for (iterations = 0; (int)(((DataRowView)e.Item.DataItem)["OverallRating"]) > iterations; iterations++)
            {
                overallRating.Text += "&#x2605";//Shows a full star for each given out of 5
            }
            for (; 5 > iterations; iterations++)
            {
                overallRating.Text += "&#x2606";//Shows an empty star for each remaining out of 5
            }
        }//For each item in repeater when bound with datasource
    }
}