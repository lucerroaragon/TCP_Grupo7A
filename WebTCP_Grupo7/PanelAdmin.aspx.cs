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
            if (!Seguridad.esAdmin(Session["Usuario"])){
                Response.Redirect("Default.aspx", false);
            }
            PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();
            dgvPanelAdmin.DataSource = puntosReciclajeNegocio.listarTodos();
            dgvPanelAdmin.DataBind();

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

        }

        protected void dgvPanelAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = dgvPanelAdmin.SelectedRow.Cells[0].Text;
            Response.Redirect("DetalleCentro.aspx?IdPR=" + Id);
        }

        protected void dgvPanelAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Obtén el índice de la fila
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            // Usa el índice para acceder a los datos de la fila
            GridViewRow row = dgvPanelAdmin.Rows[rowIndex];

            // Dependiendo del comando, realiza una acción
            switch (e.CommandName)
            {
                case "Seleccionar":
                    // Lógica para manejar la selección
                    string idSeleccionado = row.Cells[0].Text; // Obtén el ID, por ejemplo
                    string nombreSeleccionado = row.Cells[1].Text; // Nombre
                    Response.Redirect("DetalleCentro.aspx?IdPR=" + idSeleccionado);
                    break;

                case "Editar":
                    // Lógica para manejar la edición
                    string idEditar = row.Cells[0].Text; // Obtén el ID
                    Response.Redirect("RegistroPuntoReciclaje.aspx?IdPR=" + idEditar);

                    break;
            }
        }
    }
}