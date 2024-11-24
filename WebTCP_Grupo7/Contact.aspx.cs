using System;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace WebTCP_Grupo7
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Se ejecuta solo en la carga inicial
            {
                lblMessage.Text = "Rellena los campos a continuación y nos pondremos en contacto contigo.";
                lblMessage.ForeColor = System.Drawing.Color.Black;
                pnlContactForm.Visible = true; // Mostrar formulario en la carga inicial
            }
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            // Validar formulario
            if (!ValidateForm())
            {
                return; // Detenemos si hay errores
            }

            // Obtener nombre y mostrar mensaje de confirmación
            string name = txtName.Text;
            lblMessage.Text = $"Gracias por contactarnos, {name}. Tu mensaje ha sido recibido.";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            // Ocultar formulario tras el envío
            pnlContactForm.Visible = false;
        }

        private bool ValidateForm()
        {
            // Validación de campos usando expresiones regulares
            if (string.IsNullOrWhiteSpace(txtName.Text) || !Regex.IsMatch(txtName.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{2,50}$"))
            {
                SetErrorMessage("Por favor, ingresa un nombre válido.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSurname.Text) || !Regex.IsMatch(txtSurname.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{2,50}$"))
            {
                SetErrorMessage("Por favor, ingresa un apellido válido.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                SetErrorMessage("Por favor, ingresa un correo electrónico válido.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || !Regex.IsMatch(txtPhone.Text, @"^\d{7,15}$"))
            {
                SetErrorMessage("Por favor, ingresa un teléfono válido (7 a 15 dígitos).");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtMessage.Text) || txtMessage.Text.Length < 10 || txtMessage.Text.Length > 500)
            {
                SetErrorMessage("Por favor, ingresa un mensaje válido (10-500 caracteres).");
                return false;
            }
            return true;
        }

        private void SetErrorMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = System.Drawing.Color.Red;
        }
    }
}
