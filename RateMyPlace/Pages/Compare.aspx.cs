// Created by: Dustin Hengel
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RateMyPlace.Pages
{
    public partial class Compare : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["Page"])
            {
                case "Complexes"://If comparing complexes
                    DisplayComplexes();
                    break;
                case "Reviews":
                    break;
                default://If nothing specified, there is no default items to compare
                    DisplayNothing();
                    break;
            }//Switch on different page types
        }

        private void DisplayComplexes()
        {
            if (null == Session["Compared"] || 2 > ((String[])Session["Compared"]).Length)
            {
                DisplayNothing();
                return;
            }//If invalid session data
            DataTable Complexes = Connection.RunSQL("SELECT HousingComplex, ROUND(AVG(CAST(OverallRating AS FLOAT)),2) AS OverallRating, ROUND(AVG(Rent),2) AS AverageRent , ROUND(AVG(CAST(Utilities AS FLOAT)),2) AS AverageUtilities, ROUND(AVG(CAST(Noise AS FLOAT)),2) AS AverageNoise, ROUND(AVG(CAST(Safety AS FLOAT)),2) AS AverageSafety, ROUND(AVG(CAST(Maintenance AS FLOAT)),2) AS AverageMaintenance, ROUND(AVG(CampusDistance),2) AS AverageCampusDistance, ROUND(AVG(CAST(StudySpace AS INT)),0) AS AverageStudySpace, ROUND(AVG(CAST(Shuttle AS INT)),0) AS AverageShuttle, ROUND(AVG(CAST(Wifi AS INT)),0) AS AverageWifi, ROUND(AVG(CAST(Furnished AS INT)),0) AS AverageFurnished, ROUND(AVG(CAST(TV AS INT)),0) AS AverageTV, ROUND(AVG(CAST(TrashService AS INT)),0) AS AverageTrashService, ROUND(AVG(CAST(Gym AS INT)),0) AS AverageGym, ROUND(AVG(CAST(Parking AS INT)),0) AS AverageParking, ROUND(AVG(ParkingFee),2) AS AverageParkingFee, ROUND(AVG(CAST(Pets AS INT)),0) AS AveragePets, ROUND(AVG(PetsFee),2) AS AveragePetsFee, ROUND(AVG(MiscFee),2) AS AverageMiscFee FROM Reviews GROUP BY HousingComplex;");//Gets all unique data complexes
            Complexes = Connection.TransposeTable(Complexes);//Transposed table to be horizontal instead of vertical
            tblCompare.DataSource = Complexes;
            tblCompare.DataBind();//Binds SQL Return to Repeater
            tblCompare.Visible = true;
        }

        private void DisplayNothing()
        {
            lblError.Text = "Nothing selected to compare, Please try again from the beginning";
            lblError.Visible = true;
            return;
        }//Errors if nothing to compare
    }
}