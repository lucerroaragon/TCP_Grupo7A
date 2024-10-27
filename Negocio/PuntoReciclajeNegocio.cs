using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class PuntoReciclajeNegocio
    {
        public List<PuntosReciclaje> listarTodos()
        {
            //List<PuntosReciclaje> lista = new List<PuntosReciclaje>();
            //AccesoDatos datos = new AccesoDatos();

            //try
            //{
            //    datos.setearProcedimiento("storedListarArticulo");
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
            //    datos.ejecutarLectura();

            //    while (datos.Lector.Read())
            //    {

            //        int idPuntoReciclaje = (int)datos.Lector["idPuntoReciclaje"];

            //        // Busca si ya existe en la lista
            //        PuntosReciclaje aux = lista.FirstOrDefault(a => a.idPuntoReciclaje == idPuntoReciclaje);


            //        if (aux == null)
            //        {
            //            aux = new PuntosReciclaje
            //            {
            //                idPuntoReciclaje = idPuntoReciclaje,
            //                CodArticulo = (string)datos.Lector["Codigo"],
            //                Nombre = (string)datos.Lector["Nombre"],
            //                marca = new Marca
            //                {
            //                    IdMarca = (int)datos.Lector["IdMarca"],
            //                    Nombre = (string)datos.Lector["Marca"]
            //                },
            //                categoria = new Categoria
            //                {
            //                    IdCategoria = (int)datos.Lector["IdCategoria"],
            //                    Nombre = (string)datos.Lector["Categoria"]
            //                },
            //                Precio = (decimal)datos.Lector["Precio"],
            //                Descripcion = (string)datos.Lector["Descripcion"],
            //                imagenes = new List<string>()
            //            };



            //            lista.Add(aux);
            //        }

            //        if (!(datos.Lector["ImagenUrl"] is DBNull))
            //        {
            //            string imageUrl = (string)datos.Lector["ImagenUrl"];
            //            aux.imagenes.Add(imageUrl);
            //        }
            //    }

            //    return lista;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    datos.cerrarConexion();
            //};
            return null;
        }
    }
}
