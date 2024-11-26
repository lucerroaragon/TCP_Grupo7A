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
        public List<PuntosReciclaje> listarTodos(string estado = "")
        {
            List<PuntosReciclaje> lista = new List<PuntosReciclaje>();
            TipoReciclajeNegocio tipoReciclajeNegocio = new TipoReciclajeNegocio();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if(estado == "")
                {
                    datos.setearProcedimiento("sp_PuntoReciclaje");
                }
                else
                {
                    datos.setearProcedimiento("sp_PuntoReciclaje_por_Estado");
                    datos.agregarParametro("@Estado", estado);
                }

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
                            Usuario = new Usuario             
                            {
                                idUsuario = (int)datos.Lector["IdUsuario"],
                                Nombre = (string)datos.Lector["NombreUsuario"],
                                Apellido = (string)datos.Lector["ApellidoUsuario"],
                                Email = (string)datos.Lector["EmailUsuario"],                                
                            },
                            Nombre = (string)datos.Lector["NombrePunto"],
                            Email = (string)datos.Lector["Email"],
                            Direccion = (string)datos.Lector["Direccion"],
                            HoraApertura = datos.Lector["HoraApertura"].ToString(),
                            HoraCierre = datos.Lector["HoraCierre"].ToString(),
                            Telefono = (string)datos.Lector["Telefono"],
                            Municipio = (string)datos.Lector["Municipio"],
                            Provincia = (string)datos.Lector["Provincia"],
                            Localidad = (string)datos.Lector["Localidad"],
                            FechaAlta = (DateTime)datos.Lector["FechaAlta"],
                            Estado = datos.Lector["Estado"].ToString(),

                            //Imagen = (string)datos.Lector["Imagen"],
                            //Latitud = (string)datos.Lector["Latitud"],
                            //Longitud = (string)datos.Lector["Longitud"],
                            //Tipo = (string)datos.Lector["Tipo"],
                            //Descripcion = (string)datos.Lector["Descripcion"],
                            //Comentarios = new List<Comentarios>(),
                            //Likes = new List<Likes>(),
                            Imagenes = new List<string>(),
                            TipoReciclaje = new List<string>()
                        };

                        lista.Add(aux);
                    }

                    if (!(datos.Lector["NombreImagen"] is DBNull))
                    {
                        string imagenes = (string)datos.Lector["NombreImagen"];
                        aux.Imagenes.Add(imagenes);
                    }
                    aux.TipoReciclaje = tipoReciclajeNegocio.ListarPorId(idPuntoReciclaje);

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
            try {
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
                datos.agregarParametro("@Localidad", puntoReciclaje.Localidad);
                datos.agregarParametro("@IdUsuario", puntoReciclaje.Usuario.idUsuario);

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
                datos.setearProcedimiento("sp_ModificarPuntoReciclaje");
                datos.agregarParametro("@IdPuntoReciclaje", puntoReciclaje.IdPuntoReciclaje);
                datos.agregarParametro("@Nombre", puntoReciclaje.Nombre);
                datos.agregarParametro("@Direccion", puntoReciclaje.Direccion);
                datos.agregarParametro("@HoraApertura", puntoReciclaje.HoraApertura);
                datos.agregarParametro("@HoraCierre", puntoReciclaje.HoraCierre);
                datos.agregarParametro("@Telefono", puntoReciclaje.Telefono);
                datos.agregarParametro("@Email", puntoReciclaje.Email);
                datos.agregarParametro("@Provincia", puntoReciclaje.Provincia);
                datos.agregarParametro("@Municipio", puntoReciclaje.Municipio);
                datos.agregarParametro("@Localidad", puntoReciclaje.Localidad);
                datos.agregarParametro("@CodigoPostal", puntoReciclaje.CodigoPostal);
                //datos.agregarParametro("@Tipo", puntoReciclaje.Tipo);
                //datos.agregarParametro("@Descripcion", puntoReciclaje.Descripcion);
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

        public PuntosReciclaje ObtenerPorId(int idPuntoReciclaje, int estado = 0)
        {
            PuntosReciclaje punto = null;
            TipoReciclajeNegocio tipoReciclajeNegocio = new TipoReciclajeNegocio();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Configurar el procedimiento almacenado
                datos.setearProcedimiento("sp_PuntoReciclaje_por_Id");
                datos.setearParametro("@IdPuntoReciclaje", idPuntoReciclaje);
                datos.setearParametro("@Estado", estado);


                datos.ejecutarLectura();

                // Leer el resultado
                if (datos.Lector.Read())
                {
                    punto = new PuntosReciclaje
                    {
                        IdPuntoReciclaje = (int)datos.Lector["IdPuntoReciclaje"],
                        Usuario = new Usuario
                        {
                            idUsuario = (int)datos.Lector["IdUsuario"],
                            Nombre = (string)datos.Lector["NombreUsuario"],
                            Apellido = (string)datos.Lector["ApellidoUsuario"],
                            Email = (string)datos.Lector["EmailUsuario"],
                        },
                        Nombre = (string)datos.Lector["Nombre"],
                        Direccion = (string)datos.Lector["Direccion"],
                        CodigoPostal = datos.Lector["CodigoPostal"].ToString(),
                        Email = (string)datos.Lector["Email"],
                        HoraApertura = ((TimeSpan)datos.Lector["HoraApertura"]).ToString(@"hh\:mm"),
                        HoraCierre = ((TimeSpan)datos.Lector["HoraCierre"]).ToString(@"hh\:mm"),
                        Telefono = (string)datos.Lector["Telefono"],
                        Provincia = (string)datos.Lector["Provincia"],
                        Municipio = (string)datos.Lector["Municipio"],
                        Localidad = (string)datos.Lector["Localidad"],
                        Imagenes = new List<string>(),
                        TipoReciclaje = new List<string>()
                    };

                    if (!(datos.Lector["NombreImagen"] is DBNull))
                    {
                        string imagen = (string)datos.Lector["NombreImagen"];
                        punto.Imagenes.Add(imagen);
                    }
                    punto.TipoReciclaje = tipoReciclajeNegocio.ListarPorId(idPuntoReciclaje);
                }

                return punto;
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

        public void Aprobar(int id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearProcedimiento("sp_AprobarPuntoReciclaje");
                accesoDatos.agregarParametro("@IdPuntoReciclaje", id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }
    }
}



