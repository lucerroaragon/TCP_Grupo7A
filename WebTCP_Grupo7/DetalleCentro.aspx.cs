using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTCP_Grupo7
{
    public partial class DetalleCentro : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string idPuntoReciclaje = Request.QueryString["IdPR"];
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(idPuntoReciclaje) && int.TryParse(idPuntoReciclaje, out int id))
                {
                    CargarCentroReciclaje(id);
                    LoadComments();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "logError", "console.log('No se proporcionó un ID válido en la URL.');", true);
                }
            }

            // Cargar el carrusel siempre
            cargarCarruselDetalle();
        }

        private void CargarCentroReciclaje(int idPuntoReciclaje)
        {
            PuntosReciclajeNegocio negocio = new PuntosReciclajeNegocio();
            PuntosReciclaje centro;

            // Obtener estado desde la sesión
            if (Session["estado"] != null)
            {
                var estado = Session["estado"].ToString();
                if (!string.IsNullOrEmpty(estado) && bool.TryParse(estado, out bool estadoBool))
                {
                    int estadoInt = estadoBool ? 1 : 0; // true -> 1, false -> 0
                    centro = negocio.ObtenerPorId(idPuntoReciclaje, estadoInt);
                    Session.Remove("estado");
                }
                else
                {
                    centro = negocio.ObtenerPorId(idPuntoReciclaje, 0);
                }
            }
            else
            {
                centro = negocio.ObtenerPorId(idPuntoReciclaje, 1);
            }

            // Configurar datos del centro en la interfaz
            ConfigurarDatosCentro(centro);
        }

        private void cargarCarruselDetalle()
        {
            // Instanciamos la clase de negocio
            PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();
            List<PuntosReciclaje> puntosReciclajes = new List<PuntosReciclaje>();
            string idArticulo = Request.QueryString["IdPR"];
            if(Session["estado"] != null)
            {
                var estado = Session["estado"].ToString();
                if (!string.IsNullOrEmpty(estado) && bool.TryParse(estado, out bool estadoBool))
                {

                    string estadoInt = estadoBool ? "1" : "0"; // true -> 1, false -> 0
                    puntosReciclajes = puntosReciclajeNegocio.listarTodos(estadoInt);
                    Session.Remove("estado");
                }
            }
            else
            {
                puntosReciclajes = puntosReciclajeNegocio.listarTodos();
             }


            // Asegúrate de que idArticulo sea válido antes de continuar
            if (string.IsNullOrEmpty(idArticulo)) return;

            foreach (var puntosReciclaje in puntosReciclajes)
            {
                // Filtra por el IdPuntoReciclaje
                if (puntosReciclaje.IdPuntoReciclaje == int.Parse(idArticulo))
                {
                    // ID único para el carrusel
                    string carouselId = $"carousel_{puntosReciclaje.IdPuntoReciclaje}";

                    // Iniciamos el HTML para el carrusel
                    string carouselHtml = $@"
                <div id='{carouselId}' class='carousel slide' data-bs-ride='carousel'>
                    <div class='carousel-inner'>";

                    // Si no hay imágenes, mostrar una imagen predeterminada
                    if (puntosReciclaje.Imagenes == null || puntosReciclaje.Imagenes.Count == 0)
                    {
                        string defaultImageUrl = ResolveUrl("~/img/imgPuntosReciclaje/default-image.jpg");
                        carouselHtml += $@"
                    <div class='carousel-item active'>
                        <img src='{defaultImageUrl}' class='d-block w-100' style='height: 500px; object-fit: cover;' alt='Imagen predeterminada'>
                    </div>";
                    }
                    else
                    {
                        // Generar los items del carrusel con las imágenes del punto de reciclaje
                        for (int i = 0; i < puntosReciclaje.Imagenes.Count; i++)
                        {
                            string imagenUrl = ResolveUrl("~/img/imgPuntosReciclaje/" + puntosReciclaje.Imagenes[i]);
                            string activeClass = i == 0 ? "active" : "";

                            carouselHtml += $@"
                        <div class='carousel-item {activeClass}'>
                            <img src='{imagenUrl}' class='d-block w-100' style='height: 500px; object-fit: contain;' alt='{puntosReciclaje.Nombre}'>
                        </div>";
                        }
                    }

                    carouselHtml += @"
                    </div>
                    <button class='carousel-control-prev' type='button' data-bs-target='#" + carouselId + @"' data-bs-slide='prev'>
                        <span class='carousel-control-prev-icon' aria-hidden='true'></span>
                        <span class='visually-hidden'>Previous</span>
                    </button>
                    <button class='carousel-control-next' type='button' data-bs-target='#" + carouselId + @"' data-bs-slide='next'>
                        <span class='carousel-control-next-icon' aria-hidden='true'></span>
                        <span class='visually-hidden'>Next</span>
                    </button>
                </div>"; // Fin del carrusel

                    // Construir la tarjeta con el carrusel dentro
                    string cardHtml = $@"
                    <div class='container my-5'>                       
                        <div class='row justify-content-center'>
                            <div class='col-md-10'>
                                <div class='card w-100'>
                                    <!-- Card Header -->
                                    <div class='card-header'>
                                        <h5 class='card-title'>Galería de {puntosReciclaje.Nombre}</h5>
                                    </div>
                                    <!-- Carousel -->
                                    <div class='card-body'>
                                        {carouselHtml}
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>";

                    // Agregar el HTML generado al contenedor
                    PuntoReciclajeContainer.Controls.Add(new LiteralControl(cardHtml));
                    break; // Salir del bucle después de encontrar el punto de reciclaje
                }
            }
        }

        private void ConfigurarDatosCentro(PuntosReciclaje centro)
        {
            if (centro == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "logError", "console.log('No se encontró información para el centro de reciclaje.');", true);
                return;
            }

            // Configuración de datos básicos
            centerName.InnerHtml = !string.IsNullOrEmpty(centro.Nombre)
                ? System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(centro.Nombre.ToLower())
                : "";

            centerAddress.InnerHtml = $"{centro.Direccion}, {centro.Municipio}, {centro.Provincia}";
            centerPhone.InnerHtml = centro.Telefono;
            centerHours.InnerHtml = $"Desde las {centro.HoraApertura} hasta {centro.HoraCierre}";
            centerDescription.InnerHtml = !string.IsNullOrEmpty(centro.Descripcion)
                ? centro.Descripcion
                : "La descripción del centro no ha sido proporcionada.";
            centerInfo.InnerHtml = $"{centro.Usuario.Nombre} {centro.Usuario.Apellido}";

            // Generar iframe del mapa
            string iframeMap = GenerarIframeMapa(centro);
            centerMap.Text = iframeMap;

            // Log de datos
            string script = $@"
        console.log('ID del artículo: {centro.IdPuntoReciclaje}');
        console.log('Nombre: {centro.Nombre}');
        console.log('Dirección: {centro.Direccion}');
        console.log('Teléfono: {centro.Telefono}');";
            ClientScript.RegisterStartupScript(this.GetType(), "logDatosCentro", script, true);
        }

        public string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private string GenerarIframeMapa(PuntosReciclaje centro)
        {
            // Construir dirección completa
            string direccionCompleta = $"{centro.Direccion}, {centro.Municipio}, {centro.Provincia}";
            string direccionCodificada = HttpUtility.UrlEncode(direccionCompleta);

            // Obtener la clave de API desde una configuración o variable de entorno
            string googleMapsApiKey = System.Configuration.ConfigurationManager.AppSettings["GoogleMapsApiKey"];
            if (string.IsNullOrEmpty(googleMapsApiKey))
            {
                throw new Exception("La clave de API de Google Maps no está configurada.");
            }

            // Generar el iframe de Google Maps
            return $@"
        <iframe 
            width='515' 
            height='450' 
            style='border: 1px solid #000000; border-radius: 10px;' 
            loading='lazy' 
            allowfullscreen 
            src='https://www.google.com/maps/embed/v1/place?key={googleMapsApiKey}&q={direccionCodificada}'>
        </iframe>";
        }

        private void LoadComments()
        {
            try
            {
                ComentariosNegocio comentariosNegocio = new ComentariosNegocio();

               
                var usuario = (Usuario)Session["Usuario"];
                bool esAdministrador = usuario != null && usuario.Administrador == 1;

                
                if (string.IsNullOrEmpty(Request.QueryString["IdPR"]) || !int.TryParse(Request.QueryString["IdPR"], out int idPuntoReciclaje))
                {
                    lblMessage.Text = "No se pudo identificar el punto de reciclaje.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                List<Comentarios> comentarios = comentariosNegocio.ListarComentariosPorPunto(idPuntoReciclaje);

                
                if (comentarios == null || comentarios.Count == 0)
                {
                    lblMessage.Text = "No se encontraron comentarios para este punto de reciclaje.";
                    lblMessage.ForeColor = System.Drawing.Color.Orange;
                    return;
                }

                rptComments.DataSource = comentarios;
                rptComments.DataBind();

               
                if (esAdministrador)
                {
                    foreach (RepeaterItem item in rptComments.Items)
                    {
                        Button btnDeleteComment = (Button)item.FindControl("btnDeleteComment");
                        if (btnDeleteComment != null)
                        {
                            btnDeleteComment.Visible = true; 
                        }
                    }
                }
                else
                {
                
                    foreach (RepeaterItem item in rptComments.Items)
                    {
                        Button btnDeleteComment = (Button)item.FindControl("btnDeleteComment");
                        if (btnDeleteComment != null)
                        {
                            btnDeleteComment.Visible = false; 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = $"Error al cargar los comentarios: {ex.Message}";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void MostrarMensaje(string mensaje, string tipoAlerta)
        {
            lblMessage.Text = mensaje;
            lblMessage.CssClass = $"alert {tipoAlerta} shadow"; // Aplica las clases de Bootstrap
            lblMessage.Visible = true;

            // Inyectar script para ocultar el mensaje después de 3 segundos
            ScriptManager.RegisterStartupScript(this, GetType(), "HideSuccessMessage", "hideSuccessMessage();", true);
        }

        protected void btnSubmitComment_Click(object sender, EventArgs e)
        {
            ComentariosNegocio comentariosNegocio = new ComentariosNegocio();
            Comentarios comentarios = new Comentarios();
            var usuario = (Usuario)Session["Usuario"];





            try
            {
                // Verificar si el usuario ha iniciado sesión
                if (usuario == null || string.IsNullOrWhiteSpace(usuario.idUsuario.ToString()))
                {
                    MostrarMensaje("Debe iniciar sesión o registrarse para poder comentar.", "alert-warning");
                    return;
                }

                // Validar si el parámetro "IdPR" está presente y es válido
                if (string.IsNullOrEmpty(Request.QueryString["IdPR"]) || !int.TryParse(Request.QueryString["IdPR"], out int idPuntoReciclaje))
                {
                    MostrarMensaje("No se pudo identificar el punto de reciclaje. Por favor, intente nuevamente.", "alert-danger");
                    return;
                }

                // Validar que el comentario no esté vacío
                if (string.IsNullOrWhiteSpace(txtComment.Text))
                {
                    MostrarMensaje("El comentario no puede estar vacío.", "alert-danger");
                    return;
                }

                // Asignar valores al objeto de comentarios
                comentarios.IdPuntoReciclaje = idPuntoReciclaje;
                comentarios.IdUsuario = usuario.idUsuario;
                comentarios.Comentario = txtComment.Text.Trim();
                comentarios.FechaCometario = DateTime.Now;


                // Guardar el comentario en la base de datos
                comentariosNegocio.Agregar(comentarios);

                // Borrar el contenido del formulario
                txtComment.Text = string.Empty;

                // Mostrar mensaje de éxito
                MostrarMensaje("¡Comentario enviado exitosamente!", "alert-success");

                // Recargar los comentarios
                LoadComments();
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrar mensaje al usuario
                MostrarMensaje($"Ocurrió un error al enviar el comentario: {ex.Message}", "alert-danger");
            }
        }







    }
}