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

                CargarMateriales();
            }


            if (Request.QueryString["IdPR"] != null && !IsPostBack)
            {
                PuntosReciclajeNegocio pReciclajeNegocio = new PuntosReciclajeNegocio();
                PuntosReciclaje pReciclaje = new PuntosReciclaje();
                int estadoInt = 0;
                if (Session["estado"] != null)
                {
                    var estado = Session["estado"].ToString();
                    if (!string.IsNullOrEmpty(estado) && bool.TryParse(estado, out bool estadoBool))
                    {
                        estadoInt = estadoBool ? 1 : 0; // true -> 1, false -> 0
                        Session.Remove("estado");
                    }
                    else
                    {

                        Session.Remove("estado");
                    }
                }
                pReciclaje = pReciclajeNegocio.ObtenerPorId(int.Parse(Request.QueryString["IdPR"]), estadoInt);
                txtNombre.Text = pReciclaje.Nombre;
                txtDireccion.Text = pReciclaje.Direccion;
                txtCP.Text = pReciclaje.CodigoPostal;
                txtHoraApertura.Text = pReciclaje.HoraApertura;
                txtHoraCierre.Text = pReciclaje.HoraCierre;
                txtTelefono.Text = pReciclaje.Telefono;
                txtEmail.Text = pReciclaje.Email;
                ddlProvincias.Items.Insert(0, pReciclaje.Provincia.ToString());
                ddlMunicipios.Items.Insert(0, new ListItem(pReciclaje.Municipio.ToString(), "0"));
                ddlLocalidad.Items.Insert(0, pReciclaje.Localidad.ToString());
                foreach (var item in pReciclaje.TipoReciclaje)
                {
                    foreach (ListItem listItem in ddlMateriales.Items)
                    {
                        if (listItem.Text == item.ToString())
                        {
                            listItem.Selected = true;
                        }
                    }
                }

            }
        }

        private void CargarMateriales()
        {
            TipoReciclajeNegocio tipoReciclajeNegocio = new TipoReciclajeNegocio();
            List<TipoReciclaje> materiales = tipoReciclajeNegocio.Listar();

            ddlMateriales.DataSource = materiales;
            ddlMateriales.DataTextField = "NombreTipo";
            ddlMateriales.DataValueField = "IdTipo";
            ddlMateriales.DataBind();
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
            if (ValidarCampos())
            {
                RegistrarPuntoReciclaje();
                Response.Redirect("ConfirmacionRegistroPunto.aspx");

            }
        }

        private void RegistrarPuntoReciclaje()
        {
            AccesoDatos datos = new AccesoDatos();
            PuntosReciclajeNegocio pReciclajeNegocio = new PuntosReciclajeNegocio();
            PuntosReciclaje pReciclaje = new PuntosReciclaje();
            ImagenesNegocio imagenesNegocio = new ImagenesNegocio();
            TipoReciclajeNegocio tipoReciclajeNegocio = new TipoReciclajeNegocio();


            try
            {
                var usuarioLogueado = (Usuario)Session["Usuario"];
                if (usuarioLogueado == null)
                {
                    throw new Exception("El usuario no está logueado.");
                }

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
                pReciclaje.Localidad = ddlLocalidad.SelectedItem.Text;
                pReciclaje.Usuario = new Usuario { idUsuario = usuarioLogueado.idUsuario };
                pReciclaje.Estado = "Activo";

                // Guardar el punto de reciclaje
                pReciclaje.IdPuntoReciclaje = pReciclajeNegocio.agregar(pReciclaje);

                // Manejo de imágenes
                int Id = imagenesNegocio.obtenerUltimoIdImg();
                if (fileUploadImagenes.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in fileUploadImagenes.PostedFiles)
                    {
                        string nombreArchivo = $"pReciclaje-{Id}-PR-{pReciclaje.IdPuntoReciclaje}.jpg";
                        string rutaArchivo = Server.MapPath("~/img/imgPuntosReciclaje/");
                        uploadedFile.SaveAs(Path.Combine(rutaArchivo, nombreArchivo));
                        Id = imagenesNegocio.GuardarRutaImagenes(pReciclaje.IdPuntoReciclaje, rutaArchivo, nombreArchivo);
                    }
                }
                //obtener tipo de reciclaje
                foreach (ListItem item in ddlMateriales.Items)
                {
                    if (item.Selected)
                    {
                        tipoReciclajeNegocio.GuardarTipoReciclaje(pReciclaje.IdPuntoReciclaje, int.Parse(item.Value));
                    }
                }






                LimpiarCampos();
                MostrarMensaje("Registro exitoso.", true);

                Response.Redirect("Default.aspx", false);
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

                var listaProvincias = ((IEnumerable<dynamic>)provincias.provincias)
                    .OrderBy(p => (string)p.nombre) // Acceso seguro a la propiedad dinámica
                    .ToList();

                ddlProvincias.DataSource = listaProvincias;
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

                    // Ordenar y convertir a lista
                    var listaMunicipios = ((IEnumerable<dynamic>)municipios.municipios)
                        .Select(m => new { id = (string)m.id, nombre = ((string)m.nombre).Trim() })
                        .OrderBy(m => m.nombre, StringComparer.OrdinalIgnoreCase)
                        .ToList();

                    // Cargar en el DropDownList
                    ddlMunicipios.Items.Clear();
                    ddlMunicipios.DataSource = listaMunicipios;
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
        protected async void ddlMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string municipioId = ddlMunicipios.SelectedValue;

                if (!string.IsNullOrEmpty(municipioId) && municipioId != "0")
                {
                    string url = $"https://apis.datos.gob.ar/georef/api/localidades?max=200&municipio={municipioId}";
                    string response = await ApiClient.GetAsync(url);

                    dynamic localidades = JsonConvert.DeserializeObject(response);

                    // Ordenar y convertir a lista
                    var listaLocalidades = ((IEnumerable<dynamic>)localidades.localidades)
                        .Select(l => new { id = (string)l.id, nombre = ((string)l.nombre).Trim() })
                        .OrderBy(l => l.nombre, StringComparer.OrdinalIgnoreCase)
                        .ToList();

                    // Cargar en el DropDownList
                    ddlLocalidad.Items.Clear();
                    ddlLocalidad.DataSource = listaLocalidades;
                    ddlLocalidad.DataTextField = "nombre";
                    ddlLocalidad.DataValueField = "id";
                    ddlLocalidad.DataBind();
                    ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione Localidad --", "0"));
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar localidades: {ex.Message}", false);
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
                pReciclaje.Localidad = ddlLocalidad.SelectedItem.Text;
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
            string tipoClase = exito ? "alert-success" : "alert-danger"; // Success or error class
            string icono = exito ? "✔️" : "❌"; // Icon based on success or error

            string script = $@"
        var mensajeDiv = document.createElement('div');
        mensajeDiv.className = 'alert {tipoClase} alert-dismissible fade show';
        mensajeDiv.role = 'alert';
        mensajeDiv.innerHTML = '{icono} {mensaje}';
        var closeButton = document.createElement('button');
        closeButton.className = 'btn-close';
        closeButton.setAttribute('data-bs-dismiss', 'alert');
        closeButton.setAttribute('aria-label', 'Close');
        mensajeDiv.appendChild(closeButton);
        document.body.appendChild(mensajeDiv);
    ";

            ClientScript.RegisterStartupScript(this.GetType(), exito ? "successMessage" : "errorMessage", script, true);
        }


    }
}



