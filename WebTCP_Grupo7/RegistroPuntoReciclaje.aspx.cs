using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTCP_Grupo7
{
    public partial class RegistroPuntoReciclaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                PuntosReciclajeNegocio pReciclajeNegocio = new PuntosReciclajeNegocio();
                PuntosReciclaje pReciclaje = new PuntosReciclaje();
                ImagenesNegocio imagenesNegocio = new ImagenesNegocio();

                pReciclaje.Nombre = txtNombre.Text;
                pReciclaje.Direccion = txtDireccion.Text;
                pReciclaje.CodigoPostal = txtCP.Text;
                pReciclaje.HoraApertura = txtHoraApertura.Text;
                pReciclaje.HoraCierre = txtHoraCierre.Text;
                pReciclaje.Telefono = txtTelefono.Text;
                pReciclaje.FechaAlta = DateTime.Now;
                pReciclaje.Email = txtEmail.Text;

                pReciclaje.IdPuntoReciclaje = pReciclajeNegocio.agregar(pReciclaje);

                int IdImg = imagenesNegocio.obtenerUltimoIdImg();
                if (fileUploadImagenes.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in fileUploadImagenes.PostedFiles)
                    {
                        string nombreArchivo = Path.GetFileName("pReciclaje-" + IdImg + "-PR-" + pReciclaje.IdPuntoReciclaje + ".jpg");
                        string rutaArchivo = Server.MapPath("~/img/imgPuntosReciclaje/");
                        //(uploadedFile.FileName);

                        //txtImgenes.
                        //    (rutaArchivo + "pReciclaje-" + pReciclaje.IdPuntoReciclaje + ".jpg");

                        // Guardar el archivo en el servidor

                        //string directoryPath = Path.GetDirectoryName(rutaArchivo);
                        //if (!Directory.Exists(directoryPath))
                        //{
                        //    Directory.CreateDirectory(directoryPath);
                        //}
                        uploadedFile.SaveAs(Path.Combine(rutaArchivo, nombreArchivo));

                        // Guardar la ruta en la base de datos
                        IdImg = imagenesNegocio.GuardarRutaImagenes(pReciclaje.IdPuntoReciclaje, rutaArchivo, nombreArchivo);
                    }
                }
                Response.Redirect("Default.aspx", false);
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