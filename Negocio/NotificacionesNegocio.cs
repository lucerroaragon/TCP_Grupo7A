using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class NotificacionesNegocio
    {

        public List<Notificaciones> ListarPorUsuario(int usuarioId)
        {
            List<Notificaciones> lista = new List<Notificaciones>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, UsuarioId, Mensaje, FechaNotificacion, EsLeida FROM NOTIFICACIONES WHERE UsuarioId = @UsuarioId");
                datos.setearParametro("@UsuarioId", usuarioId);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Notificaciones notificacion = new Notificaciones
                    {
                        Id = (int)datos.Lector["Id"],
                        UsuarioId = (int)datos.Lector["UsuarioId"],
                        Mensaje = (string)datos.Lector["Mensaje"],
                        FechaNotificacion = (DateTime)datos.Lector["FechaNotificacion"],
                        EsLeida = (bool)datos.Lector["EsLeida"],
                        Usuario = new Usuario { idUsuario = (int)datos.Lector["UsuarioId"] }
                    };

                    lista.Add(notificacion);
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

        
        public void Agregar(Notificaciones notificacion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO NOTIFICACIONES (UsuarioId, Mensaje, FechaNotificacion, EsLeida) VALUES (@UsuarioId, @Mensaje, @FechaNotificacion, @EsLeida)");
                datos.setearParametro("@UsuarioId", notificacion.UsuarioId);
                datos.setearParametro("@Mensaje", notificacion.Mensaje);
                datos.setearParametro("@FechaNotificacion", notificacion.FechaNotificacion);
                datos.setearParametro("@EsLeida", notificacion.EsLeida);

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

       
        public void MarcarComoLeida(int idNotificacion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE NOTIFICACIONES SET EsLeida = 1 WHERE Id = @Id");
                datos.setearParametro("@Id", idNotificacion);

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

      
        public void Eliminar(int idNotificacion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM NOTIFICACIONES WHERE Id = @Id");
                datos.setearParametro("@Id", idNotificacion);

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

