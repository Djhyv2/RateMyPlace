﻿//Created by: Dustin Hengel
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
                    DisplayAllComplexes();
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
            Page.Title = "All Reviews";
            DataTable Reviews = Connection.RunSQL("SELECT PK_ReviewID, FK_Username, OverallRating, Noise, Safety, Maintenance, LeaseStartDate, LeaseEndDate, CampusDistance, StudySpace, Shuttle, Wifi, Furnished, TV, TrashService, Gym, Parking, ParkingFee, Pets, PetsFee, MiscFee, Rent, Utilities, HousingComplex FROM Reviews ORDER BY LeaseEndDate DESC, PK_ReviewID DESC;");//Gets all reviews from database
            repeaterListAll.DataSource = Reviews;
            repeaterListAll.DataBind();//Binds SQL Return to Repeater
            repeaterListAll.Visible = true;//Displays this repeater
        }

        private void DisplayAllComplexes()
        {
            Page.Title = "All Complexes";
            DataTable Complexes = Connection.RunSQL("SELECT HousingComplex, AVG(OverallRating) AS OverallRating, AVG(Rent) AS AverageRent , AVG(Utilities) AS AverageUtilities FROM Reviews GROUP BY HousingComplex;");//Gets all unique data complexes
            repeaterListComplexes.DataSource = Complexes;
            repeaterListComplexes.DataBind();//Binds SQL Return to Repeater
            repeaterListComplexes.Visible = true;//Displays this repeater
        }

        protected void repeaterListOverallRating_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (ListItemType.Header == e.Item.ItemType || ListItemType.Footer == e.Item.ItemType)
            {
                return;
            }//No data to specifically bind on header or footer

            System.Web.UI.WebControls.Label overallRating = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblOverallRating");//Finds overallRating in specific list element

            //Replaces the integer with out of 10 stars
            overallRating.Text += RateMyPlaceDisplayUtilities.generateStars((int)(((DataRowView)e.Item.DataItem)["OverallRating"]));
        }//For each item in repeater when bound with datasource

        protected void btnView_Command(object sender, CommandEventArgs e)
        {
            Session["Viewed"] = e.CommandArgument;//Sets reviw to be viewed
            Response.Redirect("View.aspx?Page=Review");//Redirects to view page
        }//Buttonhandler for each item in repeater of RepeaterAll to view specific

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (null == Request.Form.GetValues("Complexes") || 2 > Request.Form.GetValues("Complexes").Length)
            {
                lblError.Text = "Select 2 or more Complexes to Compare.";
                lblError.Visible = true;
                return;
            }//If selected <2 complexes
            
            Session["Compared"] = Request.Form.GetValues("Complexes");//Stores values to be compared
            Response.Redirect("Compare.aspx?Page=Complexes");//Redirects to compare

        }//Submit Button for compare complex
    }
}