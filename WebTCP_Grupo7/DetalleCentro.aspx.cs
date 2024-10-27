using System;
using System.Collections.Generic;
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
            if (!IsPostBack)
            {
                LoadCenterDetails();
                LoadComments();
            }

        }




        private void LoadCenterDetails()
        {
            // Lógica para cargar detalles del centro de reciclaje
            // Puedes usar el ID del centro pasado en la query string para buscar en la base de datos
        }

        private void LoadComments()
        {
            // Lógica para cargar comentarios de la base de datos y enlazarlos al repeater
            // rptComments.DataSource = listaDeComentarios;
            // rptComments.DataBind();
        }

        protected void btnSubmitComment_Click(object sender, EventArgs e)
        {
            // Lógica para guardar el comentario en la base de datos
            // Luego, vuelve a cargar la lista de comentarios
            LoadComments();
        }
    }
}