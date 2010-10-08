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

        public string[] Leer_Columna(string tabla, string columna)
        {
            string[] cadena;
            int cant;
            OleDbCommand cmdLeer = new OleDbCommand();

            cmdLeer.CommandType = CommandType.Text;
            cmdLeer.Connection = dbConnection;
            cmdLeer.Parameters.Add("?", columna);
            cmdLeer.Parameters.Add("?", tabla);
            cmdLeer.CommandText = @"SELECT ? FROM ?";
            dbAdapter.SelectCommand = cmdLeer;

            try
            {
                dbAdapter.Fill(dbDataSet);
                cant = dbDataSet.Tables[0].Rows.Count;
                cadena = new string[cant];
                for (int x = 0; x < cant; x++)
                    cadena[x] = dbDataSet.Tables[0].Rows[x][columna].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la base de datos.");
                return null;
            }
        }

        //lee la columna de una tabla filtrando por un columf con el valor val
        public string[] Leer_Columna(string tabla, string columna, string columf, string val)
        {
            string[] cadena;
            int cant;
            OleDbCommand cmdLeer = new OleDbCommand();

            string cad = "SELECT " + columna + " FROM " + tabla + " WHERE " + columf + " = ?";

            cmdLeer.CommandType = CommandType.Text;
            cmdLeer.Connection = dbConnection;
            cmdLeer.Parameters.Add("?", val);
            cmdLeer.CommandText = cad;
            dbAdapter.SelectCommand = cmdLeer;
            dbDataSet.Clear();// agregado clear, sino se arma lio con el dataset anterior
            try
            {
                dbAdapter.Fill(dbDataSet);
                cant = dbDataSet.Tables[0].Rows.Count;
                cadena = new string[cant];
                for (int x = 0; x < cant; x++)
                    cadena[x] = dbDataSet.Tables[0].Rows[x][columna].ToString();
                return cadena;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir la base de datos");
                return null;
            }
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

        public bool ValidarLogin(string user, string pass)
        {
            int cant;
            OleDbCommand cmdValidar = new OleDbCommand();

            cmdValidar.CommandType = CommandType.Text;
            cmdValidar.Connection = dbConnection;
            cmdValidar.Parameters.Add("?", user);
            cmdValidar.CommandText = @"SELECT Password FROM Usuario WHERE Id_usuario = ?";
            dbAdapter.SelectCommand = cmdValidar;

            dbAdapter.Fill(dbDataSet);

            cant = dbDataSet.Tables[0].Rows.Count;

            if (cant == 0)
            {
                MessageBox.Show("El Usuario ingresado no existe :(");
                return false;
            }
            else
            {
                if (dbDataSet.Tables[0].Rows[0]["Password"].ToString() == pass)
                {
                    MessageBox.Show("Bienvenido al reproductor, que la pase bien.");
                    return true;
                }
                else
                {
                    MessageBox.Show("Constraseña erronea, acceso no autorizado");
                    return false;
                }
            }
        }

        public void AgregarRutaDeArchivos(string user, string path)
        {
            OleDbCommand cmdAgregar = new OleDbCommand();

            cmdAgregar.CommandType = CommandType.Text;
            cmdAgregar.Connection = dbConnection;
            cmdAgregar.Parameters.Add("?", user);
            cmdAgregar.Parameters.Add("?", path);
            cmdAgregar.CommandText = @"INSERT INTO Ruta_De_Archivos ([Id_Usuario], [Path]) VALUES (?,?)";

            cmdAgregar.ExecuteNonQuery();
        }

        //metodo agregado
        public void QuitarRutaDeArchivos(string user, string path)
        {
            OleDbCommand cmdQuitar = new OleDbCommand();

            cmdQuitar.CommandType = CommandType.Text;
            cmdQuitar.Connection = dbConnection;
            cmdQuitar.Parameters.Add("?", user);
            cmdQuitar.Parameters.Add("?", path);
            cmdQuitar.CommandText = @"DELETE FROM Ruta_De_Archivos WHERE Id_Usuario = ? AND Path = ?";

            cmdQuitar.ExecuteNonQuery();

        }

        public void AddNewProfile(Usuario user, Configuration config)
        {

        }

        #endregion

    }
}
