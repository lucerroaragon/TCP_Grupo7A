using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;


namespace Negocio
{
    public class UsuariosNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT idUsuario, Nombre, Apellido, DNI, Email, Telefono, Direccion, Password, Role FROM USUARIOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario
                    {
                        idUsuario = (int)datos.Lector["idUsuario"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        DNI = (string)datos.Lector["DNI"],
                        Email = (string)datos.Lector["Email"],
                        Telefono = (string)datos.Lector["Telefono"],
                        Direccion = (string)datos.Lector["Direccion"],
                        Password = (string)datos.Lector["Password"],
                        Role = (string)datos.Lector["Role"]
                    };

                    lista.Add(aux);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO USUARIOS (Nombre, Apellido, DNI, Email, Telefono, Direccion, Password, Role) VALUES (@Nombre, @Apellido, @DNI, @Email, @Telefono, @Direccion, @Password, @Role)");
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@DNI", usuario.DNI);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@Direccion", usuario.Direccion);
                datos.setearParametro("@Password", usuario.Password);
                datos.setearParametro("@Role", usuario.Role);
                datos.ejecutarAccion();
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

        public void eliminar(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM USUARIOS WHERE idUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.ejecutarAccion();
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

        public void modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USUARIOS SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Email = @Email, Telefono = @Telefono, Direccion = @Direccion, Password = @Password, Role = @Role WHERE idUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", usuario.idUsuario);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@DNI", usuario.DNI);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Telefono", usuario.Telefono);
                datos.setearParametro("@Direccion", usuario.Direccion);
                datos.setearParametro("@Password", usuario.Password);
                datos.setearParametro("@Role", usuario.Role);
                datos.ejecutarAccion();
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

