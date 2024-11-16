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
            // Validación de Contraseña
            if (!Seguridad.ContrasenaSegura(txtPassword.Text))
            {
                //lblErrorMessage.Text = "La contraseña no cumple con los requisitos de seguridad. Ejemplo de requisitos de una contraseña segura: Al menos 8 caracteres / Al menos una letra mayúscula / Al menos una letra minúscula/ Al menos un número";
                //lblErrorMessage.Visible = true;

                string script = "alert('La contraseña no cumple con los requisitos de seguridad. Ejemplo de requisitos de una contraseña segura: Al menos 8 caracteres / Al menos una letra mayúscula / Al menos una letra minúscula/ Al menos un número');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                return;
            }

            // Validar si la página es válida (todas las validaciones en los controles de la página)
            Page.Validate();
            if (!Page.IsValid)
                return;

            // Crear instancia de la clase que maneja la lógica de acceso a base de datos
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
                    return; // Termina el proceso si el correo ya está registrado
                }

                // Si el correo no está registrado, continuar con el registro
                Usuario user = new Usuario
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = email,
                    Password = txtPassword.Text
                };

                // Enviar correo de verificación
                EmailService emailService = new EmailService();
                int codigo = Seguridad.ObtenerCodVerificación();
                emailService.armarCorreo(user.Email, "Bienvenido a Puntos de Reciclaje " + user.Nombre, codigo);
                emailService.enviarCorreo();

                // Registrar el usuario en la base de datos
                negocio.RegistrarUsuario(user);

                // Guardar la sesión del usuario
                Session.Add("Usuario", user);

                // Redirigir a la página de verificación de correo
                Response.Redirect("VerificacionEmail.aspx", false);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                lblErrorMessage.Text = "Ocurrió un error al intentar registrar el usuario. Por favor, intente nuevamente.";
                lblErrorMessage.Visible = true;
                // Registrar el error o enviarlo al log de errores
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiar la sesión y redirigir al inicio
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}
