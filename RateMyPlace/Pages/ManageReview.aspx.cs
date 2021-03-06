﻿// Written by: Dustin Hengel
// Tested by: Mercy Housh
// Debugged by: Connor Fitzmaurice
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace RateMyPlace.Pages
{
    public partial class ManageReview : System.Web.UI.Page
    {
        public enum DisplayType { Add, Edit };//Used to show or hide elements based on what should be displayed
        public DisplayType displayType;
        public DataRow edited;//DataRow to hold review to be editted, is used to databind

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack == false)
            {
                DataTable complexes = Connection.RunSQL("SELECT DISTINCT HousingComplex AS Name, HousingComplex AS Value,0 AS RowIndex FROM REVIEWS UNION SELECT 'Add Complex' AS 'Name','NEW' AS 'Value',-1 AS RowIndex UNION SELECT '' AS 'Name','' AS 'Value', 1 AS RowIndex ORDER BY RowIndex DESC;");//Gets all possible housing complexes and option for adding new complex and empty for default value
                ddlComplex.DataSource = complexes;
                ddlComplex.DataTextField = "Name";
                ddlComplex.DataValueField = "Value";
                ddlComplex.DataBind();//Binds the sql return to the drop down list

                switch (Request.QueryString["Page"])
                {
                    case "Edit":
                        btnSubmit.Text = "Edit Review";
                        Page.Title = "Edit Review";
                        displayType = DisplayType.Edit;
                        PopulateReview(Request.QueryString["Edited"]);//Populates Existing Review
                        break;
                    default://Default is add a review
                        Page.Title = "Add Review";//Default title
                        displayType = DisplayType.Add;
                        break;
                }
            }//Only populates on first load           
        }

        private void PopulateReview(string ID)
        {
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@ReviewID", Session["Edited"]));//Adds Edited Review as parameter
            DataTable review = Connection.RunSQL("SELECT * FROM Reviews WHERE PK_ReviewID = @ReviewID",
Parameters);//Gets selected review from database
            if (0 == review.Rows.Count)
            {
                lblError.Visible = true;
                lblError.Text = "Unable to Load Review to Edit, Please Try Again";
                return;
            }

            edited = review.Rows[0];//Gets Row to be Databound
            Page.DataBind();
            ddlComplex.SelectedValue = true == edited.Table.Columns.Contains("HousingComplex") && DBNull.Value != edited["HousingComplex"] ? edited["HousingComplex"].ToString() : "";
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (false == ValidateForm())
            {
                return;
            }//If current form not valid

            if ("Edit" == Request.QueryString["Page"])
            {
                EditReview();
            }
            else
            {
                AddReview();
            }//If editting, edit, else adding review
        }

        protected void ddlComplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlSender = (DropDownList)sender;//Sender will always be a dropdownlist, casts value
            if ("NEW" == ddlSender.SelectedValue)
            {
                divComplex.Visible = true;//Enables user input complex name
            }//If add complex selected
            else
            {
                divComplex.Visible = false;//Disables user input complex name
            }
        }//When housing complex drop down changed

        private bool ValidateForm()
        {
            if (0 == ratingOverall.CurrentRating)
            {
                lblError.Visible = true;
                lblError.Text = "Must provide Overall Rating.";
                return false;
            }//If no overall rating specified

            if ("" == txtRent.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Must provide Rent Amount.";
                return false;
            }//If no rent specified

            if ("" == txtUtilities.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Must provide Utilities Amount.";
                return false;
            }//If no utilities specified

            if (("NEW" == ddlComplex.SelectedValue && "" == txtComplex.Text) || "" == ddlComplex.SelectedValue)
            {
                lblError.Visible = true;
                lblError.Text = "Must provide Housing Complex.";
                return false;
            }//If no complex selected or add selected and none specified

            return true;//Return true if no errors found
        }

        private void EditReview()
        {
            List<SqlParameter> Parameters = GenerateParameters();//Gets Parameters from Page
            Parameters.Add(new SqlParameter("@PK_ReviewID", Session["Edited"]));//Adds Review ID as Parameter
            int test = Connection.RunNonQuerySQL("UPDATE Reviews SET OverallRating = @OverallRating, Noise = @Noise, Safety = @Safety, Maintenance = @Maintenance, Location = @Location, LeaseStartDate = @LeaseStartDate, LeaseEndDate = @LeaseEndDate, CampusDistance = @CampusDistance, SquareFootage = @SquareFootage, Pros = @Pros, Cons = @Cons, StudySpace = @StudySpace, Shuttle = @Shuttle, Wifi = @Wifi, Furnished = @Furnished, TV= @TV, TrashService = @TrashService, Gym = @Gym, Parking = @Parking, ParkingFee = @ParkingFee, Pets = @Pets, PetsFee = @PetsFee, MiscFee = @MiscFee, Rent = @Rent, Utilities = @Utilities, HousingComplex = @HousingComplex WHERE PK_ReviewID = @PK_ReviewID", Parameters);//Edits existing review
            Session["Viewed"] = Session["Edited"];
            Response.Redirect("View.aspx?Page=Review");//Redirects to view page
        }

        private void AddReview()
        {
            List<SqlParameter> Parameters = GenerateParameters();//Gets Parameters from Page
            Connection.RunSQL("INSERT INTO REVIEWS (FK_Username,OverallRating,Noise,Safety,Maintenance,Location,LeaseStartDate,LeaseEndDate,CampusDistance,SquareFootage,Pros,Cons,StudySpace,Shuttle,Wifi,Furnished,TV,TrashService,Gym,Parking,ParkingFee,Pets,PetsFee,MiscFee,Rent,Utilities,HousingComplex) VALUES (@Username, @OverallRating, @Noise, @Safety, @Maintenance, @Location, @LeaseStartDate, @LeaseEndDate, @CampusDistance, @SquareFootage, @Pros, @Cons, @StudySpace, @Shuttle, @Wifi, @Furnished, @TV, @TrashService, @Gym, @Parking, @ParkingFee, @Pets, @PetsFee, @MiscFee, @Rent, @Utilities, @HousingComplex);",Parameters);//Adds Review to Database
            Response.Redirect("HomePage.aspx");//Redirects to homepage
        }

        private List<SqlParameter> GenerateParameters()
        {
            List<SqlParameter> Parameters = new List<SqlParameter>();//List to hold parameters
            if (null != Session["Username"])
            {
                Parameters.Add(new SqlParameter("@Username", Session["Username"]));//Adds username from session
            }
            else
            {
                Parameters.Add(new SqlParameter("@Username", DBNull.Value));
            }//If session username doesn't exist, use null, else use session username
            Parameters.Add(new SqlParameter("@OverallRating",ratingOverall.CurrentRating));
            if (0 == ratingNoise.CurrentRating)
            {
                Parameters.Add(new SqlParameter("@Noise", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@Noise", ratingNoise.CurrentRating));
            }////If rating not set, use null, else use rating
            if (0 == ratingSafety.CurrentRating)
            {
                Parameters.Add(new SqlParameter("@Safety", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@Safety", ratingSafety.CurrentRating));
            }////If rating not set, use null, else use rating
            if (0 == ratingMaintenance.CurrentRating)
            {
                Parameters.Add(new SqlParameter("@Maintenance", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@Maintenance", ratingMaintenance.CurrentRating));
            }////If rating not set, use null, else use rating
            if (0 == ratingLocation.CurrentRating)
            {
                Parameters.Add(new SqlParameter("@Location", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@Location", ratingLocation.CurrentRating));
            }////If rating not set, use null, else use rating 
            if ("" == txtLeaseStart.Text)
            {
                Parameters.Add(new SqlParameter("@LeaseStartDate", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@LeaseStartDate", txtLeaseStart.Text));
            }//If date doesn't exist, use null, else use date
            if ("" == txtLeaseEnd.Text)
            {
                Parameters.Add(new SqlParameter("@LeaseEndDate", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@LeaseEndDate", txtLeaseEnd.Text));
            }//If date doesn't exist, use null, else use date
            if ("" == txtDistance.Text)
            {
                Parameters.Add(new SqlParameter("@CampusDistance", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@CampusDistance", txtDistance.Text));
            }//If text doesn't exist, use null, else use text
            if ("" == txtSqFoot.Text)
            {
                Parameters.Add(new SqlParameter("@SquareFootage", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@SquareFootage", txtSqFoot.Text));
            }//If text doesn't exist, use null, else use text
            Parameters.Add(new SqlParameter("@Pros",txtPros.Text));
            Parameters.Add(new SqlParameter("@Cons",txtCons.Text));
            Parameters.Add(new SqlParameter("@StudySpace",chkStudySpace.Checked));
            Parameters.Add(new SqlParameter("@Shuttle",chkShuttle.Checked));
            Parameters.Add(new SqlParameter("@Wifi",chkWiFi.Checked));
            Parameters.Add(new SqlParameter("@Furnished",chkFurnished.Checked));
            Parameters.Add(new SqlParameter("@TV",chkTV.Checked));
            Parameters.Add(new SqlParameter("@TrashService",chkTrashService.Checked));
            Parameters.Add(new SqlParameter("@Gym",chkGym.Checked));
            Parameters.Add(new SqlParameter("@Parking",chkParking.Checked));
            if ("" == txtParking.Text)
            {
                Parameters.Add(new SqlParameter("@ParkingFee", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@ParkingFee", txtParking.Text));
            }//If text doesn't exist, use null, else use text
            Parameters.Add(new SqlParameter("@Pets",chkPets.Checked));
            if ("" == txtPets.Text)
            {
                Parameters.Add(new SqlParameter("@PetsFee", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@PetsFee", txtPets.Text));
            }//If text doesn't exist, use null, else use text
            if ("" == txtMiscFees.Text)
            {
                Parameters.Add(new SqlParameter("@MiscFee", DBNull.Value));
            }
            else
            {
                Parameters.Add(new SqlParameter("@MiscFee", txtMiscFees.Text));
            }//If text doesn't exist, use null, else use text
            Parameters.Add(new SqlParameter("@Rent",txtRent.Text));
            Parameters.Add(new SqlParameter("@Utilities",txtUtilities.Text));
            Parameters.Add(new SqlParameter("@HousingComplex", ("NEW" == ddlComplex.SelectedValue) ? txtComplex.Text : ddlComplex.SelectedValue));//Adds either selected drop down or text value if new complex
            return Parameters;//Returns list of parameters
        }
    }
}