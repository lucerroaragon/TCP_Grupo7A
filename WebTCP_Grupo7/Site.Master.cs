using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace WebTCP_Grupo7
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is InicioSesion || Page is _Default || Page is Mision || Page is RegistrarUsuario || Page is Contact || Page is Home || Page is DetalleCentro || Page is VerificacionEmail))
            {
                if (!Seguridad.ValidarUsuario(Session["Usuario"]))
                {
                    Response.Redirect("InicioSesion.aspx");
                }
            }

            // Asignar el evento Command a los botones al cargar la página
            btnLogoutSmall.Command += Logout;
            btnLogoutLarge.Command += Logout;
        }

        protected void Logout(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Logout")
            {
                // Limpiar sesión
                Session.Clear();


                // Redirigir al usuario
                Response.Redirect("/Default.aspx");
            }
        }
    }
}