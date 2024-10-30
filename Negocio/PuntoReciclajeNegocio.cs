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
                datos.setearProcedimiento("storedListarPuntosReciclaje");
                //    /*
                //     * "Stored Procedure"
                //        create procedure storedListarArticulo as
                //        Select A.Id IdArticulo, A.Codigo, A.Nombre, M.Descripcion Marca, M.id IdMarca, C.Descripcion Categoria,
                //        C.Id IdCategoria, A.Precio, A.Descripcion, I.ImagenUrl
                //        from ARTICULOS A
                //        INNER JOIN MARCAS M ON A.IdMarca = M.Id
                //        INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id
                //        LEFT JOIN IMAGENES I ON A.Id = I.IdArticulo
                //    */
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
                            Horario = (string)datos.Lector["Horario"],
                            Telefono = (string)datos.Lector["Telefono"],
                            Imagen = (string)datos.Lector["Imagen"],
                            Latitud = (string)datos.Lector["Latitud"],
                            Longitud = (string)datos.Lector["Longitud"],
                            Tipo = (string)datos.Lector["Tipo"],
                            Descripcion = (string)datos.Lector["Descripcion"],
                            Comentarios = new List<Comentarios>(),
                            Likes = new List<Likes>(),
                            Imagenes = new List<string>()
                        };

                        lista.Add(aux);
                    }

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        string imageUrl = (string)datos.Lector["ImagenUrl"];
                        aux.Imagenes.Add(imageUrl);
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

        public void agregar(PuntosReciclaje puntoReciclaje)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedAgregarPuntoReciclaje");
                datos.agregarParametro("@Nombre", puntoReciclaje.Nombre);
                datos.agregarParametro("@Direccion", puntoReciclaje.Direccion);
                datos.agregarParametro("@Horario", puntoReciclaje.Horario);
                datos.agregarParametro("@Telefono", puntoReciclaje.Telefono);
                datos.agregarParametro("@Imagen", puntoReciclaje.Imagen);
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

        public void modificar(PuntosReciclaje puntoReciclaje)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("storedModificarPuntoReciclaje");
                datos.agregarParametro("@IdPuntoReciclaje", puntoReciclaje.IdPuntoReciclaje);
                datos.agregarParametro("@Nombre", puntoReciclaje.Nombre);
                datos.agregarParametro("@Direccion", puntoReciclaje.Direccion);
                datos.agregarParametro("@Horario", puntoReciclaje.Horario);
                datos.agregarParametro("@Telefono", puntoReciclaje.Telefono);
                datos.agregarParametro("@Imagen", puntoReciclaje.Imagen);
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



  