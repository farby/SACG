using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SACG_APP
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (aLogin.Text == "Cerrar Sesion")
            {
                Session["user"] = "";
            }
            if (Session["user"] == null || Session["user"] == "")
            {
                Session["user"] = "";
                Session["role"] = "";
                aLogin.Text = "Login";
                lLogin.Text = "";
            }
            else
            {
                aLogin.Text = "Cerrar Sesion";
                lLogin.Text = "Bienvenido, " + Session["user"];
            }
        }
    }
}