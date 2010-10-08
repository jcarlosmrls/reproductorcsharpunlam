using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor.Clases
{
    public class Configuraciones
    {
        private string skin;        //Contiene el nombre del último skin usado/Skin actual
        private string perfil;      //Contiene el nombre del último perfil usado/Perfil actual

        private Configuraciones()
        {
            skin = "Default";
            perfil = "Default";
        }
    }
}
