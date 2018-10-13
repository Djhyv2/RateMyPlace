using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace RateMyPlace.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Page"]=="Register")
            {
                txtPasswordRepeat.Visible = true;
                btnLogin.Visible = false ;
                Page.Title = "Register";
            }//Only runs on first page load
        }//Shows register


        protected void handleLogin_click(object sender, EventArgs e)
        {
            //Get Stored Password
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Username", txtUsername.Text));
            DataTable credentials = Connection.RunSQL("SELECT PK_Username, Password FROM Users WHERE PK_Username = @Username", parameters);//Gets password from database for user supplied username


            //Turn input password into hash
            string password = credentials.Rows[0]["Password"].ToString();
            byte[] hashBytes = Convert.FromBase64String(password);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(txtPassword.Text, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);


            
            //Compare stored hashed to input hashed
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return;//If not matching logins
                }
            }

            //Reached successful login
            Session["Username"] = txtUsername.Text;//Saves username into session if successfully logged in
            Response.Redirect("HomePage.aspx");//Redirects user to home page after log in
        }

        protected void handleRegister_click(object sender, EventArgs e)
        {
            if (Request.QueryString["Page"] != "Register")
            {
                Response.Redirect("Login.aspx?Page=Register");
            }

            if (txtPassword.Text == txtPasswordRepeat.Text)
            {

            }

            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);
            var pdkdf2 = new Rfc2898DeriveBytes(txtPassword.Text, salt, 1000);
            byte[] hash = pdkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string passwordHash = Convert.ToBase64String(hashBytes);

        }
    }
}