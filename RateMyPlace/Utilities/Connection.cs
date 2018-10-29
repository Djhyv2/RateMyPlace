//Created by: Dustin Hengel
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace RateMyPlace
{
    public class Connection
    {
        /// <summary>
        /// Executes the passed SQL command
        /// </summary>
        /// <param name="sql">
        /// Text of SQL to execute
        /// </param>
        /// <returns>
        /// Table of values from executed SQL
        /// </returns>
        public static DataTable RunSQL(string sql)
        {
            return RunSQL(sql, null);//Chain constructors from less specific to more specific 
        }


        /// <summary>
        /// Executes the passed SQL command
        /// </summary>
        /// <param name="sql">
        /// Text of SQL to execute
        /// </param>
        /// <param name="parameters">
        /// List of Parameters to be applied to sql
        /// </param>
        /// <returns>
        /// Table of values from executed SQL
        /// </returns>
        public static DataTable RunSQL(string sql, List<SqlParameter> parameters)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);//Gets connection string from Web.Config, requires the System.Configuration
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
            if (null != parameters)
            {
                sqlCmd.Parameters.AddRange(parameters.ToArray());//Converts list to array and adds all to sql parameters
            }
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dataTable = new DataTable();
            try
            {
                sqlConn.Open();
                sqlDataAdapter.Fill(dataTable);//Fills table using result of executed query
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

        /// <summary>
        /// Executes the passed SQL non query command
        /// </summary>
        /// <param name="sql">
        /// Text of SQL to execute
        /// </param>
        /// <returns>
        /// Number of rows affected
        /// </returns>
        public static int RunNonQuerySQL(string sql)
        {
            return RunNonQuerySQL(sql, null);//Chains constructors from less to more specific
        }


        /// <summary>
        /// Executes the passed SQL non query command
        /// </summary>
        /// <param name="sql">
        /// Text of SQL to execute
        /// </param>
        /// <returns>
        /// Number of rows affected
        /// </returns>
        public static int RunNonQuerySQL(string sql,List<SqlParameter> parameters)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);//Gets connection string from Web.Config, requires the System.Configuration
            SqlCommand sqlCmd = new SqlCommand(sql, sqlConn);
            int rowsAffected = -1;
            if (null != parameters)
            {
                sqlCmd.Parameters.AddRange(parameters.ToArray());//Converts list to array and adds all to sql parameters
            }
            try
            {
                sqlConn.Open();
                rowsAffected = sqlCmd.ExecuteNonQuery();//Executes query with no return table
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);//Displays error as alert box
            }
            finally
            {
                sqlConn.Close();
            }
            return rowsAffected;
        }

        /// <summary>
        /// Rotates SQL Table around first column
        /// </summary>
        /// <param name="input">
        /// Table to Transpose
        /// </param>
        /// <returns>
        /// Transposed Table
        /// </returns>
        public static DataTable TransposeTable (DataTable input)
        {
            DataTable newTable = new DataTable();

            newTable.Columns.Add(" ");//First Column on New Table will Store Headers of Old Table
            for (int i=0; i < input.Rows.Count; i++)
            {
                newTable.Columns.Add(input.Rows[i].ItemArray[0].ToString());//Adds column to new table with name of associated row in old table
            }//Create a column for each row in put

            for (int k = 1; k < input.Columns.Count; k++)
            {
                DataRow newRow = newTable.NewRow();//Creates row of format of new table
                newRow[0] = input.Columns[k].ToString();//Copies old column name into new first column
                for (int j=1;j <= input.Rows.Count; j++)
                {
                    newRow[j] = input.Rows[j - 1][k];
                }//For each item in old column, add to new row
                newTable.Rows.Add(newRow);//Adds new row to new table
            }//Create New Row for Each Column in Old Table

            return newTable;
        }
    }
}