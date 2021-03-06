﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SACG_BLL;
using SACG_BLL.IRepos;
using SACG_Repos;

namespace SACG_APP
{
    public partial class ActivarEstablecimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IRepoEstablecimiento repo = new RepoEstablecimiento();
            if (!IsPostBack)
            {
                lstPendientes.DataSource = repo.Sby();
                lstPendientes.DataBind();

                lstActivos.DataSource = repo.All();
                lstActivos.DataBind();
            }
        }

        protected void btnActivar_Click(object sender, EventArgs e)
        {
            IRepoEstablecimiento repo = new RepoEstablecimiento();
            Establecimiento est;
            try
            {
                //CREO EL ESTABLECIMIENTO
                est = new Establecimiento(
                   Convert.ToInt64(lstPendientes.SelectedItem.Text)
                ); 
                //ACTUALIZO EL ESTABLECIMIENTO, SETEANDO SU ESTADO COMO ACTIVO
                repo.Act(est);
                lblError.Visible = false;
                Response.Redirect("home.aspx");
            }
            catch
            {
                lblError.Visible = true;
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            IRepoEstablecimiento repo = new RepoEstablecimiento();
            Establecimiento est;
            try
            {
                //CREO EL ESTABLECIMIENTO
                est = new Establecimiento(
                    Convert.ToInt64(lstActivos.SelectedItem.Text)
                );
                //ACTUALIZO EL ESTABLECIMIENTO, SETEANDO SU ESTADO COMO INACTIVO
                repo.Rem(est);
                lblError.Visible = false;
                Response.Redirect("home.aspx");
            }
            catch
            {
                lblError.Visible = true;
            }
        }
    }
}