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
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        CargarPuntos();
        //    }
        //}
        //private void CargarPuntos()
        //{
        //    PuntoReciclajeNegocio puntoReciclajeNegocio = new PuntoReciclajeNegocio();
        //    List<PuntosReciclaje> puntosReciclajes = puntoReciclajeNegocio.listarTodos();

        //    foreach (var puntosReciclaje in puntosReciclajes)

        //    {
        //        string carouselId = $"carousel_{puntosReciclaje.idPuntoReciclaje}";
        //        string carouselHtml = $@"
        //        <div id='{carouselId}' class='carousel slide' data-bs-ride='carousel'>
        //        <div class='carousel-inner'>";

        //        for (int i = 0; i < puntosReciclaje.imagenes.Count; i++)
        //        {
        //            var imagen = puntosReciclaje.imagenes[i];
        //            string activeClass = i == 0 ? "active" : "";

        //            carouselHtml += $@"
        //            <div class='carousel-item {activeClass}'>
        //                <img src='{imagen}' class='d-block w-100 img-custom' alt='{puntosReciclaje.Nombre}'>
        //            </div>";

        //        }
        //        carouselHtml += @"
        //    </div>
        //    <button class='carousel-control-prev' type='button' data-bs-target='#" + carouselId + @"' data-bs-slide='prev'>
        //        <span class='carousel-control-prev-icon' aria-hidden='true'></span>
        //        <span class='visually-hidden'>Previous</span>
        //    </button>
        //    <button class='carousel-control-next' type='button' data-bs-target='#" + carouselId + @"' data-bs-slide='next'>
        //        <span class='carousel-control-next-icon' aria-hidden='true'></span>
        //        <span class='visually-hidden'>Next</span>
        //    </button>
        //</div>";

        //        // Card HTML con el carrusel
        //        string cardHtml = $@"
        //<div class='col-md-4 mb-4'>
        //    <div class='card h-100'>
        //        {carouselHtml}
        //        <div class='card-body'>
        //            <h5 class='card-title'>{puntosReciclaje.Nombre}</h5>
        //            <p class='card-text'>{puntosReciclaje.Descripcion}</p>
        //            <a href='FormularioCliente.aspx?IdArticulo={puntosReciclaje.idPuntoReciclaje}' class='btn btn-primary btn-flex'>Canjear</a>
        //        </div>
        //    </div>
        //</div>";

        //        PuntoReciclajeContainer.Controls.Add(new LiteralControl(cardHtml));
        //    }
        //}
    }
}