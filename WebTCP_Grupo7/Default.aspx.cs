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
        <div class='col-md-4 mb-4'>
            <div class='card h-100'>
                {carouselHtml}
                <div class='card-body'>
                    <h5 class='card-title'>{puntosReciclaje.Nombre}</h5>
                    <p class='card-text'>{puntosReciclaje.Descripcion}</p>
                    <a href='Detallecentro.aspx?IdArticulo={puntosReciclaje.IdPuntoReciclaje}' class='btn btn-primary btn-flex'>+ Detalles</a>
                </div>
            </div>
        </div>";

                PuntoReciclajeContainer.Controls.Add(new LiteralControl(cardHtml));
            }
        }
    }
}