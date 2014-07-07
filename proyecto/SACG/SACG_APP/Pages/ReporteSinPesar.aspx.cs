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
    public partial class ReporteSinPesar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            IRepoAnimal repo = new RepoAnimal();
            try
            {
                DateTime fecha = Convert.ToDateTime(calFecha.SelectedDate);
                List<Animal> list = repo.sinPesar(fecha);
                List<String> sinPesar = new List<String>();
                foreach (var i in list)
	            {
                    sinPesar.Add("ID: " + i.ID + " | DICOSE: " + i.DICOSE + " | Sexo: " + i.Sexo +
                        " | Raza / Cruza: " + i.RazaCruza + " | Año Nacimiento: " + i.AnoNacimiento);
	            }
                bullSinPesar.DataSource = sinPesar;
                if (bullSinPesar.DataSource == null)
                {
                    lblError.Visible = true;
                    bullSinPesar.DataSource = new List<String>();
                }
                else
                {
                    lblError.Visible = false;
                }
                bullSinPesar.DataBind();
            }
            catch
            {
                lblError.Visible = true;
            }
        }
    }
}