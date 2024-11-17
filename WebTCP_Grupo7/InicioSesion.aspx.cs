using Dominio;
using Negocio;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTCP_Grupo7
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
          
            Page.Validate();
            if (!Page.IsValid)
                return;  // Si no es válida, no continuar

            Usuario usuario = new Usuario();
            UsuariosNegocio usuariosNegocio = new UsuariosNegocio();
            try
            {
                usuario.Email = txtUsername.Text;
                usuario.Password = txtPassword.Text;

                
                bool credencialesValidas = usuariosNegocio.ValidarUsuario(usuario);

                if (credencialesValidas)
                {
                    
                    Session["Usuario"] = usuario;
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                  
                    lblMessage.Text = "El nombre de usuario o la contraseña son incorrectos.";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
              
                lblMessage.Text = "Ocurrió un error al intentar iniciar sesión. Por favor, intente nuevamente.";
                lblMessage.Visible = true;
                
            }
        }
    }
}
