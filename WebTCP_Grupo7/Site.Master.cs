using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTCP_Grupo7
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {

                loginLink.Visible = false;
                signUpLink.Visible = false;
                logoutLink.Visible = true;

            }
            else
            {
                loginLink.Visible = true;
                signUpLink.Visible = true;
                logoutLink.Visible = false;
            }

        }
    }
}