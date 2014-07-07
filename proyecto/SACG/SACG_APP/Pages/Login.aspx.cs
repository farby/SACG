using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SACG_BLL;
using SACG_BLL.IRepos;
using SACG_Repos;
using SACG_APP;

namespace SACG_APP.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"].ToString().Length > 0)
            {
                panLogin.Visible = false;
                panLogout.Visible = true;
            }
            else
            {
                panLogin.Visible = true;
                panLogout.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            IRepoUsuario repo = new RepoUsuario();
            Usuario usr;
            try
            {
                usr = repo.Login(txtUser.Text, txtPass.Text);
                if (usr != null)
                {
                    Session["user"] = usr.User;
                    Session["role"] = usr.Role;
                    Session["dicose"] = usr.Dicose.ToString();
                    lblError.Visible = false;
                }
                else
                {
                    lblError.Visible = true;
                }
            }
            catch
            {
                lblError.Visible = true;
                throw;
            }
            finally
            {
                if (Session["user"].ToString().Length > 0)
                {
                    Response.Redirect("home.aspx");
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["user"] = "";
            Response.Redirect("home.aspx");
        }
    }
}