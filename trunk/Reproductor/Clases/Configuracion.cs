using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;

namespace Reproductor
{
    public class Configuracion
    {
        List<string> perfiles;
        List<string> skinsList;
        private string perfil;
        private string skin;
        private Color colorClaro;
        private Color colorOscuro;
        private string path;
        private string skinsPath;

        public Configuracion()
        {
            //Obtengo la ruta de la base de datos
            path = Directory.GetCurrentDirectory();
            path = path.Remove(path.LastIndexOf("\\"));
            path = path.Remove(path.LastIndexOf("\\"));
            path = path.Remove(path.LastIndexOf("\\"));
            path += "\\Base_Reproductor.mdb";

            //Obtengo la lista de skins, ubicada en la carpeta "Skins" del directorio del reproductor
            skinsPath = Directory.GetCurrentDirectory() + "\\Skins";
            skinsList = new List<string>(Directory.GetDirectories(skinsPath));

            //Ahora parseo los strings, para sacar la ruta completa
            for (int i = 0; i < skinsList.Count; i++)
            {
                skinsList[i] = skinsList[i].Substring(skinsList[i].LastIndexOf("\\") + 1);
            }

            //Defino colores por defecto
            colorClaro = Color.FromName("Control");
            colorOscuro = Color.FromName("Control");
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

        public List<string> Skins
        {
            get
            {
                return skinsList;
            }
            set
            {
                skinsList = value;
            }
        }
        
        public string UltimoPerfilUsado
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

        public string UltimoSkinUsado
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

        public string SkinsPath
        {
            get
            {
                return skinsPath;
            }
        }

        public Color ColorClaro
        {
            get
            {
                return colorClaro;
            }
            set
            {
                colorClaro = value;
            }
        }

        public Color ColorOscuro
        {
            get
            {
                return colorOscuro;
            }
            set
            {
                colorOscuro = value;
            }
        }

        public void CargarPerfiles(ref BaseDeDatos db, string idUsuario)
        {
            //Cargo la lista de perfiles de acuerdo al usuario
            perfiles = new List<string>(db.Leer_Columna("Perfil", "Nombre", "Id_Usuario", idUsuario));
        }

        public void CargarUltimaConfiguracion(ref BaseDeDatos db, string idUsuario)
        {
            string[] aux;
            
            //Leo el ultimo skin usado
            aux = db.Leer_Columna("Configuraciones", "Skin", "Id_Usuario", idUsuario);
            skin = aux[0];

            //Leo el ultimo perfil usado
            aux = db.Leer_Columna("Configuraciones", "Perfil", "Id_Usuario", idUsuario);
            perfil = aux[0];
        }
    }
}
