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
            DataTable Complexes = Connection.RunSQL("SELECT HousingComplex, AVG(OverallRating) AS OverallRating, AVG(Rent) AS AverageRent , AVG(Utilities) AS AverageUtilities FROM Reviews GROUP BY HousingComplex;");//Gets all unique data complexes
            Complexes = Connection.TransposeTable(Complexes);//Transposed table
            dataListComplex.DataSource = Complexes;
            dataListComplex.RepeatColumns = Complexes.Rows.Count;
            dataListComplex.DataBind();//Binds SQL Return to Repeater
        }
    }
}