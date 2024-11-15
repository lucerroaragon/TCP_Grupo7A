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
            if (!Seguridad.ContrasenaSegura(txtPassword.Text))
            {
                // Muestra un mensaje de error al usuario si la contraseña no es segura
                lblErrorMessage.Text = "La contraseña no cumple con los requisitos de seguridad. Ejemplo de requisitos de una contraseña segura: Al menos 8 caracteres / Al menos una letra mayúscula /Al menos una letra minúscula/ Al menos un número";
                lblErrorMessage.Visible = true;
                return;
            }

            Page.Validate();
            if (!Page.IsValid)
                return;

            UsuariosNegocio negocio = new UsuariosNegocio();
            try
            {
                Usuario user = new Usuario();
                EmailService emailService = new EmailService();
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                user.Password = txtPassword.Text;

                int codigo = Seguridad.ObtenerCodVerificación();
                emailService.armarCorreo(user.Email, "Bien benido a Puntos de Reciclaje" + user.Nombre, codigo);
                emailService.enviarCorreo();
                Session.Add("Usuario", user);
                //negocio.RegistrarUsuario(user);

                Response.Redirect("VerificacionEmail.aspx", false);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}