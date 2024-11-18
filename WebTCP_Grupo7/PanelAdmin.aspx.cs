using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTCP_Grupo7
{
    public partial class PanelAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();
            dgvPanelAdmin.DataSource = puntosReciclajeNegocio.listarTodos();
            dgvPanelAdmin.DataBind();

        }
    }
}