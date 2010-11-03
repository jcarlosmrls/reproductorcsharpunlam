using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor
{
    public class Usuario
    {
        private string ID;
        private string password;
        private bool isNewUser;
        private Configuracion config;

        public Usuario()
        {
            config = new Configuracion();
        }
        
        public string Id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public bool IsNewUser
        {
            get
            {
                return isNewUser;
            }
            set
            {
                isNewUser = value;
            }
        }

        public Configuracion Configuracion
        {
            get
            {
                return config;
            }
            set
            {
                config = value;
            }
        }
    }
}
