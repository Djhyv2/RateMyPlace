using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace RateMyPlace.Pages
{
    public partial class UserProfileResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable table = Connection.RunSQL("SELECT * FROM Reviews");




            userProfileText.Text = "<tr><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td><button class=\"editButton\">Edit</button><button class=\"deleteButton\">Delete</button></td></tr>";
        }
    }
}