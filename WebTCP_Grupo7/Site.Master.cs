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
            if (!(Page is InicioSesion || Page is _Default || Page is Mision || Page is RegistrarUsuario))
            {
                if (!Seguridad.ValidarUsuario(Session["Usuario"]))
                {
                    Response.Redirect("InicioSesion.aspx");
                }
            
            }
            //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //{

            //    iniciarsesionLink.Visible = false;
            //    registarseLink.Visible = false;
            //    cerrarsesionLink.Visible = true;

            //}
            //else
            //{
            //    iniciarsesionLink.Visible = true;
            //    registarseLink.Visible = true;
            //    cerrarsesionLink.Visible = false;
            //}

        }
    }
}