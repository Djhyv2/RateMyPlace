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
            DataTable Complexes = Connection.RunSQL("SELECT HousingComplex, ROUND(AVG(OverallRating),2) AS 'Overall Rating', ROUND(AVG(Rent),2) AS 'Average Rent ($)', ROUND(AVG(Utilities),2) AS 'Average Utilities ($)', ROUND(AVG(Noise),2) AS 'Average Noise', ROUND(AVG(Safety),2) AS 'Average Safety', ROUND(AVG(Maintenance),2) AS 'Average Maintenance', ROUND(AVG(CampusDistance),2) AS 'Average Campus Distance (Mi)', ROUND(AVG(CAST(StudySpace AS INT)),0) AS 'Study Space', ROUND(AVG(CAST(Shuttle AS INT)),0) AS 'Shuttle', ROUND(AVG(CAST(Wifi AS INT)),0) AS 'Wifi', ROUND(AVG(CAST(Furnished AS INT)),0) AS 'Furnished', ROUND(AVG(CAST(TV AS INT)),0) AS 'TV', ROUND(AVG(CAST(TrashService AS INT)),0) AS 'Trash Service', ROUND(AVG(CAST(Gym AS INT)),0) AS 'Gym', ROUND(AVG(CAST(Parking AS INT)),0) AS 'Parking', ROUND(AVG(ParkingFee),2) AS 'Average Parking Fee ($)', ROUND(AVG(CAST(Pets AS INT)),0) AS 'Pets', ROUND(AVG(PetsFee),2) AS 'Average Pets Fee ($)', ROUND(AVG(MiscFee),2) AS 'Average Misc Fees ($)' FROM Reviews GROUP BY HousingComplex;");//Gets all unique data complexes
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

        protected void tblCompare_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            string[] checkboxes = new string[] { };
            string[] currency = new string[] { };
            string[] stars = new string[] { };

        }
    }
}