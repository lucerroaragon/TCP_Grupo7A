using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTCP_Grupo7
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDNI.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            string direccion = txtDireccion.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validaciones simples
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                string.IsNullOrWhiteSpace(dni) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(telefono) || string.IsNullOrWhiteSpace(direccion) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                lblMessage.Text = "Por favor, complete todos los campos.";
                return;
            }

            if (password != confirmPassword)
            {
                lblMessage.Text = "Las contraseñas no coinciden.";
                return;
            }

            // Aquí puedes agregar la lógica para almacenar el usuario en la base de datos
            // Por ejemplo, usar Entity Framework para registrar el nuevo usuario.

            lblMessage.Text = "Registro exitoso. ¡Bienvenido, " + nombre + " " + apellido + "!";

            // Limpiar los campos después de registrar
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDNI.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }


    }
}