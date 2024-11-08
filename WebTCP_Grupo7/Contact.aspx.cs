using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebTCP_Grupo7
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Aquí puedes agregar el código para cargar la página
        }

        // Este es el evento que maneja el clic del botón
        protected void btnSend_Click(object sender, EventArgs e)
        {
            // Aquí puedes agregar la lógica para manejar el formulario, como enviar el correo electrónico o guardar los datos.
            // Ejemplo:
            string name = txtName.Text;
            string email = txtEmail.Text;
            string message = txtMessage.Text;

            // Hacer algo con los datos, como enviarlos por correo o guardarlos en una base de datos
            // Ejemplo:
            lblMessage.Text = "Gracias por contactarnos, " + name + ". Tu mensaje ha sido recibido.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}
