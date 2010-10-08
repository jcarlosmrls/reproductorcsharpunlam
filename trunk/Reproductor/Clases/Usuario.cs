using System;
using System.Collections.Generic;
using System.Text;

namespace Reproductor
{
    public class Usuario
    {
        private string ID;

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
    }
}
