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
            if (Session["user"] != null && Session["user"].ToString().Length > 0)
            {
                aLogin.Text = "Logout";
                lLogin.Text = "Bienvenido, " + Session["user"];
            }
            else
            {
                Session["user"] = "";
                Session["role"] = "";
                aLogin.Text = "Login";
                lLogin.Text = "";
            }

        }
    }
}