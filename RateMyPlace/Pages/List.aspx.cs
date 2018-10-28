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
            listViewList.DataSource = Reviews;
            listViewList.DataBind();//Binds sql return to listview
        }

        protected void listViewList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Label overallRating = (Label)e.Item.FindControl("lblOverallRating");//Finds overallRating in specific list element
            for (int iterations = 0; (int)(((DataRowView)e.Item.DataItem)["OverallRating"]) > iterations; iterations++)
            {
                overallRating.Text += "*";//Shows a star for each
            }//For overall rating given to review
        }//Called each time an item is added to the list
    }
}