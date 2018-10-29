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
            //ALSO CHECK FOR LIST LENGTH <2
            if (null == Session["Compared"])
            {
                DisplayNothing();
                return;
            }//If invalid session data
            DataTable Complexes = Connection.RunSQL("SELECT HousingComplex, ROUND(AVG(OverallRating),2) AS OverallRating, ROUND(AVG(Rent),2) AS AverageRent , ROUND(AVG(Utilities),2) AS AverageUtilities FROM Reviews GROUP BY HousingComplex;");//Gets all unique data complexes
            Complexes = Connection.TransposeTable(Complexes);//Transposed table to be horizontal instead of vertical
            tblCompare.DataSource = Complexes;
            tblCompare.DataBind();//Binds SQL Return to Repeater
        }

        private void DisplayNothing()
        {
            lblError.Text = "Nothing selected to compare, Please try again from the beginning";
            lblError.Visible = true;
            return;
        }//Errors if nothing to compare
    }
}