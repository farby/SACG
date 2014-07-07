using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SACG_BLL;
using SACG_BLL.IRepos;
using SACG_Repos;

namespace SACG_APP.Pages
{
    public partial class Activo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt64(Session["dicose"]) > 0)
            {
                panEstablecimiento.Visible = true;
            }
        }

        protected void btnDocumento_Click(object sender, EventArgs e)
        {
            IRepoEstablecimiento repo = new RepoEstablecimiento();
            Establecimiento est = new Establecimiento();
            est.DICOSE = Convert.ToInt64(Session["dicose"].ToString());
            est.Responsable = Convert.ToInt32(txtDocumento.Text);
            repo.Res(est);
            Response.Redirect("home.aspx");
        }

        protected void btnPass_Click(object sender, EventArgs e)
        {
            IRepoUsuario repo = new RepoUsuario();
            Usuario u = new Usuario();
            u.User = Session["user"].ToString();
            u.Pass = txtPass.Text;
            repo.Pas(u);
            Response.Redirect("home.aspx");
        }
    }
}