using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace RateMyPlace
{
    using System;
    using System.Data.SqlClient;
    using System.Configuration;

    public class Connection
    {
        /// <summary>
        /// Executes the passed SQL command
        /// </summary>
        /// <param name="SQL">
        /// Text of SQL to execute
        /// </param>
        /// <returns>
        /// Table of values from executed SQL
        /// </returns>
        public static SqlDataReader RunSQL(string SQL)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);//Gets connection string from Web.Config, requires the System.Configuration
            SqlCommand sqlCmd = new SqlCommand(SQL, sqlConn);
            SqlDataReader sqlDataReader;
            try
            {
                sqlConn.Open();
                sqlDataReader = sqlCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);//Displays error as alert box
                return null;
            }
            finally
            {
                sqlConn.Close();
            }
            return sqlDataReader;
        }
    }
}