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
    public partial class ModificarEstablecimiento : System.Web.UI.Page
    {
        IRepoEstablecimiento repo = new RepoEstablecimiento();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Establecimiento est = repo.Fnd(Convert.ToInt64(Session["dicose"].ToString()));
                    txtDicose.Text = est.DICOSE.ToString();
                    txtRut.Text = est.RUT.ToString();
                    txtBps.Text = est.BPS.ToString();
                    txtRazonSocial.Text = est.RazonSocial;
                    txtDocumento.Text = est.Responsable.ToString();
                    txtDepartamento.Text = est.Departamento;
                    txtSPolicial.Text = est.SeccionalPolicial.ToString();
                    txtParaje.Text = est.Paraje;
                    txtDireccion.Text = est.Direccion.ToString();
                    txtTelefono.Text = est.Telefono.ToString();
                    txtEmail.Text = est.Email.ToString();
                    txtSuperficie.Text = est.Superficie.ToString();
                }
                catch
                {
                    lblDicose.Text = "DICOSE";
                }
            }
        }

        protected void UpdEstablecimiento(object sender, EventArgs e)
        {
            Establecimiento estUpd = new Establecimiento();
            try
            {
                //CREO EL ESTABLECIMIENTO
                estUpd = new Establecimiento(
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
                //MODIFICO EL ESTABLECIMIENTO
                repo.Upd(estUpd);
            }
            catch
            {
                throw;
            }
        }
    }
}