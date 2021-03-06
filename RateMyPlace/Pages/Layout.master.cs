﻿// Written by: Dustin Hengel
// Tested by: Madison Williams
// Debugged by: Mercy Housh
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
            if (null != Session["Username"])
            {
                btnUsername.InnerHtml = "Hello, " + Session["Username"].ToString() + "! ";//Say hello username
                btnLogin.Visible = false;//Disable login
            }//If logged in
            else
            {
                btnLogout.Visible = false;//Disable logout
            }//Else not logged in
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["Username"] = null;//Actually logs out user from server variable
            Response.Redirect("HomePage.aspx");//Redirects to homepage
            
        }//Logs out user

        protected void login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");//Redirects to login 
        }//Redirects to login

        protected void user_Click(object sender, EventArgs e)
        {
            if(null != Session["Username"])
            {
                Response.Redirect("List.aspx?Page=Review&Type=User");//Redirects to Users Reviews
            }//If Username set
            else
            {
                Response.Redirect("Login.aspx");//Redirects to Login if not logged in
            }//Else Not logged in
        }//Redirects to Users Reviews or Login
    }
}