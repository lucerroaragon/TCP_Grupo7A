using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ImagenesNegocio
    {
        public int GuardarRutaImagenes(int puntoId, string ruta, string nombreImagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarImagen");
                datos.setearParametro("@IdPuntoReciclaje", puntoId);
                datos.setearParametro("@Ruta", ruta);
                datos.setearParametro("@NombreImagen", nombreImagen);
                return datos.ejecutarAccionEscalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int obtenerUltimoIdImg()
        {
            AccesoDatos datos = new AccesoDatos();
            int id = 0;
            try
            {
                datos.setearConsulta("select top(1) id from IMAGENES ORDER by id DESC");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    id = (int)datos.Lector["id"];
                }
                return id;
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
