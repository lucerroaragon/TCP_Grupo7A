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
                ClientScript.RegisterStartupScript(this.GetType(), "autoFocusNombre",
                    $"document.getElementById('{txtNombre.ClientID}').focus();", true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            // Botón sin funcionalidad asignada
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                RegistrarPuntoReciclaje();
            }
        }

        private void RegistrarPuntoReciclaje()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                PuntosReciclajeNegocio pReciclajeNegocio = new PuntosReciclajeNegocio();
                PuntosReciclaje pReciclaje = new PuntosReciclaje();
                ImagenesNegocio imagenesNegocio = new ImagenesNegocio();

                // Asignación de valores
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

                // Guardar el punto de reciclaje
                pReciclaje.IdPuntoReciclaje = pReciclajeNegocio.agregar(pReciclaje);

                // Manejo de imágenes
                int IdImg = imagenesNegocio.obtenerUltimoIdImg();
                if (fileUploadImagenes.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in fileUploadImagenes.PostedFiles)
                    {
                        string nombreArchivo = $"pReciclaje-{IdImg}-PR-{pReciclaje.IdPuntoReciclaje}.jpg";
                        string rutaArchivo = Server.MapPath("~/img/imgPuntosReciclaje/");
                        uploadedFile.SaveAs(Path.Combine(rutaArchivo, nombreArchivo));
                        IdImg = imagenesNegocio.GuardarRutaImagenes(pReciclaje.IdPuntoReciclaje, rutaArchivo, nombreArchivo);
                    }
                }

                LimpiarCampos();
                MostrarMensaje("Registro exitoso.", true);
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Ocurrió un error: {ex.Message}", false);
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

                dynamic provincias = JsonConvert.DeserializeObject(response);

                ddlProvincias.DataSource = provincias.provincias;
                ddlProvincias.DataTextField = "nombre";
                ddlProvincias.DataValueField = "id";
                ddlProvincias.DataBind();

                ddlProvincias.Items.Insert(0, new ListItem("-- Seleccione Provincia --", "0"));
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar provincias: {ex.Message}", false);
            }
        }

        protected async void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string provinciaId = ddlProvincias.SelectedValue;

                if (!string.IsNullOrEmpty(provinciaId) && provinciaId != "0")
                {
                    string url = $"https://apis.datos.gob.ar/georef/api/municipios?max=200&provincia={provinciaId}";
                    string response = await ApiClient.GetAsync(url);

                    dynamic municipios = JsonConvert.DeserializeObject(response);

                    ddlMunicipios.DataSource = municipios.municipios;
                    ddlMunicipios.DataTextField = "nombre";
                    ddlMunicipios.DataValueField = "id";
                    ddlMunicipios.DataBind();

                    ddlMunicipios.Items.Insert(0, new ListItem("-- Seleccione Municipio --", "0"));
                    ClientScript.RegisterStartupScript(this.GetType(), "autoFocusMunicipio",
                        $"document.getElementById('{ddlMunicipios.ClientID}').focus();", true);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar municipios: {ex.Message}", false);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || ddlProvincias.SelectedValue == "0" || ddlMunicipios.SelectedValue == "0")
            {
                MostrarMensaje("Por favor complete todos los campos obligatorios.", false);
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCP.Text = string.Empty;
            txtHoraApertura.Text = string.Empty;
            txtHoraCierre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            ddlProvincias.SelectedIndex = 0;
            ddlMunicipios.Items.Clear();
        }

        private void MostrarMensaje(string mensaje, bool exito)
        {
            string script = $"alert('{mensaje}');";
            ClientScript.RegisterStartupScript(this.GetType(), exito ? "successMessage" : "errorMessage", script, true);
        }
    }
}
