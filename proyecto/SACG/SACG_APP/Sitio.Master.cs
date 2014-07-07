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
                Session["dicose"] = "";
                aLogin.Text = "Login";
                lLogin.Text = "";
            }
            Permisos();
        }

        private void Permisos()
        {
            switch (Session["role"].ToString())
            {
                case "Administrador":
                    aEstablecimientos.Visible = false;
                    aERegistrar.Visible = false;
                    aEModificar.Visible = false;
                    aEActivar.Visible = false;
                    aEListar.Visible = false;

                    aAnimales.Visible = false;
                    aARegistrar.Visible = false;
                    aAEvento.Visible = false;
                   // aATransferencia.Visible = false;

                    aPersonas.Visible = true;

                    aReportes.Visible = false;
                    break;

                case "Sociedad":
                    aEstablecimientos.Visible = true;
                    aERegistrar.Visible = true;
                    aEModificar.Visible = false;
                    aEActivar.Visible = true;
                    aEListar.Visible = true;

                    aAnimales.Visible = true;
                    aARegistrar.Visible = true;
                    aAEvento.Visible = true;
                    //aATransferencia.Visible = true;

                    aPersonas.Visible = false;

                    aReportes.Visible = true;
                    break;

                case "Establecimiento":
                    aEstablecimientos.Visible = true;
                    aERegistrar.Visible = false;
                    aEModificar.Visible = true;
                    aEActivar.Visible = false;
                    aEListar.Visible = false;

                    aAnimales.Visible = true;
                    aARegistrar.Visible = true;
                    aAEvento.Visible = true;
                    //aATransferencia.Visible = true;

                    aPersonas.Visible = false;

                    aReportes.Visible = true;
                    break;

                default:
                    //SIN USUARIO O USUARIO NO LOGUEADO
                    aEstablecimientos.Visible = true;
                    aERegistrar.Visible = true;
                    aEModificar.Visible = false;
                    aEActivar.Visible = false;
                    aEListar.Visible = false;

                    aAnimales.Visible = false;
                    aARegistrar.Visible = false;
                    aAEvento.Visible = false;
                   // aATransferencia.Visible = false;

                    aPersonas.Visible = false;

                    aReportes.Visible = false;
                    break;
            }
        }
    }
}