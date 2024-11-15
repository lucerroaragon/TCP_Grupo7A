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
                            <a href='Detallecentro.aspx?IdArticulo={puntosReciclaje.IdPuntoReciclaje}' class='btn btn-primary btn-sm'>+ Detalles</a>
                        </div>
                    </div>
                </div>";


                PuntoReciclajeContainer.Controls.Add(new LiteralControl(cardHtml));
            }
        }


        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            DropDownList materialSelect = (DropDownList)FindControl("materialSelect");
            DropDownList ciudadSelect = (DropDownList)FindControl("ciudadSelect");
            DropDownList municipioSelect = (DropDownList)FindControl("municipioSelect");
            // Obtener los valores de los filtros
            string materialSeleccionado = materialSelect.SelectedValue;
            string ciudadSeleccionada = ciudadSelect.SelectedValue;
            string municipioSeleccionado = municipioSelect.SelectedValue;
            PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();

            // Llamar a un método que se encargue de obtener los puntos de reciclaje filtrados
            List<PuntosReciclaje> puntosFiltrados = ObtenerPuntosFiltrados(materialSeleccionado, ciudadSeleccionada, municipioSeleccionado);

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
        <div class='col-md-4 mb-4'>
            <div class='card h-100'>
                {carouselHtml}
                <div class='card-body'>
                    <h5 class='card-title'>{punto.Nombre}</h5>
                    <p class='card-text'>{punto.Descripcion}</p>
                    <a href='Detallecentro.aspx?IdArticulo={punto.IdPuntoReciclaje}' class='btn btn-primary btn-flex'>+ Detalles</a>
                </div>
            </div>
        </div>";

                PuntoReciclajeContainer.Controls.Add(new LiteralControl(cardHtml));
            }
        }

        // Método que obtiene los puntos de reciclaje filtrados (esto es solo un ejemplo)
        private List<PuntosReciclaje> ObtenerPuntosFiltrados(string material, string ciudad, string municipio)


        {
         material = "nombre";
          municipio = "municipio";
         ciudad = "ciudad";
            //Aquí deberías implementar la lógica para obtener los puntos de reciclaje según los filtros
            // Por ejemplo, podrías hacer una consulta a la base de datos filtrando por estos parámetros
            // Este es solo un ejemplo de cómo podrías estructurar la lógica:

            List<PuntosReciclaje> puntosFiltrados = new List<PuntosReciclaje>();
            PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();

            //Filtra en base a los valores seleccionados
            //(Este código es solo una ilustración y debe adaptarse a tu lógica de negocio y base de datos)
            var todosPuntos = puntosReciclajeNegocio.listarTodos(); // Llama a tu negocio para obtener todos los puntos
            //foreach (var punto in todosPuntos)
            //{
            //    if ((material == "Todos" || punto.Material == material) &&
            //        (ciudad == "Todas" || punto.Ciudad == ciudad) &&
            //        (municipio == "Todos" || punto.Municipio == municipio))
            //    {
            //        puntosFiltrados.Add(punto);
            //    }
            //}
             return material == "nombre" && municipio == "municipio" && ciudad == "ciudad" ? todosPuntos : puntosFiltrados;
        }
 

    }
}