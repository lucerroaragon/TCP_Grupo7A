using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TipoReciclajeNegocio
    {
        public void GuardarTipoReciclaje(int idPunto,  int idTipo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into PUNTOSRECICLAJE_TIPOSRECICLAJE values (@IdPuntoReciclaje, @IdTipo)");
                datos.setearParametro("@IdPuntoReciclaje", idPunto);
                datos.setearParametro("@IdTipo", idTipo);
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

        public List<TipoReciclaje> Listar()
        {
            List<TipoReciclaje> lista = new List<TipoReciclaje>();
            TipoReciclaje tipoReciclaje = new TipoReciclaje();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select IdTipo, Nombretipo from TiposReciclaje");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    tipoReciclaje = new TipoReciclaje();
                    tipoReciclaje.IdTipo = (int)datos.Lector["IdTipo"];
                    tipoReciclaje.NombreTipo = (string)datos.Lector["NombreTipo"];
                    lista.Add(tipoReciclaje);
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
        public List<string> ListarPorId(int id)
        {
            List<string> lista = new List<string>();
            TipoReciclaje tipoReciclaje = new TipoReciclaje();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_NombreTipoReciclajeporIdPuntoReciclaje");
                datos.setearParametro("@IdPuntoReciclaje", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    lista.Add((string)datos.Lector["NombreTipo"]);
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
    }
}
