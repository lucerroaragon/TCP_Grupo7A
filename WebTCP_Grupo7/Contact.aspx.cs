using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace WebTCP_Grupo7
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí puedes agregar el código para cargar la página
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (!ValidateForm())
            {
                return;
            }

            // Obtener los datos del formulario
            string name = txtName.Text;

            // Mostrar mensaje de confirmación
            lblMessage.Text = $"Gracias por contactarnos, {name}. Tu mensaje ha sido recibido.";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            // Ocultar el formulario
            pnlContactForm.Visible = false;
        }

        private bool ValidateForm()
        {
            // Validar Nombre
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblMessage.Text = "El campo 'Nombre' es obligatorio.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (!Regex.IsMatch(txtName.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{2,50}$"))
            {
                lblMessage.Text = "El 'Nombre' solo debe contener letras y tener entre 2 y 50 caracteres.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Validar Apellido
            if (string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                lblMessage.Text = "El campo 'Apellido' es obligatorio.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (!Regex.IsMatch(txtSurname.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{2,50}$"))
            {
                lblMessage.Text = "El 'Apellido' solo debe contener letras y tener entre 2 y 50 caracteres.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Validar Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                lblMessage.Text = "El campo 'Email' es obligatorio.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                lblMessage.Text = "Por favor, ingresa un correo electrónico válido.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Validar Teléfono
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                lblMessage.Text = "El campo 'Teléfono' es obligatorio.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (!Regex.IsMatch(txtPhone.Text, @"^\d{7,15}$"))
            {
                lblMessage.Text = "El 'Teléfono' debe contener solo números y tener entre 7 y 15 dígitos.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Validar Mensaje
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                lblMessage.Text = "El campo 'Mensaje' es obligatorio.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (txtMessage.Text.Length < 10 || txtMessage.Text.Length > 500)
            {
                lblMessage.Text = "El 'Mensaje' debe tener entre 10 y 500 caracteres.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            return true;
        }
    }
}
