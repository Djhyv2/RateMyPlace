using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data;

namespace RateMyPlace.Pages
{
    public partial class ManageReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (IsPostBack == false)
            {
                DataTable complexes = Connection.RunSQL("SELECT DISTINCT HousingComplex AS Name, HousingComplex AS Value,0 AS RowIndex FROM REVIEWS UNION SELECT 'Add Complex' AS 'Name','NEW' AS 'Value',-1 AS RowIndex UNION SELECT '' AS 'Name','' AS 'Value', 1 AS RowIndex ORDER BY RowIndex DESC;");//Gets all possible housing complexes and option for adding new complex and empty for default value
                ddlComplex.DataSource = complexes;
                ddlComplex.DataTextField = "Name";
                ddlComplex.DataValueField = "Value";
                ddlComplex.DataBind();//Binds the sql return to the drop down list
            }//Only generates drop down list on first load
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(overallRating.CurrentRating.ToString(),"", MessageBoxButtons.OK);
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
        }
    }
}