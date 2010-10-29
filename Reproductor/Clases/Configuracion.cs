using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Reproductor
{
    public class Configuracion
    {
        List<string> perfiles;
        private string perfil;
        private string skin;
        private string path;

        public Configuracion()
        {
            path = Directory.GetCurrentDirectory();
            path = path.Remove(path.LastIndexOf("\\"));
            path = path.Remove(path.LastIndexOf("\\"));
            path = path.Remove(path.LastIndexOf("\\"));
            path += "\\Base_Reproductor.mdb";
        }

        public List<string> Perfiles
        {
            get
            {
                return perfiles;
            }
            set
            {
                perfiles = value;
            }
        }
        
        public string Perfil
        {
            get
            {
                return perfil;
            }
            set
            {
                perfil = value;
            }
        }

        public string Skin
        {
            get
            {
                return skin;
            }
          set
            {
                skin = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }
        }

        public void CargarPerfiles(ref BaseDeDatos db, string idUsuario)
        {
            //Cargo la lista de perfiles de acuerdo al usuario
            perfiles = new List<string>(db.Leer_Columna("Perfil", "Nombre", "Id_Usuario", idUsuario));
        }
    }
}
