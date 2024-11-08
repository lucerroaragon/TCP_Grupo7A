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
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Opcional: cualquier código que necesites en la carga de la página
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuariosNegocio usuariosNegocio = new UsuariosNegocio();
            try
            {
                usuario.Email = txtUsername.Text;
                usuario.Password = txtPassword.Text;
                if (usuariosNegocio.ValidarUsuario(usuario))
                {
                    Session["Usuario"] = usuario;
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    Response.Redirect("InicioSesion.aspx", false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
      
        }
    }
}