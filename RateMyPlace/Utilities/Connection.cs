using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace RateMyPlace
{
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
        public static DataTable RunSQL(string SQL)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);//Gets connection string from Web.Config, requires the System.Configuration
            SqlCommand sqlCmd = new SqlCommand(SQL, sqlConn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            try
            {
                sqlConn.Open();
                sqlDataAdapter.Fill(dataTable);
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
            return dataTable;
        }
    }
}