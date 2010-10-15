using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Reproductor
{
    public class Configuracion
    {
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
    }
}
