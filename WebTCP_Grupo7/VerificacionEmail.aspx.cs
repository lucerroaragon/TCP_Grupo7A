using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebTCP_Grupo7
{
    public partial class VerificacionEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnValidar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            UsuariosNegocio negocio = new UsuariosNegocio();
            try
            {
                datos.setearConsulta("SELECT numcodigo FROM CODIGOVERIFICACION WHERE numcodigo = @Codigo");
                datos.setearParametro("@Codigo", txtCodigo.Text);
                datos.ejecutarLectura();
                

                if (datos.Lector.Read())
                {
                    Usuario user = (Usuario)Session["Usuario1"];
                    negocio.RegistrarUsuario(user);
                    Seguridad.EliminarCodigo(int.Parse(txtCodigo.Text));
                    Response.Redirect("InicioSesion.aspx", false);
                }
                else
                {
                    //lblError.Text = "Código incorrecto";
                    //lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Session.Clear();
                datos.cerrarConexion();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}