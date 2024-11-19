using Dominio;
using Negocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebTCP_Grupo7
{
    public partial class RegistroPuntoReciclaje : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadProvincias();
                ClientScript.RegisterStartupScript(this.GetType(), "autoFocusMunicipio",
                 "document.getElementById('" + txtNombre + "').focus();", true);

            }
            if (Request.QueryString["IdPR"] != null)
            {
                PuntosReciclajeNegocio pReciclajeNegocio = new PuntosReciclajeNegocio();
                PuntosReciclaje pReciclaje = new PuntosReciclaje();
                pReciclaje = pReciclajeNegocio.ObtenerPorId(int.Parse(Request.QueryString["IdPR"]));
                txtNombre.Text = pReciclaje.Nombre;
                txtDireccion.Text = pReciclaje.Direccion;
                txtCP.Text = pReciclaje.CodigoPostal;
                txtHoraApertura.Text = pReciclaje.HoraApertura;
                txtHoraCierre.Text = pReciclaje.HoraCierre;
                txtTelefono.Text = pReciclaje.Telefono;
                txtEmail.Text = pReciclaje.Email;
                ddlProvincias.SelectedValue = pReciclaje.Provincia.ToString();
                ddlMunicipios.SelectedValue = pReciclaje.Municipio.ToString();
            }
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
            PuntosReciclajeNegocio pReciclajeNegocio = new PuntosReciclajeNegocio();
            PuntosReciclaje pReciclaje = new PuntosReciclaje();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            try
            {
                pReciclaje.Nombre = txtNombre.Text;
                pReciclaje.Direccion = txtDireccion.Text;
                pReciclaje.CodigoPostal = txtCP.Text;
                pReciclaje.HoraApertura = txtHoraApertura.Text;
                pReciclaje.HoraCierre = txtHoraCierre.Text;
                pReciclaje.Telefono = txtTelefono.Text;
                pReciclaje.FechaAlta = DateTime.Now;
                pReciclaje.Email = txtEmail.Text;
                pReciclaje.Provincia = ddlProvincias.SelectedItem.Text;
                pReciclaje.Municipio = ddlMunicipios.SelectedItem.Text;
                pReciclaje.IdPuntoReciclaje = pReciclajeNegocio.agregar(pReciclaje);

                int IdImg = imagenesNegocio.obtenerUltimoIdImg();
                if (fileUploadImagenes.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in fileUploadImagenes.PostedFiles)
                    {
                        string nombreArchivo = Path.GetFileName("pReciclaje-" + IdImg + "-PR-" + pReciclaje.IdPuntoReciclaje + ".jpg");
                        string rutaArchivo = Server.MapPath("~/img/imgPuntosReciclaje/");
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


        private async Task LoadProvincias()
        {
            try
            {

                string url = "https://apis.datos.gob.ar/georef/api/provincias";

                string response = await ApiClient.GetAsync(url);


                ClientScript.RegisterStartupScript(this.GetType(), "log", $"console.log({JsonConvert.SerializeObject(response)});", true);


                dynamic provincias = JsonConvert.DeserializeObject(response);


                ddlProvincias.DataSource = provincias.provincias;
                ddlProvincias.DataTextField = "nombre";  // El campo que quieres mostrar
                ddlProvincias.DataValueField = "id";    // El campo que quieres usar como valor
                ddlProvincias.DataBind();

                // Agregar una opción inicial
                ddlProvincias.Items.Insert(0, new ListItem("-- Seleccione Provincia --", "0"));
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "log", $"console.log('Error: {ex.Message}');", true);

            }
        }


        protected async void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string provinciaId = ddlProvincias.SelectedValue;

                // Solo cargar municipios si se selecciona una provincia válida
                if (!string.IsNullOrEmpty(provinciaId) && provinciaId != "0")
                {
                    string url = $"https://apis.datos.gob.ar/georef/api/municipios?max=200&provincia={provinciaId}";  // URL con parámetro para obtener municipios
                    string response = await ApiClient.GetAsync(url);

                    dynamic municipios = JsonConvert.DeserializeObject(response);

                    // Llenar el DropDownList de municipios
                    ddlMunicipios.DataSource = municipios.municipios;
                    ddlMunicipios.DataTextField = "nombre";  // Nombre del municipio (ajustar según la API)
                    ddlMunicipios.DataValueField = "id";    // ID del municipio
                    ddlMunicipios.DataBind();

                    // Agregar una opción por defecto
                    ddlMunicipios.Items.Insert(0, new ListItem("-- Seleccione Municipio --", "0"));
                    ClientScript.RegisterStartupScript(this.GetType(), "autoFocusMunicipio",
                 "document.getElementById('" + ddlMunicipios.ClientID + "').focus();", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "log", $"console.log('Error: {ex.Message}');", true);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            PuntosReciclajeNegocio pReciclajeNegocio = new PuntosReciclajeNegocio();
            PuntosReciclaje pReciclaje = new PuntosReciclaje();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            try
            {
                pReciclaje.Nombre = txtNombre.Text;
                pReciclaje.Direccion = txtDireccion.Text;
                pReciclaje.CodigoPostal = txtCP.Text;
                pReciclaje.HoraApertura = txtHoraApertura.Text;
                pReciclaje.HoraCierre = txtHoraCierre.Text;
                pReciclaje.Telefono = txtTelefono.Text;
                pReciclaje.Email = txtEmail.Text;
                pReciclaje.Provincia = ddlProvincias.SelectedItem.Text;
                pReciclaje.Municipio = ddlMunicipios.SelectedItem.Text;
                pReciclaje.IdPuntoReciclaje = int.Parse(Request.QueryString["IdPR"]);
                pReciclajeNegocio.modificar(pReciclaje);

                int IdImg = imagenesNegocio.obtenerUltimoIdImg();
                if (fileUploadImagenes.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in fileUploadImagenes.PostedFiles)
                    {
                        string nombreArchivo = Path.GetFileName("pReciclaje-" + IdImg + "-PR-" + pReciclaje.IdPuntoReciclaje + ".jpg");
                        string rutaArchivo = Server.MapPath("~/img/imgPuntosReciclaje/");
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