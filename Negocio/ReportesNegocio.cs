using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class ReportesNegocio
    {
        public List<Reportes> listar()
        {
            List<Reportes> lista = new List<Reportes>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IdReporte, IdUsuario, IdPuntoReciclaje, Motivo, FechaReporte FROM Reportes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Reportes aux = new Reportes
                    {
                        IdReporte = (int)datos.Lector["IdReporte"],
                        IdUsuario = (int)datos.Lector["IdUsuario"],
                        IdPuntoReciclaje = (int)datos.Lector["IdPuntoReciclaje"],
                        Motivo = (string)datos.Lector["Motivo"],
                        FechaReporte = (DateTime)datos.Lector["FechaReporte"]
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

        public void agregar(Reportes reporte)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Reportes (IdUsuario, IdPuntoReciclaje, Motivo, FechaReporte) VALUES (@IdUsuario, @IdPuntoReciclaje, @Motivo, @FechaReporte)");
                datos.setearParametro("@IdUsuario", reporte.IdUsuario);
                datos.setearParametro("@IdPuntoReciclaje", reporte.IdPuntoReciclaje);
                datos.setearParametro("@Motivo", reporte.Motivo);
                datos.setearParametro("@FechaReporte", reporte.FechaReporte);
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

        public void eliminar(int idReporte)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM Reportes WHERE IdReporte = @IdReporte");
                datos.setearParametro("@IdReporte", idReporte);
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

        public void modificar(Reportes reporte)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Reportes SET IdUsuario = @IdUsuario, IdPuntoReciclaje = @IdPuntoReciclaje, Motivo = @Motivo, FechaReporte = @FechaReporte WHERE IdReporte = @IdReporte");
                datos.setearParametro("@IdReporte", reporte.IdReporte);
                datos.setearParametro("@IdUsuario", reporte.IdUsuario);
                datos.setearParametro("@IdPuntoReciclaje", reporte.IdPuntoReciclaje);
                datos.setearParametro("@Motivo", reporte.Motivo);
                datos.setearParametro("@FechaReporte", reporte.FechaReporte);
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