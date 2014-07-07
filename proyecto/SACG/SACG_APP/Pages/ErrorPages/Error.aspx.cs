using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SACG_APP.Pages.ErrorPages
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtError.Text = Session["error"].ToString();
            }
         
        }

        protected void cancel(Object sender, EventArgs e)
        {
            navegarHome();
        }

        // Navega a la home de la aplicacion.
        private void navegarHome() { Response.Redirect("../home.aspx"); }
    }
}