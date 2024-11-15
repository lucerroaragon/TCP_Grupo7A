using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static bool ContrasenaSegura(string contrasena)
        {
            string patronSeguridad = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$";
            return Regex.IsMatch(contrasena, patronSeguridad);
        }

        public static void Main()
        {
            string contrasena = "Ejemplo@123";
            if (ContrasenaSegura(contrasena))
            {
                Console.WriteLine("Contraseña segura");
            }
            else
            {
                Console.WriteLine("La contraseña no cumple con los requisitos de seguridad");
            }
        }
        public static int ObtenerCodVerificación()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("GenerateNumeroVerificacion");
                return datos.ejecutarAccionEscalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
