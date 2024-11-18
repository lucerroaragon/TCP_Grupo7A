using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;
using Negocio;


namespace Negocio
{
    public class PuntosReciclajeNegocio
    {
        public List<PuntosReciclaje> listarTodos()
        {
            List<PuntosReciclaje> lista = new List<PuntosReciclaje>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
               datos.setearProcedimiento("sp_PuntoReciclaje");
               
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    int idPuntoReciclaje = (int)datos.Lector["IdPuntoReciclaje"];

                    PuntosReciclaje aux = lista.FirstOrDefault(p => p.IdPuntoReciclaje == idPuntoReciclaje);

                    if (aux == null)
                    {
                        aux = new PuntosReciclaje
                        {
                            IdPuntoReciclaje = idPuntoReciclaje,
                            Nombre = (string)datos.Lector["Nombre"],
                            Direccion = (string)datos.Lector["Direccion"],
                            HoraApertura = datos.Lector["HoraApertura"].ToString(),
                            HoraCierre = datos.Lector["HoraCierre"].ToString(),
                            Telefono = (string)datos.Lector["Telefono"],
                            Municipio= (string)datos.Lector["Municipio"],
                            Provincia= (string)datos.Lector["Provincia"],
                            
                            //Imagen = (string)datos.Lector["Imagen"],
                            //Latitud = (string)datos.Lector["Latitud"],
                            //Longitud = (string)datos.Lector["Longitud"],
                            //Tipo = (string)datos.Lector["Tipo"],
                            //Descripcion = (string)datos.Lector["Descripcion"],
                            //Comentarios = new List<Comentarios>(),
                            //Likes = new List<Likes>(),
                            Imagenes = new List<string>()
                        };

                        lista.Add(aux);
                    }

                    if (!(datos.Lector["Imagen"] is DBNull))
                    {
                        string imagenes = (string)datos.Lector["Imagen"];
                        aux.Imagenes.Add(imagenes);
                    }
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

        public int agregar(PuntosReciclaje puntoReciclaje)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_AgregarPuntoReciclaje");

                datos.agregarParametro("@Nombre", puntoReciclaje.Nombre);
                datos.agregarParametro("@Email", puntoReciclaje.Email);
                datos.agregarParametro("@Direccion", puntoReciclaje.Direccion);
                datos.agregarParametro("@CodigoPostal", puntoReciclaje.CodigoPostal);
                datos.agregarParametro("@Horaapertura", puntoReciclaje.HoraApertura);
                datos.agregarParametro("@Horacierre", puntoReciclaje.HoraCierre);
                datos.agregarParametro("@Telefono", puntoReciclaje.Telefono);
                datos.agregarParametro("@fechaAlta", puntoReciclaje.FechaAlta);
                datos.agregarParametro("@Provincia", puntoReciclaje.Provincia);
                datos.agregarParametro("@Municipio", puntoReciclaje.Municipio);


                return datos.ejecutarAccionEscalar();
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

        public void modificar(PuntosReciclaje puntoReciclaje)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedModificarPuntoReciclaje");
                datos.agregarParametro("@IdPuntoReciclaje", puntoReciclaje.IdPuntoReciclaje);
                datos.agregarParametro("@Nombre", puntoReciclaje.Nombre);
                datos.agregarParametro("@Direccion", puntoReciclaje.Direccion);
                datos.agregarParametro("@Horario", puntoReciclaje.HoraApertura);
                datos.agregarParametro("@Horario", puntoReciclaje.HoraCierre);
                datos.agregarParametro("@Telefono", puntoReciclaje.Telefono);
                datos.agregarParametro("@Latitud", puntoReciclaje.Latitud);
                datos.agregarParametro("@Longitud", puntoReciclaje.Longitud);
                datos.agregarParametro("@Tipo", puntoReciclaje.Tipo);
                datos.agregarParametro("@Descripcion", puntoReciclaje.Descripcion);
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

        public void eliminar(int idPuntoReciclaje)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedEliminarPuntoReciclaje");
                datos.agregarParametro("@IdPuntoReciclaje", idPuntoReciclaje);
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



  