using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace RateMyPlace.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        //protected void handleLogin_click(object sender, EventArgs e)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>;
        //    parameters.AddWithValue("@Username", txtUsername.Text);
        //    DataTable credentials = Connection.RunSQL("SELECT PK_Username, Password FROM Users WHERE PK_Username = '" + txtUsername.Text + "'",parameters);

        //    MessageBox.Show("Server Username: " + credentials.Rows[0]["PK_Username"] + "\nServer Password: " + credentials.Rows[0]["Password"] + "\nInput Username: " + txtUsername.Text + "\nInput Password: " + txtPassword.Text, "Confidential Info", MessageBoxButtons.OK);
        //}

        protected void handleRegister_click(object sender, EventArgs e)
        {
            
        }
    }
}