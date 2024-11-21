using System;
using System.Collections;
using System.Collections.Generic;
using Dominio;

namespace Negocio
{
    public class UsuariosNegocio
    {
    
        public bool VerificarContrasenaSegura(string contrasena)
        {
            return Seguridad.ContrasenaSegura(contrasena);
        }

       
        public bool ValidarEmailExistente(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("SELECT COUNT(*) FROM USUARIOS WHERE Email = @Email");
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = (int)datos.Lector[0];
                    return count > 0; 
                }

                return false; 
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

     
        public List<Usuario> listar(string estado = "")
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if(estado != "")
                {
                    datos.setearConsulta("SELECT idUsuario, Nombre, Apellido, Email, Password, Administrador, FechaAlta FROM USUARIOS WHERE Estado = @estado");
                    datos.setearParametro("@estado", estado);
                }
                else
                {
                    datos.setearConsulta("SELECT idUsuario, Nombre, Apellido, Email, Password, Administrador, FechaAlta FROM USUARIOS");
                }
                
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
                        FechaAlta = ((DateTime)datos.Lector["FechaAlta"]).Date,
                        Administrador = Convert.ToBoolean(datos.Lector["Administrador"]) ? 1 : 0
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
            finally
            {
                datos.cerrarConexion();
            }
        }

 
        public void agregar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO USUARIOS (Nombre, Apellido, Email, Password) VALUES (@Nombre, @Apellido, @Email, @Password)");
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

 
        public void RegistrarUsuario(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO USUARIOS (Nombre, Apellido, Email, Password, FechaAlta) VALUES (@Nombre, @Apellido, @Email, @Password, @FechaAlta)");

                datos.setearParametro("@Nombre", user.Nombre);
                datos.setearParametro("@Apellido", user.Apellido);
                datos.setearParametro("@Email", user.Email);
                datos.setearParametro("@Password", user.Password);
                datos.setearParametro("@FechaAlta", user.FechaAlta);

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
                datos.setearConsulta("UPDATE USUARIOS SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email WHERE idUsuario = @idUsuario");
                datos.setearParametro("@idUsuario", usuario.idUsuario);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);

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

     
        public bool ValidarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
              
                string consulta = "SELECT COUNT(*) FROM USUARIOS WHERE Email = @Email AND Password = @Password";

              
                datos.setearConsulta(consulta);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Password", usuario.Password); 

            
                datos.ejecutarLectura();

          
                if (datos.Lector.Read())
                {
                    int count = (int)datos.Lector[0];
                    return count > 0; 
                }

                return false; 
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
        public Usuario ObtenerUsuario_id(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Nombre, Apellido, Email, Password FROM USUARIOS WHERE idusuario = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario
                    {
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Email = (string)datos.Lector["Email"],
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
