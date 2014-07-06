﻿using System;
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

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            IRepoUsuario repo = new RepoUsuario();
            Usuario usr;
            try
            {
                //ACTUALIZO EL ESTABLECIMIENTO, SETEANDO SU ESTADO COMO ACTIVO
                usr = repo.Login(txtUser.Text, txtPass.Text);
                if (usr != null)
                {
                    Session["user"] = usr.User;
                    Session["role"] = usr.Role;
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
        }
    }
}