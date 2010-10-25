using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.IO;

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

        //lee la columna de una tabla
        public string[] Leer_Columna(string tabla, string columna)
        {
            string[] cadena;
            int cant;
            OleDbCommand cmdLeer = new OleDbCommand();

            string cad = "SELECT " + columna + " FROM " + tabla;

            cmdLeer.CommandType = CommandType.Text;
            cmdLeer.Connection = dbConnection;
            cmdLeer.CommandText = cad;
            dbAdapter.SelectCommand = cmdLeer;
            dbDataSet.Clear(); // agregado clear, sino se arma lio con el dataset anterior
            try
            {
                dbAdapter.Fill(dbDataSet);
                cant = dbDataSet.Tables[0].Rows.Count;
                cadena = new string[cant];
                for (int x = 0; x < cant; x++)
                    cadena[x] = dbDataSet.Tables[0].Rows[x][columna].ToString();
                return cadena;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al abrir la base de datos");
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
            catch (Exception)
            {
                MessageBox.Show("Error al abrir la base de datos");
                return null;
            }
        }

        public string[] Leer_Columna(string tabla, string columna, string columf1, string val1, string columf2, string val2)
        {
            string[] cadena;
            int cant;
            OleDbCommand cmdLeer = new OleDbCommand();

            string cad = "SELECT " + columna + " FROM " + tabla + " WHERE " + columf1 + " = ? AND " + columf2 + " = ?";

            cmdLeer.CommandType = CommandType.Text;
            cmdLeer.Connection = dbConnection;
            cmdLeer.Parameters.Add("?", val1);
            cmdLeer.Parameters.Add("?", val2);
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
            catch (Exception)
            {
                MessageBox.Show("Error al abrir la base de datos");
                return null;
            }
        }


        public int AddUser(string user, string password)
        {
            OleDbCommand cmdInsertar = new OleDbCommand();
            OleDbCommand cmdPerfil = new OleDbCommand();
            OleDbCommand cmdConfiguraciones = new OleDbCommand();
            
            cmdInsertar.Connection = dbConnection;
            cmdInsertar.Parameters.Add("?", user);
            cmdInsertar.Parameters.Add("?", password);
            cmdInsertar.CommandText = @"INSERT INTO Usuario ([Id_Usuario], [Password]) VALUES (?,?)";

            try
            {
                cmdInsertar.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("El nombre de usuario seleccionado ya está en uso. Por favor, elija otro.", "Error");
                return -1;
            }

            //Si pudo crear el usuario, defino las operaciones restantes
            cmdPerfil.Connection = dbConnection;
            cmdPerfil.Parameters.Add("?", user);
            cmdPerfil.Parameters.Add("?", "Normal");    //Es el perfil que se crea por defecto
            cmdPerfil.CommandText = @"INSERT INTO Perfil ([Id_Usuario], [Nombre]) VALUES (?, ?)";

            cmdConfiguraciones.Connection = dbConnection;
            cmdConfiguraciones.Parameters.Add("?", user);
            cmdConfiguraciones.Parameters.Add("?", "Normal");   //El nombre del skin por defecto
            cmdConfiguraciones.Parameters.Add("?", "Normal");   //El nombre del ultimo Perfil usado
            cmdConfiguraciones.CommandText = @"INSERT INTO Configuraciones ([Id_Usuario], [Skin], [Perfil]) VALUES (?, ?, ?)";

            try
            {
                cmdPerfil.ExecuteNonQuery();
                cmdConfiguraciones.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar crear el usuario.", "ERROR");
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

        public void ActualizarRutaDeArchivos(string user, List<string> paths)
        {
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("?", user);

            cmd.CommandText = @"DELETE FROM Ruta_De_Archivos WHERE Id_Usuario = ?";
            try
            {
                cmd.ExecuteNonQuery();

                for (int x = 0; x < paths.Count; x++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("?", user);
                    cmd.Parameters.Add("?", paths[x]);
                    cmd.CommandText = @"INSERT INTO Ruta_De_Archivos ([Id_Usuario], [Path]) VALUES (?,?)";
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Se producido un error en la base de datos");
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

        //metodo que va a generar la lista de canciones en los directorios seleccionados
        private List<string> ListaPathsCanciones(string[] paths)
        {
            List<string> canciones = new List<string>();

            foreach (string path in paths)
            {
                //obtiene una lista  por cada formato
                foreach (string cad in Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories))
                {


                    canciones.Add(cad.ToString());

                }
                foreach (string cad in Directory.GetFiles(path, "*.wav", SearchOption.AllDirectories))
                {


                    canciones.Add(cad.ToString());

                }
                foreach (string cad in Directory.GetFiles(path, "*.mid", SearchOption.AllDirectories))
                {


                    canciones.Add(cad.ToString());

                }
            }

            return canciones;
        }

        private bool ExisteCancion(string path)
        {

            if (Leer_Columna("Cancion", "Path", "Path", path).Length > 0)
                return true;
            else
                return false;
        }

        public string InterpreteId(string nombre)
        {
            try //controla si el nombre es de tamaño 0 o si es nulo
            {
                if (nombre.Length == 0)
                    nombre = "?";
            }
            catch (Exception)
            {
                nombre = "?";
            }

            string[] lista;
            lista = Leer_Columna("Interprete", "Id", "Nombre", nombre); //realizo una busqueda en al bd de los interpretes con ese nombre

            if (lista.Length == 0)
                return "";
            else
                return lista[0];
        }

        public string AlbumId(string nombre, string idInterprete)
        {
            try//controla si el nombre es de tamaño 0 o si es nulo
            {
                if (nombre.Length == 0)
                    nombre = "?";
            }
            catch (Exception)
            {
                nombre = "?";
            }

            string[] lista;
            lista = Leer_Columna("Album", "Id_Album", "Nombre", nombre, "Id_Interprete", idInterprete); //busqueda en la bd de los albunes con ese nombre

            if (lista.Length == 0)
                return "";
            else
                return lista[0];
        }


        private string AgregarInterprete(string nombre)
        {
            try//controla si el nombre es de tamaño 0 o si es nulo
            {
                if (nombre.Length == 0)
                    nombre = "?";
            }
            catch (Exception)
            {
                nombre = "?";
            }

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("?", nombre);

            cmd.CommandText = @"INSERT INTO Interprete ([Nombre]) VALUES (?)";
            cmd.ExecuteNonQuery();

            return InterpreteId(nombre);

        }

        private string AgregarAlbum(Cancion cancion, string idInterprete)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbConnection;

            string album = cancion.Album;

            try//controla si el album es de tamaño 0 o si es nulo
            {
                if (album.Length == 0)
                    album = "?";
            }
            catch (Exception)
            {
                album = "?";
            }

            cmd.Parameters.Add("?", album);
            cmd.Parameters.Add("?", idInterprete);
            cmd.Parameters.Add("?", cancion.Genero);
            cmd.Parameters.Add("?", cancion.Año);
            //cmd.Parameters.Add("?", cancion.Imagen);

            cmd.CommandText = @"INSERT INTO Album ([Nombre],[Id_Interprete],[Genero],[Año]) VALUES (?,?,?,?)";
            cmd.ExecuteNonQuery();

            return AlbumId(cancion.Album, idInterprete);
        }

        private void AgregarCancion(Cancion cancion, string idAlbum)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("?", idAlbum);
            cmd.Parameters.Add("?", cancion.Nombre);
            //cmd.Parameters.Add("?", cancion.numero);
            cmd.Parameters.Add("?", cancion.Duracion);
            cmd.Parameters.Add("?", cancion.Ruta);

            cmd.CommandText = @"INSERT INTO Cancion ([Id_Album],[Titulo],[Duracion],[Path]) VALUES (?,?,?,?)";
            cmd.ExecuteNonQuery();
        }

    /*    public void AgregarCancion(string album, string lista, string titulo, uint numero, TimeSpan duracion, string path)
        {
            OleDbCommand cmd = new OleDbCommand();

            //Defino las caracteristicas del comando
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbConnection;

            //Creo los parametros
            cmd.Parameters.Add("?", album);
            cmd.Parameters.Add("?", lista);
            cmd.Parameters.Add("?", titulo);
            cmd.Parameters.Add("?", numero);
            cmd.Parameters.Add("?", duracion);
            cmd.Parameters.Add("?", path);

            cmd.CommandText = @"INSERT INTO Cancion ([Id_Album], [Id_Lista], [Titulo], [Numero_Cancion], [Duracion], [Path]) VALUES (?,?,?,?,?,?)";
            cmd.ExecuteNonQuery();
        }*/

        // funcion que actualiza las canciones en la base de datos, 
        public void ActualizarCanciones(PantallaPrincipal ventana)
        {
            List<string> canciones;

            //obtengo una lista de los paths de canciones en base a los directorios guardados en la base de datos
            canciones = ListaPathsCanciones(Leer_Columna("Ruta_De_Archivos", "Path", "Id_Usuario", ventana.UsuarioActual.Id));

            foreach (string path in canciones)
            {

                if (!ExisteCancion(path)) // controlo si el path de la cancion ya esta en la base de datos.
                {

                    Cancion cancion = new Cancion(path); //creo objeto cancion
                    string idInterprete = InterpreteId(cancion.Artista);
                    string idAlbum = AlbumId(cancion.Album, idInterprete); //obtengo los ids de album y interprete.
                    if (idInterprete == "") // controlo si el interprete no existe
                    {
                        idInterprete = AgregarInterprete(cancion.Artista);
                        idAlbum = AgregarAlbum(cancion, idInterprete);
                    }
                    else
                    {
                        if (idAlbum == "") //controlo si el album no existe
                        {
                            idAlbum = AgregarAlbum(cancion, idInterprete);
                        }
                    }

                    AgregarCancion(cancion, idAlbum);
                }
            }
        }

        public List<Cancion> CancionDeCadaAlbum(string interprete)
        {
            List<Cancion> canciones = new List<Cancion>();
            string idInteprete = InterpreteId(interprete);

            foreach (string idAlbum in Leer_Columna("Album", "Id_Album", "Id_Interprete", idInteprete))
            {
                string[] aux = Leer_Columna("Cancion", "Path", "Id_Album", idAlbum);
                if (aux != null)
                {
                    try
                    {
                        canciones.Add(new Cancion(aux[0]));
                    }
                    catch (Exception)
                    {//si tira excepcion aca es porque el erchivo de musca ya no existe
                        BorrarCancion(idInteprete, idAlbum, aux[0]);
                    }
                }

            }
            return canciones;
        }

        public void BorrarCancion(string idInterete, string idAlbum, string path)
        {
            BorrarRegistro("Cancion", "Path", path);

            string[] cadena;
            cadena = Leer_Columna("Cancion", "Id_Album", "Id_ALbum", idAlbum);

            if (cadena.Length == 0)
            {
                BorrarRegistro("Album", "Id_Album", idAlbum);
                cadena = Leer_Columna("Album", "Id_Interprete", "Id_Interprete", idInterete);
                if (cadena.Length == 0)
                {
                    BorrarRegistro("Interprete", "Id", idInterete);
                }
            }
        }

        public void BorrarRegistro(string tabla, string columf, string val)
        {
            OleDbCommand cmdBorrar = new OleDbCommand();

            string cad = "DELETE FROM " + tabla + " WHERE " + columf + " = ?";

            cmdBorrar.CommandType = CommandType.Text;
            cmdBorrar.Connection = dbConnection;
            cmdBorrar.Parameters.Add("?", val);
            cmdBorrar.CommandText = cad;

            try
            {
                cmdBorrar.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al abrir la base de datos");
            }
        }

        #endregion
    }
}
