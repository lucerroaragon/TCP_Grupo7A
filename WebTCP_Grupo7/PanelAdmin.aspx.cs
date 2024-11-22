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
            if (!IsPostBack)
            {
                PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();
                dgvPanelAdmin.Visible = true;
                dgvPanelAdmin.DataSource = puntosReciclajeNegocio.listarTodos();
                dgvPanelAdmin.DataBind();
            }
            lblMensaje.Visible = false;
            lblMensaje1.Visible = false;

        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            PuntosReciclajeNegocio puntoreciclajenegocio = new PuntosReciclajeNegocio();
            UsuariosNegocio usuariosNegocio = new UsuariosNegocio();
            string seleccionPrincipal = ddlSeleccionar.SelectedValue;
            string filtroUsuario = ddlUsuario.SelectedValue;
            string filtroPuntos = DropDownList3.SelectedValue;

            // Verifica qué tipo de filtro aplicar
            if (seleccionPrincipal == "Usuarios")
            {
                // Lógica para filtrar por usuarios
                if (filtroUsuario == "Activos")
                {
                    // Ejemplo: Filtrar una lista de usuarios activos
                    dgvUsuarios.Visible = true;
                    dgvPanelAdmin.Visible = false;
                    dgvUsuarios.DataSource = usuariosNegocio.listar("1");
                    dgvUsuarios.DataBind();
                }
                else if (filtroUsuario == "Bajas")
                {
                    // Filtrar por usuarios dados de baja
                    dgvUsuarios.Visible = true;
                    dgvPanelAdmin.Visible = false;
                    dgvUsuarios.DataSource = usuariosNegocio.listar("0");
                    dgvUsuarios.DataBind();
                    if(dgvUsuarios.DataSource.ToString() == null)
                    {
                        lblMensaje1.Visible = true;
                        lblMensaje1.Text = "No hay usurios dados de baja! ";
                    }

                }
                else
                {
                    // Filtrar todos los usuarios
                    dgvUsuarios.Visible = true;
                    dgvPanelAdmin.Visible = false;
                    dgvUsuarios.DataSource = usuariosNegocio.listar();
                    dgvUsuarios.DataBind();
                }
            }
            else if (seleccionPrincipal == "Puntos reciclaje")
            {
                // Lógica para filtrar puntos de reciclaje
                if (filtroPuntos == "Validados")
                {
                    btnAprobar.Visible = false;
                    dgvPanelAdmin.Visible = true;
                    dgvPanelAdmin.DataSource = puntoreciclajenegocio.listarTodos("1");
                    dgvPanelAdmin.DataBind();
                }
                else if (filtroPuntos == "Sin Validar")
                {
                    btnAprobar.Visible = true;
                    dgvPanelAdmin.Visible = true;
                    dgvPanelAdmin.DataSource = puntoreciclajenegocio.listarTodos("0");
                    dgvPanelAdmin.DataBind();
                }
            }
            else
            {
                // Si no se seleccionó una opción válida
                //MostrarMensaje("Por favor, selecciona un filtro válido.");
            }

        }

        protected void dgvPanelAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = dgvPanelAdmin.SelectedRow.Cells[1].Text;
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
                    string idSeleccionado = row.Cells[1].Text; // Obtén el ID, por ejemplo
                    string nombreSeleccionado = row.Cells[2].Text; // Nombre
                    Session["estado"] = "0";
                    Response.Redirect("DetalleCentro.aspx?IdPR=" + idSeleccionado);
                    break;

                case "Editar":
                    // Lógica para manejar la edición
                    string idEditar = row.Cells[1].Text; // Obtén el ID
                    Response.Redirect("RegistroPuntoReciclaje.aspx?IdPR=" + idEditar);
                    break;
            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            int contar = 0;
            foreach (GridViewRow row in dgvPanelAdmin.Rows)
            {
                // Encuentra el CheckBox en cada fila
                CheckBox chkSelect = (CheckBox)row.FindControl("chkSelect");

                if (chkSelect != null && chkSelect.Checked)
                {
                    // Obtén el ID de la fila seleccionada
                    int idPuntoReciclaje = Convert.ToInt32(dgvPanelAdmin.DataKeys[row.RowIndex].Value);

                    // Aquí puedes aprobar el elemento o realizar la acción deseada
                    AprobarPuntoReciclaje(idPuntoReciclaje);
                    contar++;
                }
            }

            // Recarga el GridView o muestra un mensaje de éxito
            
            if(contar == 0)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se seleccionó ningún punto de reciclaje.";
                return;
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Puntos de reciclaje aprobados con éxito.";
                CargarDatosGridView();
            }
        }

        private void CargarDatosGridView()
        {
            PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();
            dgvPanelAdmin.DataSource = puntosReciclajeNegocio.listarTodos();
            dgvPanelAdmin.DataBind();
        }
        private void AprobarPuntoReciclaje(int id)
        {
            // Lógica para aprobar el punto de reciclaje, como actualizar el estado en la base de datos
            PuntosReciclajeNegocio negocio = new PuntosReciclajeNegocio();
            negocio.Aprobar(id); // Implementa este método en tu capa de negocio
        }

        protected void ddlSeleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Resetea la visibilidad de los filtros
            filtrosUsuarios.Visible = false;
            filtrosPuntos.Visible = false;

            // Determina qué filtros mostrar
            switch (ddlSeleccionar.SelectedValue)
            {
                case "Usuarios":
                    filtrosUsuarios.Visible = true;
                    btnAprobar.Visible = false;
                    break;
                case "Puntos reciclaje":
                    filtrosPuntos.Visible = true;
                    break;
            }
        }

        protected void dgvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Obtén el índice de la fila
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            // Usa el índice para acceder a los datos de la fila
            GridViewRow row = dgvUsuarios.Rows[rowIndex];

            // Dependiendo del comando, realiza una acción
            switch (e.CommandName)
            {
                case "EditarUser":
                    // Lógica para manejar la edición
                    string idEditar = row.Cells[1].Text; // Obtén el ID
                    Response.Redirect("RegistrarUsuario.aspx?IdUser=" + idEditar);
                    break;
            }

        }
    }
}