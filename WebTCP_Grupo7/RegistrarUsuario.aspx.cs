using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;


namespace WebTCP_Grupo7
{
    public partial class RegistrarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                Usuario user = new Usuario();
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;
                negocio.RegistrarUsuario(user);
                Session["Usuario"] = user;
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Session.Clear();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}