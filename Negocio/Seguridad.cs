using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool ValidarUsuario(object user)
        {
            // Lógica para validar el usuario
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario == null)
            {
                return false;
            }
            return true;
        }
        public static bool esAdmin(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (usuario != null && usuario.Rol == "admin")
            {
                return true;
            }
            return false;
        }
    }
}
