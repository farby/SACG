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
        Establecimiento est = new Establecimiento();
        //DEBERIA RECUPERAR EL DICOSE DEL USUARIO LOGUEADO (SI CORRESPONDE)
        Int64 dicose = 123456;

        protected void Page_Load(object sender, EventArgs e)
        {
            est = repo.Fnd(dicose);
            txtDicose.Text = est.DICOSE.ToString();
            txtRut.Text = est.RUT.ToString();
            txtBps.Text = est.BPS.ToString();
            txtRazonSocial.Text = est.RazonSocial.ToString();
            txtDocumento.Text = est.Responsable.ToString();
            txtDepartamento.Text = est.Departamento.ToString();
            txtSPolicial.Text = est.SeccionalPolicial.ToString();
            txtParaje.Text = est.Paraje.ToString();
            txtDireccion.Text = est.Direccion.ToString();
            txtTelefono.Text = est.Telefono.ToString();
            txtEmail.Text = est.Email.ToString();
            txtSuperficie.Text = est.Superficie.ToString();

        }

        protected void UpdEstablecimiento(object sender, EventArgs e)
        {
            Establecimiento estUpd = new Establecimiento();
            Persona per = new Persona(
                Convert.ToInt64(txtDocumento.Text),
                "", "", txtTelefono.Text);
            try
            {
                //CREO EL ESTABLECIMIENTO
                estUpd = new Establecimiento(
                Convert.ToInt64(est.DICOSE),
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
                //MODIFICO EL ESTABLECIMIENTO Y SU RESPONSABLE
                repo.Upd(est, per);
            }
            catch
            {
                throw;
            }
        }
    }
}