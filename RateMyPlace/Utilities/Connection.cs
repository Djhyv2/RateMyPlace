﻿using System;
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
        /// <param name="SQL">
        /// Text of SQL to execute
        /// </param>
        /// <returns>
        /// Number of rows affected
        /// </returns>
        public static int RunNonQuerySQL(string SQL)
        {
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString);//Gets connection string from Web.Config, requires the System.Configuration
            SqlCommand sqlCmd = new SqlCommand(SQL, sqlConn);
            int rowsAffected = -1;
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
    }
}