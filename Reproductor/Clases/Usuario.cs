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

        public Usuario()
        {
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
    }
}
