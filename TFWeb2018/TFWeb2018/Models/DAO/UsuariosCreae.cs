using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFWeb2018.Models.DAO
{
    public class UsuariosCreae
    {

        public bool TieneMasDeDieciOcho(int Edad)
        {
            if (Edad >= 18)
                return true;
            else
                return false;
        }

    }


 
}