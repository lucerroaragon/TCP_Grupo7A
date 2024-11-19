using System;
using System.Collections;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class UsuariosNegocio
    {
        // Método para verificar si la contraseña es segura antes de registrar un usuario
        public bool VerificarContrasenaSegura(string contrasena)
        {
            return Seguridad.ContrasenaSegura(contrasena);
        }

        // Método para verificar si el email ya está registrado en la base de datos
        public bool ValidarEmailExistente(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Consulta SQL para verificar si el correo ya está en la base de datos
                datos.setearConsulta("SELECT COUNT(*) FROM USUARIOS WHERE Email = @Email");
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = (int)datos.Lector[0];
                    return count > 0; // Si se encuentra un registro, el correo ya está en uso
                }

                return false; // Si no se encuentra ningún registro, el email es único
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion(); // Asegurarse de cerrar la conexión
            }
        }

        // Método para listar todos los usuarios
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT idUsuario, Nombre, Apellido, DNI, Email, Direccion, Password, Administrador FROM USUARIOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario
                    {
                        idUsuario = (int)datos.Lector["idUsuario"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Email = (string)datos.Lector["Email"],
                        Password = (string)datos.Lector["Password"],
                        Administrador = (int)datos.Lector["Administrador"]
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

        // Método para agregar un nuevo usuario
        public void agregar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO USUARIOS (Nombre, Apellido, Email, Direccion, Password) VALUES (@Nombre, @Apellido, @Email, @Password, @Rol)");
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Password", usuario.Password);
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

        // Método para registrar un nuevo usuario
        public void RegistrarUsuario(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO USUARIOS (Nombre, Apellido, Email, Password) VALUES (@Nombre, @Apellido, @Email, @Password)");

                datos.setearParametro("@Nombre", user.Nombre);
                datos.setearParametro("@Apellido", user.Apellido);
                datos.setearParametro("@Email", user.Email);
                datos.setearParametro("@Password", user.Password);

                datos.ejecutarAccion();
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

        // Método para eliminar un usuario por su ID
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

        // Método para modificar los datos de un usuario
        public void modificar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE USUARIOS SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Password = @Password, Administrador = @Admin WHERE idUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", usuario.idUsuario);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Password", usuario.Password);
                datos.setearParametro("@Admin", usuario.Administrador);
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

        // Método para validar un usuario (por ejemplo, para iniciar sesión)
        public bool ValidarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Consulta SQL para verificar el correo electrónico y la contraseña
                string consulta = "SELECT COUNT(*) FROM USUARIOS WHERE Email = @Email AND Password = @Password";

                // Establecer la consulta
                datos.setearConsulta(consulta);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Password", usuario.Password); // Si la contraseña está hasheada, utiliza la misma función de hash aquí

                // Ejecutar la consulta
                datos.ejecutarLectura();

                // Leer el resultado de la consulta
                if (datos.Lector.Read())
                {
                    int count = (int)datos.Lector[0];
                    return count > 0; // Si el resultado es mayor que 0, el usuario y la contraseña son correctos
                }

                return false; // Si no se encontró ningún resultado, la validación falla
            }
            catch (Exception ex)
            {
                throw ex; // Lanza la excepción en caso de error
            }
            finally
            {
                datos.cerrarConexion(); // Asegúrate de cerrar la conexión
            }
        }

        public Usuario ObtenerUsuario(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT idUsuario, Nombre, Apellido, Email, Password, Administrador FROM USUARIOS WHERE Email = @Email AND Estado = 1 ");
                datos.setearParametro("@Email", user.Email);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario
                    {
                        idUsuario = (int)datos.Lector["idUsuario"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Email = (string)datos.Lector["Email"],
                        Password = (string)datos.Lector["Password"],
                        Administrador = Convert.ToBoolean(datos.Lector["Administrador"]) ? 1 : 0
                    };

                    return aux;
                }
            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return null;
        }
    }

}
