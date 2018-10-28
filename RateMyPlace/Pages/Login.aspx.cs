//Created by: Dustin Hengel
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Web.UI.WebControls;

namespace RateMyPlace.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ("Register" == Request.QueryString["Page"])
            {
                txtPasswordRepeat.Visible = true;
                btnLogin.Visible = false;
                Page.Title = "Register";
                lblError.Visible = false;
            }//Shows register if specified in get array

        }


        protected void handleLogin_click(object sender, EventArgs e)
        {
            //Get Stored Password
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Username", txtUsername.Text.ToLower()));
            DataTable credentials = Connection.RunSQL("SELECT PK_Username, Password FROM Users WHERE PK_Username = @Username", parameters);//Gets password from database for user supplied username
            if (0 >= credentials.Rows.Count)
            {
                lblError.Visible = true;
                lblError.Text = "Username or Password incorrect";
                return;
            }//If unable to find username in database, return

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
                    lblError.Visible = true;
                    lblError.Text = "Username or Password incorrect";
                    return;
                }//If passwords don't match, return
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
            }//If not register page

            if (txtPassword.Text != txtPasswordRepeat.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Passwords do not match";
                return;
            }//If passwords don't match, return

            if (null == txtUsername.Text || "" == txtUsername.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Username must not be blank";
                return;
            }//If Username blank, return

            if (null == txtPassword.Text || "" == txtPassword.Text || null == txtPasswordRepeat.Text || "" == txtPasswordRepeat.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Password must not be blank";
                return;
            }//If Password Blank, return

            List<SqlParameter> getUsernameParameter = new List<SqlParameter>();
            getUsernameParameter.Add(new SqlParameter("@Username", txtUsername.Text));
            DataTable usernameTable = Connection.RunSQL("SELECT PK_Username FROM Users WHERE PK_Username = @Username", getUsernameParameter);//Gets password from database for user supplied username
            if (0 < usernameTable.Rows.Count)
            {
                lblError.Visible = true;
                lblError.Text = "Username in use";
                return;
            }//If Username already exists, return

            //Turns password into hash
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);
            var pdkdf2 = new Rfc2898DeriveBytes(txtPassword.Text, salt, 1000);
            byte[] hash = pdkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string passwordHash = Convert.ToBase64String(hashBytes);

            //Store user into database
            List<SqlParameter> insertUserParameters = new List<SqlParameter>();
            insertUserParameters.Add(new SqlParameter("@Username", txtUsername.Text.ToLower()));
            insertUserParameters.Add(new SqlParameter("@Password", passwordHash));
            Connection.RunNonQuerySQL("INSERT INTO Users (PK_Username,Password) VALUES (@Username,@Password)", insertUserParameters);

            //Login user
            Session["Username"] = txtUsername.Text;//Saves username into session if successfully logged in
            Response.Redirect("HomePage.aspx");//Redirects user to home page after log in
        }
    }   
}