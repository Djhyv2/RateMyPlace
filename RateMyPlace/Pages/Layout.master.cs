using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RateMyPlace.Pages
{
    public partial class Layout : System.Web.UI.MasterPage
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                lblUsername.Text = "Hello, " + Session["Username"].ToString();
            }
        }
    }
}