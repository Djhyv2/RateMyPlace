// Created by: Dustin Hengel
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

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

            Page.Title = "Compare Complexes";
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@Complexes", Connection.StringsToDataTable((String[])Session["Compared"])));//Adds Table of strings as parameter
            Parameters[0].SqlDbType = SqlDbType.Structured;//Sets new parameter to be structured
            Parameters[0].TypeName = "stringTable";//Use stringTable type defined in database
            DataTable Complexes = Connection.RunSQL(@"SELECT HousingComplex,
ROUND(AVG(OverallRating),2) AS 'Overall Rating',
ROUND(AVG(Rent),2) AS 'Average Rent',
ROUND(AVG(Utilities),2) AS 'Average Utilities',
ROUND(AVG(Noise),2) AS 'Average Noise Amount',
ROUND(AVG(Safety),2) AS 'Average Safety',
ROUND(AVG(Maintenance),2) AS 'Average Maintenance Quality',
ROUND(AVG(CampusDistance),2) AS 'Average Campus Distance',
ROUND(AVG(SquareFootage),2) AS 'Average Square Footage',
ROUND(AVG(CAST(StudySpace AS INT)),0) AS 'Study Space',
ROUND(AVG(CAST(Shuttle AS INT)),0) AS 'Shuttle',
ROUND(AVG(CAST(Wifi AS INT)),0) AS 'Wifi',
ROUND(AVG(CAST(Furnished AS INT)),0) AS 'Furnished',
ROUND(AVG(CAST(TV AS INT)),0) AS 'TV',
ROUND(AVG(CAST(TrashService AS INT)),0) AS 'Trash Service',
ROUND(AVG(CAST(Gym AS INT)),0) AS 'Gym',
ROUND(AVG(CAST(Parking AS INT)),0) AS 'Parking',
ROUND(AVG(ParkingFee),2) AS 'Average Parking Fee',
ROUND(AVG(CAST(Pets AS INT)),0) AS 'Pets',
ROUND(AVG(PetsFee),2) AS 'Average Pets Fee',
ROUND(AVG(MiscFee),2) AS 'Average Misc Fees'
FROM Reviews 
WHERE HousingComplex IN (SELECT * FROM @Complexes)
GROUP BY HousingComplex;",
Parameters);//Gets selected complexes from database using table as parameter to create list for in clause
            Complexes = Connection.TransposeTable(Complexes);//Transposed table to be horizontal instead of vertical
            tblCompare.DataSource = Complexes;
            tblCompare.DataBind();//Binds SQL Return to Repeater
            tblCompare.Visible = true;
        }

        private void DisplayNothing()
        {
            lblError.Text = "Nothing selected to compare, Please try again from the beginning";
            lblError.Visible = true;
            Page.Title = "Compare Error";
            return;
        }//Errors if nothing to compare

        protected void tblCompare_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            string[] miles = new string[] { "Average Campus Distance" };
            string[] checkboxes = new string[] { "Study Space", "Shuttle", "Wifi","Furnished","TV","Trash Service","Gym","Parking","Pets" };
            string[] currency = new string[] { "Average Rent", "Average Utilities", "Average Parking Fee", "Average Pets Fee", "Average Misc Fees" };
            string[] stars = new string[] { "Overall Rating","Average Noise Amount","Average Safety","Average Maintenance Quality"};
            string[] sqFoot = new string[] { "Average Square Footage" };
            //Arrays of which row headers are to be what format

            if ( 0 <= Array.IndexOf(stars,e.Item.Cells[0].Text))
            {
                for (int i=1;e.Item.Cells.Count > i;i++)
                {
                    if ("&nbsp;" != e.Item.Cells[i].Text)
                    {
                        e.Item.Cells[i].Text = RateMyPlaceDisplayUtilities.generateStars(int.Parse(e.Item.Cells[i].Text));//Converts int value to stars out of max
                    }//If not null
                    else
                    {
                        e.Item.Cells[i].Text = RateMyPlaceDisplayUtilities.generateStars(0);
                    }//Default to 0 stars
                }//For each column after header column
            }//If row is to be a stars

            if (0 <= Array.IndexOf(currency, e.Item.Cells[0].Text))
            {
                for (int i = 1; e.Item.Cells.Count > i; i++)
                {
                    if ("&nbsp;" != e.Item.Cells[i].Text)
                    {
                        e.Item.Cells[i].Text = string.Format("${0:0.00}", float.Parse(e.Item.Cells[i].Text));//Converts float value to currency
                    }//If not null
                    else
                    {
                        e.Item.Cells[i].Text = "$0.00";
                    }//Defaults to $0
                }//For each column after header column
            }//If row is to be a currency

            if (0 <= Array.IndexOf(miles, e.Item.Cells[0].Text))
            {
                for (int i = 1; e.Item.Cells.Count > i; i++)
                {
                    if ("&nbsp;" != e.Item.Cells[i].Text)
                    {
                        e.Item.Cells[i].Text += " mi.";//Converts float value to miles
                    }//If not null
                    else
                    {
                        e.Item.Cells[i].Text = "Unspecified";
                    }//Default to unspecified   
                }//For each column after header column
            }//If row is to be miles

            if (0 <= Array.IndexOf(checkboxes, e.Item.Cells[0].Text))
            {
                for (int i = 1; e.Item.Cells.Count > i; i++)
                {
                    System.Web.UI.WebControls.CheckBox newCheckBox = new System.Web.UI.WebControls.CheckBox();
                    newCheckBox.Checked = ("1" == e.Item.Cells[i].Text);//Sets checked value of checkbox based on integer text
                    newCheckBox.Attributes.Add("class", "checkbox");//Adds checkbox css class
                    newCheckBox.Attributes.Add("onClick", "return false");//Prevents checkbox from being used by users
                    e.Item.Cells[i].Text = "";//Clears text from cell
                    e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Center;//Centers checkbox in cell
                    e.Item.Cells[i].Controls.Add(newCheckBox);//Adds checkbox to cell
                }//For each column after header column
            }//If row is to be a checkbox

            if (0 <= Array.IndexOf(sqFoot, e.Item.Cells[0].Text))
            {
                for (int i = 1; e.Item.Cells.Count > i; i++)
                {
                    if ("&nbsp;" != e.Item.Cells[i].Text)
                    {
                        e.Item.Cells[i].Text += " sq. ft.";//Converts float value to sq ft
                    }//If not null
                    else
                    {
                        e.Item.Cells[i].Text = "Unspecified";
                    }//Default to unspecified sq foot   
                }//For each column after header column
            }//If row is to be square footage
        }//Called for each row added to table
    }
}