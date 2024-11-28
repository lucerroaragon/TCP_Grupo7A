using Dominio;
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
            if (!Seguridad.esAdmin(Session["Usuario"]))
            {
                Response.Redirect("Default.aspx", false);
            }
            //if (!IsPostBack)
            //{
            //    PuntosReciclajeNegocio puntosReciclajeNegocio = new PuntosReciclajeNegocio();
            //    dgvPanelAdmin.Visible = true;
            //    dgvPanelAdmin.DataSource = puntosReciclajeNegocio.listarTodos();
            //    dgvPanelAdmin.DataBind();
            //}
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
                    btnRechazar.Visible = false;
                    dgvUsuarios.DataSource = usuariosNegocio.listar("1");
                    dgvUsuarios.DataBind();
                }
                else if (filtroUsuario == "Bajas")
                {
                    // Filtrar por usuarios dados de baja
                    dgvUsuarios.Visible = true;
                    dgvPanelAdmin.Visible = false;
                    btnRechazar.Visible = false;
                    dgvUsuarios.DataSource = usuariosNegocio.listar("0");
                    dgvUsuarios.DataBind();
                    if (dgvUsuarios.DataSource.ToString() == null)
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
                    btnRechazar.Visible = false;
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
                    btnRechazar.Visible = false;
                    dgvPanelAdmin.Visible = true;
                    dgvPanelAdmin.DataSource = puntoreciclajenegocio.listarTodos("1");
                    dgvPanelAdmin.DataBind();
                }
                else if (filtroPuntos == "Sin Validar")
                {
                    btnAprobar.Visible = true;
                    btnRechazar.Visible = true;
                    dgvPanelAdmin.Visible = true;
                    // Agrega atributos de Bootstrap al botón
                    btnRechazar.Attributes.Add("data-bs-toggle", "modal");
                    btnRechazar.Attributes.Add("data-bs-target", "#exampleModal");
                    btnRechazar.Attributes.Add("data-bs-whatever", "@mdo");
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
                    var estado = dgvPanelAdmin.DataKeys[rowIndex].Values["Estado"];
                    Session["estado"] = dgvPanelAdmin.DataKeys[rowIndex].Values["Estado"];
                    Response.Redirect("DetalleCentro.aspx?IdPR=" + idSeleccionado);
                    break;

                case "Editar":
                    // Lógica para manejar la edición
                    string idEditar = row.Cells[1].Text; // Obtén el ID
                    estado = dgvPanelAdmin.DataKeys[rowIndex].Values["Estado"];
                    Session["estado"] = dgvPanelAdmin.DataKeys[rowIndex].Values["Estado"];
                    Response.Redirect("RegistroPuntoReciclaje.aspx?IdPR=" + idEditar);
                    break;

            }
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            UsuariosNegocio userNegocio = new UsuariosNegocio();
            PuntosReciclajeNegocio puntoNegocio = new PuntosReciclajeNegocio();
            PuntosReciclaje puntosReciclaje = new PuntosReciclaje();
            Usuario usuario = new Usuario();
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
                    puntosReciclaje = puntoNegocio.ObtenerPorId(idPuntoReciclaje, 1);
                    usuario = userNegocio.ObtenerUsuario_id(puntosReciclaje.Usuario.idUsuario);
                    string cuerpo = "<h1>¡Bienvenido a Puntos de Reciclaje!</h1><br><p>Gracias por registrar un Punto de Reciclaje. Te informamos que tu Punto de Reciclaje fue aprobado, lo prodrás ver disponible en nuestra paguna web.</p><br><p>¡Gracias por ser parte de la comunidad de Recicladores!</p><br><p>Saludos cordiales,</p><br><p>Equipo de Puntos de Reciclaje</p>";
                    emailService.armarCorreo(usuario.Email, "Punto de Reciclaje Aprobado", 0, cuerpo);

                    emailService.enviarCorreo();
                    contar++;
                }
            }


            if (contar == 0)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se seleccionó ningún punto de reciclaje.";
                return;
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Puntos de reciclaje aprobados con éxito.";
                Response.Redirect("PanelAdmin.aspx", false);
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
                    btnRechazar.Visible = false;
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

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            UsuariosNegocio userNegocio = new UsuariosNegocio();
            PuntosReciclajeNegocio puntoNegocio = new PuntosReciclajeNegocio();
            PuntosReciclaje puntosReciclaje = new PuntosReciclaje();
            Usuario usuario = new Usuario();
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
                    puntosReciclaje = puntoNegocio.ObtenerPorId(idPuntoReciclaje);
                    usuario = userNegocio.ObtenerUsuario_id(puntosReciclaje.Usuario.idUsuario);
                    string mensaje = txtMensaje.Text;
                    string cuerpo = "<h1>¡Bienvenido a Puntos de Reciclaje!</h1><br><p>Gracias por registrar un Punto de Reciclaje. Te informamos que tu Punto de Reciclaje fue rechazado, por el motivo: " +  mensaje + "</p><br><p> Por favor revisa la información y vuelve a intentarlo.</p><br><p>¡Gracias por ser parte de la comunidad de Recicladores!</p><br><p>Saludos cordiales,</p><br><p>Equipo de Puntos de Reciclaje</p>";
                    emailService.armarCorreo(usuario.Email, "Punto de Reciclaje Rechazado", 0, cuerpo);

                    emailService.enviarCorreo();
                    puntoNegocio.eliminar(idPuntoReciclaje);
                    contar++;
                }
            }

            if (contar == 0)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se seleccionó ningún punto de reciclaje.";
                return;
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Puntos de reciclaje rechazados con éxito.";
                Response.Redirect("PanelAdmin.aspx", false);
            }

        }
    }
}