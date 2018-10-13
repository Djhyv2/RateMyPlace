using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace RateMyPlace.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void handleLogin_click(object sender, EventArgs e)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Username", txtUsername.Text));
            DataTable credentials = Connection.RunSQL("SELECT PK_Username, Password FROM Users WHERE PK_Username = @Username", parameters);//Gets password from database for user supplied username

            byte[] salt = new byte[128 / 8];
            //using (var randomNumberGenerator = RandomNumberGenerator.Create())

            
            if (0 < credentials.Rows.Count && credentials.Rows[0]["Password"].ToString() == txtPassword.Text)
            {
                Session["Username"] = txtUsername.Text;//Saves username into session if successfully logged in
                Response.Redirect("HomePage.aspx");//Redirects user to home page after log in
            }//Checks if passwords match
        }

        protected void handleRegister_click(object sender, EventArgs e)
        {
            
        }
    }
}