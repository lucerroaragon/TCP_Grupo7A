using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ComentariosNegocio
    {

        public List<Comentarios> Listar()
        {
            List<Comentarios> lista = new List<Comentarios>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setearConsulta("SELECT IdComentario, IdUsuario, IdPuntoReciclaje, Comentario, Fecha, Estado FROM COMENTARIOS");
                datos.setearProcedimiento("sp_ObtenerComentariosPorPunto");
                
                datos.ejecutarLectura();

                while (datos.Lector.Read())

                {

                    Comentarios comentario = new Comentarios

                    {
                        IdComentario = (int)datos.Lector["IdComentario"],
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        IdPuntoReciclaje = (int)datos.Lector["IdPuntoReciclaje"],
                        Comentario = (string)datos.Lector["Comentario"],
                        FechaCometario = (DateTime)datos.Lector["Fecha"],
                        PuntosReciclaje = new PuntosReciclaje { IdPuntoReciclaje = (int)datos.Lector["IdPuntoReciclaje"] },
                        Usuario = new Usuario
                        {
                            idUsuario = (int)datos.Lector["IdUsuario"],
                            Nombre = (string)datos.Lector["NombreUsuario"],
                            Apellido = (string)datos.Lector["ApellidoUsuario"],
                            Email = (string)datos.Lector["EmailUsuario"],
                        }
                    };

                    lista.Add(comentario);
                }

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


        public void Agregar(Comentarios comentario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO COMENTARIOS (IdPuntoReciclaje, IdUsuario, Comentario, Fecha, Estado) VALUES (@IdPuntoReciclaje, @IdUsuario, @Comentario, @Fecha, @Estado)");
                datos.setearParametro("@IdPuntoReciclaje", comentario.IdPuntoReciclaje);
                datos.setearParametro("@IdUsuario", comentario.IdUsuario);
                datos.setearParametro("@Comentario", comentario.Comentario);
                datos.setearParametro("@Fecha", comentario.FechaCometario);
                datos.setearParametro("@Estado", 1);

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


        public List<Comentarios> ListarComentariosPorPunto(int idPuntoReciclaje)
        {
            List<Comentarios> lista = new List<Comentarios>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Establece el procedimiento almacenado y su parámetro
                datos.setearProcedimiento("sp_ObtenerComentariosPorPunto");
                datos.setearParametro("@IdPuntoReciclaje", idPuntoReciclaje);

                datos.ejecutarLectura();

                // Lee los resultados y construye la lista de comentarios
                while (datos.Lector.Read())
                {
                    Comentarios comentario = new Comentarios
                    {
                        IdComentario = (int)datos.Lector["IdComentario"],
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        IdPuntoReciclaje = (int)datos.Lector["IdPuntoReciclaje"],
                        Comentario = (string)datos.Lector["Comentario"],
                        FechaCometario = (DateTime)datos.Lector["FechaComentario"],
                        Usuario = new Usuario
                        {
                            idUsuario = (int)datos.Lector["IdUsuario"],
                            Nombre = (string)datos.Lector["NombreUsuario"],
                            Apellido = (string)datos.Lector["ApellidoUsuario"],
                            Email = (string)datos.Lector["EmailUsuario"],
                        }
                    };

                    lista.Add(comentario);
                }

                return lista;
            }
            catch (Exception ex)
            {
                // Lanza una excepción con más contexto
                throw new Exception("Error al listar los comentarios del punto de reciclaje.", ex);
            }
            finally
            {
                // Asegura que la conexión se cierre
                datos.cerrarConexion();
            }
        }


        public void Eliminar(int idComentario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM COMENTARIOS WHERE IdComentario = @IdComentario");
                datos.setearParametro("@IdComentario", idComentario);

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
