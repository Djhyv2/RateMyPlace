using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static RateMyPlace.Classes.Review;

namespace RateMyPlace.Pages
{
    public partial class SelectComplexComparison : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HTMLInsert.Text = GetHTMLTable( "SELECT HousingComplex FROM Reviews", "<th>Complex</th><th>Select</th>", true );
        }
    }
}