using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class LikesNegocio
    {

        public List<Likes> ListarPorPuntoReciclaje(int idPuntoReciclaje)
        {
            List<Likes> lista = new List<Likes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdLike, IdUsuario, IdPuntoReciclaje FROM LIKES WHERE IdPuntoReciclaje = @IdPuntoReciclaje");
                datos.setearParametro("@IdPuntoReciclaje", idPuntoReciclaje);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Likes like = new Likes
                    {
                        IdLike = (int)datos.Lector["IdLike"],
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        IdPuntoReciclaje = (int)datos.Lector["IdPuntoReciclaje"],
                        PuntosReciclaje = new PuntosReciclaje { IdPuntoReciclaje = (int)datos.Lector["IdPuntoReciclaje"] },
                        Ususario = new Usuario { idUsuario = (int)datos.Lector["IdUsuario"] }
                    };

                    lista.Add(like);
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

        // Agregue esta validacion para que un usuario no pueda dar más de un like 
        public void Agregar(Likes like)
        {
            if (ExisteLike(like.IdUsuario, like.IdPuntoReciclaje))
            {
                throw new Exception("El usuario ya ha dado 'me gusta' a este punto de reciclaje.");
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO LIKES (IdUsuario, IdPuntoReciclaje) VALUES (@IdUsuario, @IdPuntoReciclaje)");
                datos.setearParametro("@IdUsuario", like.IdUsuario);
                datos.setearParametro("@IdPuntoReciclaje", like.IdPuntoReciclaje);

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

        // Se verifica si el usuario ya dio 'me gusta' a un punto de reciclaje
        private bool ExisteLike(int idUsuario, int idPuntoReciclaje)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM LIKES WHERE IdUsuario = @IdUsuario AND IdPuntoReciclaje = @IdPuntoReciclaje");
                datos.setearParametro("@IdUsuario", idUsuario);
                datos.setearParametro("@IdPuntoReciclaje", idPuntoReciclaje);

                int count = (int)datos.ejecutarEscalar();
                return count > 0;
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

    
        public void Eliminar(int idLike)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM LIKES WHERE IdLike = @IdLike");
                datos.setearParametro("@IdLike", idLike);

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

        // Maxi es para contar likes en un punto de reciclaje , me parecio copado para tener estadisticas
        public int ContarLikes(int idPuntoReciclaje)
        {
            AccesoDatos datos = new AccesoDatos();
            int contador = 0;

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM LIKES WHERE IdPuntoReciclaje = @IdPuntoReciclaje");
                datos.setearParametro("@IdPuntoReciclaje", idPuntoReciclaje);
                contador = (int)datos.ejecutarEscalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return contador;
        }
    }
}