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
    public partial class RegistrarEstablecimiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void AddEstablecimiento(object sender, EventArgs e)
        {
            IRepoEstablecimiento repo = new RepoEstablecimiento();
            SACG_BLL.Establecimiento est;
            SACG_BLL.Persona per;
            try
            {
                //CREO EL ESTABLECIMIENTO
                est = new Establecimiento(
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
                //CREO EL RESPONSABLE
                per = new Persona(
                    Convert.ToInt64(txtDocumento.Text),
                    txtNombre.Text,
                    txtApellido.Text,
                    txtTelefono.Text
                );
                //AGREGO EL ESTABLECIMIENTO Y SU RESPONSABLE
                repo.Add(est, per);
            }
            catch
            {
                throw;
            }
        }
        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}