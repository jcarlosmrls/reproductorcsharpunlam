using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace Reproductor
{
    class BaseDeDatos
    {
        OleDbConnection dbConnection;
        OleDbDataAdapter dbAdapter;
        DataSet dbDataSet;

        public BaseDeDatos()
        {
            dbConnection = new OleDbConnection();
            dbAdapter = new OleDbDataAdapter();
            dbDataSet = new DataSet();
        }

        public void Open(string connectionString)
        {
            dbConnection.ConnectionString = connectionString;
            try
            {
                dbConnection.Open();
            }
            catch(Exception ex)
            {
            }
        }
    }
}
