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
            // Opcional: cualquier código que necesites en la carga de la página
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            // Validar si la página es válida (todas las validaciones en los controles de la página)
            Page.Validate();
            if (!Page.IsValid)
                return;  // Si no es válida, no continuar

            Usuario usuario = new Usuario();
            UsuariosNegocio usuariosNegocio = new UsuariosNegocio();
            try
            {
                usuario.Email = txtUsername.Text;
                usuario.Password = txtPassword.Text;

                // Verificar las credenciales
                bool credencialesValidas = usuariosNegocio.ValidarUsuario(usuario);

                if (credencialesValidas)
                {
                    // Si las credenciales son correctas, almacenar en la sesión y redirigir
                    Session["Usuario"] = usuario;
                    Response.Redirect("Default.aspx", false);
                }
                else
                {
                    // Si las credenciales no son correctas, mostrar un mensaje genérico
                    lblMessage.Text = "El nombre de usuario o la contraseña son incorrectos.";
                    lblMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                lblMessage.Text = "Ocurrió un error al intentar iniciar sesión. Por favor, intente nuevamente.";
                lblMessage.Visible = true;
                // Registrar el error o enviarlo al log de errores
            }
        }
    }
}
