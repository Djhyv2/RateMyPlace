// Written by: Dustin Hengel
// Tested by: Connor Fitzmaurice
// Debugged by: Mercy Housh
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
        public enum DisplayType { ViewComplex, CompareComplex, ListComplex, AllReview, ComplexReview, UserReview};//Used to show or hide elements based on what should be displayed
        public DisplayType displayType;

        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["Page"])
            {
                case "Review":
                    DisplayReviews(Request.QueryString["Type"]);
                    break;
                case "Complex":
                    DisplayComplexes(Request.QueryString["Type"]);
                    break;
                default:
                    DisplayNothing("Nothing selected to list, Please try again from the beginning");
                    break;
            }//Switch on what list to display
        }

        private void DisplayReviews(String type)
        {
            DataTable Reviews = new DataTable();
            switch (type)
            {
                case "All":
                    Page.Title = "All Reviews View";
                    Reviews = Connection.RunSQL("SELECT * FROM Reviews ORDER BY HousingComplex ASC, LeaseEndDate DESC, PK_ReviewID DESC;");//Gets all reviews from database
                    displayType = DisplayType.AllReview;
                    break;
                case "User":
                    if (null != Session["Username"])
                    {
                        Page.Title = Session["Username"] + "'s Reviews";
                        List<SqlParameter> Parameters = new List<SqlParameter>();
                        Parameters.Add(new SqlParameter("@FK_Username", Session["Username"]));//Adds Username as parameter
                        Reviews = Connection.RunSQL("SELECT * FROM Reviews WHERE FK_Username = @FK_Username ORDER BY PK_ReviewID DESC",
            Parameters);//Gets user's reviews from database
                        if (0 == Reviews.Rows.Count)
                        {
                            lblError.Text = "No Reviews By " + Session["Username"] + " To Display"; 
                            lblError.Visible = true;
                        }//If No Rows Display Error
                    }//If Username set, get reviews by user
                    else
                    {
                        DisplayNothing("No type specified, Please try again from the beginning");//Default error and show nothing
                        return;
                    }//If Username not set, error
                    displayType = DisplayType.UserReview;
                    break;
                case "Complex":
                    if (null != Session["Listed"])
                    {
                        Page.Title = Session["Listed"] + "'s Reviews";
                        List<SqlParameter> Parameters = new List<SqlParameter>();
                        Parameters.Add(new SqlParameter("@HousingComplex", Session["Listed"]));//Adds Housing Complex as parameter
                        Reviews = Connection.RunSQL("SELECT * FROM Reviews WHERE HousingComplex = @HousingComplex ORDER BY PK_ReviewID DESC",
            Parameters);//Gets user's reviews from database
                        if (0 == Reviews.Rows.Count)
                        {
                            lblError.Text = "No Reviews Of " + Session["Listed"] + " To Display";
                            lblError.Visible = true;
                        }//If No Rows Display Error
                    }//If listed set, get reviews of complex in listed
                    else
                    {
                        DisplayNothing("No type specified, Please try again from the beginning");//Default error and show nothing
                        return;
                    }//If Username not set, error
                    displayType = DisplayType.ComplexReview;
                    break;
                default:
                    DisplayNothing("No type specified, Please try again from the beginning");//Default error and show nothing
                    return;
            }
            repeaterListReview.DataSource = Reviews;
            repeaterListReview.DataBind();//Binds SQL Return to Repeater
            repeaterListReview.Visible = true;//Displays this repeater
        }

        private void DisplayNothing(string error)
        {
            lblError.Text = error;
            lblError.Visible = true;
            Page.Title = "List Error";
            return;
        }//Errors if nothing to compare

        private void DisplayComplexes(String type)
        {
            switch (type)
            {
                case "Compare":
                    Page.Title = "List Complexes to Compare";
                    displayType = DisplayType.CompareComplex;//Will be checked before showing compare checkboxes
                    break;
                case "View":
                    Page.Title = "List Complexes to View";
                    displayType = DisplayType.ViewComplex;//Will be checked before showing view buttons
                    break;
                case "List":
                    Page.Title = "List Complexes to List";
                    displayType = DisplayType.ListComplex;//Will be checked before showing list button
                    break;
                default:
                    DisplayNothing("No type specified, Please try again from the beginning");//Default error and show nothing
                    return;
            }//Switch on Page Following List
            
            DataTable Complexes = Connection.RunSQL("SELECT HousingComplex, AVG(OverallRating) AS OverallRating, AVG(Rent) AS AverageRent , AVG(Utilities) AS AverageUtilities, AVG(SquareFootage) AS AverageSquareFootage FROM Reviews GROUP BY HousingComplex ORDER BY HousingComplex ASC;");//Gets all unique data complexes
            repeaterListComplexes.DataSource = Complexes;
            repeaterListComplexes.DataBind();//Binds SQL Return to Repeater
            repeaterListComplexes.Visible = true;//Displays this repeater
        }

        protected void repeaterListRating_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (ListItemType.Header == e.Item.ItemType || ListItemType.Footer == e.Item.ItemType)
            {
                return;
            }//No data to specifically bind on header or footer

            System.Web.UI.WebControls.Label overallRating = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblOverallRating");//Finds overallRating in specific list element

            if (null != overallRating)
            {
                overallRating.Text += RateMyPlaceDisplayUtilities.generateStars((int)(((DataRowView)e.Item.DataItem)["OverallRating"]));//Replaces the integer with out of 10 stars
            }


            System.Web.UI.WebControls.Label locationRating = (System.Web.UI.WebControls.Label)e.Item.FindControl("lblLocation");//Finds overallRating in specific list element

            if (null != locationRating)
            {
                locationRating.Text += RateMyPlaceDisplayUtilities.generateStars((DBNull.Value == ((DataRowView)e.Item.DataItem)["Location"])?0:(int)((DataRowView)e.Item.DataItem)["Location"]);//Replaces the integer with out of 10 stars
            }
        }//For each item in repeater when bound with datasource

        protected void btnViewReview_Command(object sender, CommandEventArgs e)
        {
            Session["Viewed"] = e.CommandArgument;//Sets reviw to be viewed
            Response.Redirect("View.aspx?Page=Review");//Redirects to view page
        }//Buttonhandler for each item in repeater to view specific review

        protected void btnEditReview_Command(object sender, CommandEventArgs e)
        {
            Session["Edited"] = e.CommandArgument;//Sets reviw to be edited
            Response.Redirect("ManageReview.aspx?Page=Edit");//Redirects to edit page
        }//Buttonhandler for each item in repeater to edit specific review

        protected void btnDeleteReview_Command(object sender, CommandEventArgs e)
        {
            if (DialogResult.No == MessageBox.Show("Are you sure you want to delete this review?","Confirm Deletion",MessageBoxButtons.YesNo))
            {
                return;
            }//If not confirmed delete, abort

            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@PK_ReviewID",e.CommandArgument));//Adds Review IK as Parameter
            Connection.RunNonQuerySQL("DELETE FROM Reviews WHERE PK_ReviewID = @PK_ReviewID", Parameters);//Deletes review
            Response.Redirect("List.aspx?Page=Review&Type=User");//Refreshes page

        }//Buttonhandler for each item in repeater to delete specific review

        protected void btnSubmitCompareComplex_Click(object sender, EventArgs e)
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

        protected void btnSubmitCompareReview_Click(object sender, EventArgs e)
        {
            if (null == Request.Form.GetValues("Reviews") || 2 > Request.Form.GetValues("Reviews").Length)
            {
                lblError.Text = "Select 2 or more Reviews to Compare.";
                lblError.Visible = true;
                return;
            }//If selected <2 complexes

            Session["Compared"] = Request.Form.GetValues("Reviews");//Stores values to be compared
            Response.Redirect("Compare.aspx?Page=Reviews");//Redirects to compare

        }//Submit Button for compare complex
        


        protected void btnViewComplex_Command(object sender, CommandEventArgs e)
        {
            Session["Viewed"] = e.CommandArgument;//Sets reviw to be viewed
            Response.Redirect("View.aspx?Page=Complex");//Redirects to view page
        }//Buttonhandler for each complex in repeater to view specific complex

        protected void btnListComplex_Command(object sender, CommandEventArgs e)
        {
            Session["Listed"] = e.CommandArgument;//Sets complex to be listed
            Response.Redirect("List.aspx?Page=Review&Type=Complex");//Redirects to list of reviews from that complex
        }//Buttonhandler for each complex in repeater to view specific complex
    }
}