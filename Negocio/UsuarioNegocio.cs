using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public void RegistrarUsuario(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
            //    SetearProcedimiento(sp_RegistrarUsuario);

            //    datos.setearParametro("@Doc", user.Nombre);
            //    datos.setearParametro("@Nom", user.Apellido);
            //    datos.setearParametro("@Ape", user.Email);
            //    datos.setearParametro("@Ema", user.Password);

            //    datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //datos.cerrarConexion();
            }
        }
        public bool ValidarUsuario(Usuario usuario)
        {
            // Lógica para validar el usuario
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //SetearProcedimiento(sp_ValidarUsuario);
                //datos.SetearParametro("@Email", usuario.Email);
                //datos.SetearParametro("@Password", usuario.Password);
                //datos.SetearParametro("@Rol", usuario.Rol);

                //datos.EjecutarAccion();
                //while (datos.Lector.Read())
                //{
                //    //usuario.idUsuario = (int)datos.Lector["idUsuario"];
                //    //usuario.Nombre = (string)datos.Lector["Nombre"];
                //    //usuario.Apellido = (string)datos.Lector["Apellido"];
                //    //usuario.Email = (string)datos.Lector["Email"];
                //    //usuario.Password = (string)datos.Lector["Password"];
                //    //usuario.Rol = (string)datos.Lector["Rol"];
                return true;
                //}
                //return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //datos.CerrarConexion();
            }
        }
    }
}
