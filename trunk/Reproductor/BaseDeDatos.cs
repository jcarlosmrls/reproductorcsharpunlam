using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Reproductor
{
    public class BaseDeDatos
    {
        private OleDbConnection dbConnection;
        private OleDbDataAdapter dbAdapter;
        private DataSet dbDataSet;

        public BaseDeDatos()
        {
            dbConnection = new OleDbConnection();
            dbAdapter = new OleDbDataAdapter();
            dbDataSet = new DataSet();
        }

        #region Metodos

        public void Open(string connectionString)
        {
            dbConnection.ConnectionString = connectionString;
            try
            {
                dbConnection.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Close()
        {
            dbConnection.Close();
        }

        public int AddUser(string user, string password)
        {
            OleDbCommand cmdInsertar = new OleDbCommand();

            cmdInsertar.Connection = dbConnection;
            cmdInsertar.Parameters.Add("?", user);
            cmdInsertar.Parameters.Add("?", password);
            cmdInsertar.CommandText = @"INSERT INTO Usuario ([Id_Usuario], [Password]) VALUES (?,?)";
            try
            {
                cmdInsertar.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El nombre de usuario seleccionado ya está en uso. Por favor, elija otro.", "Error");
                return -1;
            }
            return 0;
        }

        #endregion

    }
}
