//Created by: Dustin Hengel
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RateMyPlace.Pages
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["Page"])
            {
                case "Complex"://If viewing a complex
                    break;
                case "Review"://If viewing a page
                    DisplayReview();
                    break;
                default://If nothing specified, there is no default items to compare
                    DisplayNothing();
                    break;
            }//Switch on different page types
        }

        private void DisplayNothing()
        {
            lblError.Text = "Nothing selected to view, Please try again from the beginning";
            lblError.Visible = true;
            Page.Title = "View Error";
            return;
        }//Errors if nothing to compare

        private void DisplayReview()
        {
            if (null == Session["Viewed"])
            {
                DisplayNothing();
                return;
            }//If invalid session data

            Page.Title = "View Review";
            List<SqlParameter> Parameters = new List<SqlParameter>();
            Parameters.Add(new SqlParameter("@ReviewID", Session["Viewed"]));//Adds Viewed Review as parameter
            DataTable Complexes = Connection.RunSQL("SELECT * FROM Reviews WHERE PK_ReviewID = @ReviewID",
Parameters);//Gets selected review from database
            repeaterView.DataSource = Complexes;
            repeaterView.DataBind();//Binds SQL Return to Repeater
        }

        protected void repeaterView_DataBinding(object sender, EventArgs e)
        {

        }
    }
}