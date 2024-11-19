using Negocio;
using System;
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
                //lblErrorMessage.Text = "La contraseña no cumple con los requisitos de seguridad. Ejemplo de requisitos de una contraseña segura: Al menos 8 caracteres / Al menos una letra mayúscula / Al menos una letra minúscula/ Al menos un número";
                //lblErrorMessage.Visible = true;

                string script = "alert('La contraseña no cumple con los requisitos de seguridad. Ejemplo de requisitos de una contraseña segura: Al menos 8 caracteres / Al menos una letra mayúscula / Al menos una letra minúscula/ Al menos un número');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                return;
            }

            
            Page.Validate();
            if (!Page.IsValid)
                return;

           
            UsuariosNegocio negocio = new UsuariosNegocio();

            try
            {
                // Verificar si el correo ya está registrado en la base de datos
                string email = txtEmail.Text;
                bool emailExistente = negocio.ValidarEmailExistente(email); // Método que deberás crear en la capa de negocio
                if (emailExistente)
                {
                    lblErrorMessage.Text = "El correo electrónico ya está registrado. Por favor, ingrese otro.";
                    lblErrorMessage.Visible = true;
                    return; 
                }

               
                Usuario user = new Usuario
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = email,
                    Password = txtPassword.Text
                };

               
                EmailService emailService = new EmailService();
                int codigo = Seguridad.ObtenerCodVerificación();
                emailService.armarCorreo(user.Email, "Bienvenido a Puntos de Reciclaje " + user.Nombre, codigo);
                emailService.enviarCorreo();

             
                negocio.RegistrarUsuario(user);

                // Guardar la sesión del usuario
                Session.Add("Usuario1", user);

               
                Response.Redirect("VerificacionEmail.aspx", false);
            }
            catch (Exception)
            {
               
                lblErrorMessage.Text = "Ocurrió un error al intentar registrar el usuario. Por favor, intente nuevamente.";
                lblErrorMessage.Visible = true;
      
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}
