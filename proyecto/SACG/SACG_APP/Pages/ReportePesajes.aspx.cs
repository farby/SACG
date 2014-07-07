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
    public partial class ReportePesajes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IRepoAnimal repo = new RepoAnimal();
                ddlAnimal.DataSource = repo.getAll();
                ddlAnimal.DataBind();
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            IRepoAnimal repo = new RepoAnimal();
            try
            {
                Int32 id = Convert.ToInt32(ddlAnimal.SelectedItem.Text);
                bullPesajes.DataSource = repo.Pesajes(id);
                if (bullPesajes.DataSource == null)
                {
                    lblError.Visible = true;
                    bullPesajes.DataSource = new List<String>();
                }
                else
                {
                    lblError.Visible = false;
                }
                bullPesajes.DataBind();
            }
            catch
            {
                lblError.Visible = true;
            }
        }


    }
}