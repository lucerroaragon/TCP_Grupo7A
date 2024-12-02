using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace WebTCP_Grupo7
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPuntos();


            }
        }
        private void CargarPuntos()
        {
            PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();
            List<PuntosReciclaje> puntosReciclajes = puntosReciclajeNegocio.listarTodos();



            foreach (var puntosReciclaje in puntosReciclajes)
            {
                DropDownList2.Items.Clear();

                DropDownList2.Items.Add(new ListItem("_", default));
                DropDownList2.Items.Add(new ListItem(puntosReciclaje.Provincia));
                DropDownList3.Items.Add(new ListItem(puntosReciclaje.Municipio));
                DropDownList4.Items.Add(new ListItem(puntosReciclaje.Localidad));


                string carouselId = $"carousel_{puntosReciclaje.IdPuntoReciclaje}";
                string carouselHtml = $@"
                <div id='{carouselId}' class='carousel slide' data-bs-ride='carousel'>
                <div class='carousel-inner'>";

                // Verifica si el punto tiene imágenes; si no, usa una imagen predeterminada
                if (puntosReciclaje.Imagenes == null || puntosReciclaje.Imagenes.Count == 0)
                {
                    // Imagen predeterminada
                    string defaultImageUrl = ResolveUrl("~/img/imgPuntosReciclaje/default-image.jpg");
                    carouselHtml += $@"
                    <div class='carousel-item active'>
                        <img src='{defaultImageUrl}' class='d-block w-100 img-custom' style='height: 300px; object-fit: cover;' alt='Imagen predeterminada'>
                    </div>";
                }
                else
                {
                    // Genera el carrusel con las imágenes del punto de reciclaje
                    for (int i = 0; i < puntosReciclaje.Imagenes.Count; i++)
                    {
                        string imagenUrl = ResolveUrl("~/img/imgPuntosReciclaje/" + puntosReciclaje.Imagenes[i]);
                        string activeClass = i == 0 ? "active" : "";

                        carouselHtml += $@"
                        <div class='carousel-item {activeClass}'>
                            <img src='{imagenUrl}' class='d-block w-100 img-custom' style='height: 300px; object-fit: cover;' alt='{puntosReciclaje.Nombre}'>
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
                </div>";

                // Card HTML con el carrusel
                string cardHtml = $@"
                <div class='col-md-3 mb-3 mt-3'>
                    <div class='card h-100' style='max-width: 18rem;'>
                        {carouselHtml}
                        <div class='card-body'>
                            <h6 class='card-title'>{puntosReciclaje.Nombre}</h6>
                            <p class='card-text' style='font-size: 0.9rem;'>{puntosReciclaje.Descripcion}</p>
                            <a href='Detallecentro.aspx?IdPR={puntosReciclaje.IdPuntoReciclaje}' class='btn btn-primary btn-sm'>+ Detalles</a>
                        </div>
                    </div>
                </div>";


                PuntoReciclajeContainer.Controls.Add(new LiteralControl(cardHtml));
            }
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {


            // Obtener los valores de los filtros
            string localidadSeleccionada = DropDownList4.SelectedValue;
            string provinciaSeleccionada = DropDownList2.SelectedValue;
            string municipioSeleccionado = DropDownList3.SelectedValue;

            PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();
            List<PuntosReciclaje> puntosFiltrados = ObtenerPuntosFiltrados(localidadSeleccionada, provinciaSeleccionada, municipioSeleccionado);

            // Limpiar el contenedor antes de añadir los nuevos puntos
            PuntoReciclajeContainer.Controls.Clear();

            // Agregar los puntos filtrados al contenedor
            foreach (var punto in puntosFiltrados)
            {
                string carouselId = $"carousel_{punto.IdPuntoReciclaje}";
                string carouselHtml = $@"
                <div id='{carouselId}' class='carousel slide' data-bs-ride='carousel'>
                <div class='carousel-inner'>";

                // Verifica si el punto tiene imágenes; si no, usa una imagen predeterminada
                if (punto.Imagenes == null || punto.Imagenes.Count == 0)
                {
                    string defaultImageUrl = ResolveUrl("~/img/imgPuntosReciclaje/default-image.jpg");
                    carouselHtml += $@"
                    <div class='carousel-item active'>
                        <img src='{defaultImageUrl}' class='d-block w-100 img-custom' style='height: 300px; object-fit: cover;' alt='Imagen predeterminada'>
                    </div>";
                }
                else
                {
                    for (int i = 0; i < punto.Imagenes.Count; i++)
                    {
                        string imagenUrl = ResolveUrl("~/img/imgPuntosReciclaje/" + punto.Imagenes[i]);
                        string activeClass = i == 0 ? "active" : "";

                        carouselHtml += $@"
                        <div class='carousel-item {activeClass}'>
                            <img src='{imagenUrl}' class='d-block w-100 img-custom' style='height: 300px; object-fit: cover;' alt='{punto.Nombre}'>
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
                </div>";

                // Card HTML con el carrusel
                string cardHtml = $@"
                <div class='col-md-3 mb-3 mt-3'>
                    <div class='card h-100' style='max-width: 18rem;'>
                        {carouselHtml}
                        <div class='card-body'>
                            <h6 class='card-title'>{punto.Nombre}</h6>
                            <p class='card-text' style='font-size: 0.9rem;'>{punto.Descripcion}</p>
                            <a href='Detallecentro.aspx?IdPR={punto.IdPuntoReciclaje}' class='btn btn-primary btn-sm'>+ Detalles</a>
                        </div>
                    </div>
                </div>";

                PuntoReciclajeContainer.Controls.Add(new LiteralControl(cardHtml));
            }
        }

        
        private List<PuntosReciclaje> ObtenerPuntosFiltrados(string localidad, string provincia, string municipio)
        {
            List<PuntosReciclaje> puntosFiltrados = new List<PuntosReciclaje>();
            PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();
            var todosPuntos = puntosReciclajeNegocio.listarTodos();

            // Filtrar los puntos según las condiciones
            foreach (var punto in todosPuntos)
            {
                // Filtro individual o combinado
                bool coincideLocalidad = localidad == "Todos" || punto.Localidad == localidad;
                bool coincideProvincia = provincia == "Todas" || punto.Provincia == provincia;
                bool coincideMunicipio = municipio == "Todos" || punto.Municipio == municipio;

                // Si coincide cualquiera de los criterios, añadir al resultado
                if (coincideLocalidad ||
                  coincideProvincia || coincideMunicipio)
                {
                    puntosFiltrados.Add(punto);
                }
            }

            return puntosFiltrados;
        }

    }

    }