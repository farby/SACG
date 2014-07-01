using System;
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
    public partial class _WebEstablecimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AltaEstablecimiento()
        {
            IRepoEstablecimiento repo = new RepoEstablecimiento();
            
            Int64.Parse(txtDepartamento.Text);
            SACG_BLL.Establecimiento e = new SACG_BLL.Establecimiento(
                Convert.ToInt64(txtDicose.Text),
                Convert.ToInt64(txtRut.Text),
                Convert.ToInt64(txtBps.Text),
                txtRazonSocial.Text,
                Convert.ToInt64(txtDocumento.Text),
                txtDepartamento.Text,
                Convert.ToInt32(txtSPolicial.Text), 
                txtParaje.Text,
                txtDireccion.Text,
                txtTelefono.Text,
                txtEmail.Text, 
                Convert.ToInt32(txtSuperficie.Text));

            repo.Add(e);
        }
    }
}