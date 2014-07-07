using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SACG_BLL;
using SACG_BLL.IRepos;
using SACG_Repos;

namespace SACG_APP.Pages
{
    public partial class TratamientoSanitario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillTreatmentList();
                FillYearList();
                FillDicoseList();
                
                trRow1.Visible = false;
                trRow2.Visible = false;
                trRow3.Visible = false;
                trRow4.Visible = false;
            }
        }

        protected void Selection_Change(Object sender, EventArgs e)
        {
            FillAnimalList();
        }

        protected void treatment_change(Object sender, EventArgs e)
        {
            String option = listTratamiento.SelectedItem.Value;
            if (option.Equals("Muerte"))
            {
                trRow1.Visible = true;
                trRow2.Visible = false;
                trRow3.Visible = false;
                trRow4.Visible = false;
            }
            else if (option.Equals("Pesaje"))
            { 
                trRow1.Visible = false;
                trRow2.Visible = true;
                trRow3.Visible = false;
                trRow4.Visible = false;
            }
            else if (option.Equals("Vacunas"))
            {
                trRow1.Visible = false;
                trRow2.Visible = false;
                trRow3.Visible = true;
                trRow4.Visible = false;
            }
            else
            {
                trRow1.Visible = false;
                trRow2.Visible = false;
                trRow3.Visible = false;
                trRow4.Visible = true;
            }
        }

        protected void cancel(Object sender, EventArgs e)
        {
            navegarHome();
        }

        // Navega a la home de la aplicacion.
        private void navegarHome() { Response.Redirect("home.aspx"); }

        protected void FillTreatmentList()
        {

            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(String)));

            // Populate the table with sample values.
            dt.Rows.Add(CreateRow("", "", dt));
            dt.Rows.Add(CreateRow("Muerte", "Muerte", dt));
            dt.Rows.Add(CreateRow("Pesaje", "Pesaje", dt));
            dt.Rows.Add(CreateRow("Vacunas", "Vacunas", dt));
            dt.Rows.Add(CreateRow("Tratamiento", "Tratamiento", dt));

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.

            listTratamiento.DataSource = new DataView(dt);
            listTratamiento.DataTextField = "TextField";
            listTratamiento.DataValueField = "ValueField";

            // Bind the data to the control.
            listTratamiento.DataBind();

            // Set the default selected item, if desired.
            listTratamiento.SelectedIndex = 0;


        }

        protected void FillYearList()
        {

            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(String)));

            // Populate the table with sample values.
            int year;
            int actualYear = DateTime.Now.Year;
            for (year = 1980; year <= actualYear; year++)
            {
                dt.Rows.Add(CreateRow(Convert.ToString(year), Convert.ToString(year), dt));
            }

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.

            yearList.DataSource = new DataView(dt);
            yearList.DataTextField = "TextField";
            yearList.DataValueField = "ValueField";

            // Bind the data to the control.
            yearList.DataBind();

            // Set the default selected item, if desired.
            yearList.SelectedIndex = 0;


        }

        protected void FillAnimalList()
        {
            Int64 dicose = Convert.ToInt64(listEstablecimientos.SelectedItem.Value);

            IRepoAnimal repo = new RepoAnimal();
            List<Animal> animales = repo.getAllByEst(dicose);
            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(String)));

            foreach (Animal obj in animales)
            {
                String idAnimal = Convert.ToString(obj.ID);
                // Populate the table with sample values.
                dt.Rows.Add(CreateRow(idAnimal, idAnimal, dt));
            }

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.
            listAnimales.DataSource = new DataView(dt);
            listAnimales.DataTextField = "TextField";
            listAnimales.DataValueField = "ValueField";

            // Bind the data to the control.
            listAnimales.DataBind();

            // Set the default selected item, if desired.
            listAnimales.SelectedIndex = 0;

        }

        protected void FillDicoseList()
        {

            IRepoEstablecimiento repoEst = new RepoEstablecimiento();
            List<Int64> activos = repoEst.All();
            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(String)));

            foreach (Int64 dicose in activos)
            {
                // Populate the table with sample values.
                dt.Rows.Add(CreateRow(Convert.ToString(dicose), Convert.ToString(dicose), dt));
            }

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.
            listEstablecimientos.DataSource = new DataView(dt);
            listEstablecimientos.DataTextField = "TextField";
            listEstablecimientos.DataValueField = "ValueField";

            // Bind the data to the control.
            listEstablecimientos.DataBind();

            // Set the default selected item, if desired.
            listEstablecimientos.SelectedIndex = 0;

        }

        DataRow CreateRow(String Text, String Value, DataTable dt)
        {

            // Create a DataRow using the DataTable defined in the 
            // CreateDataSource method.
            DataRow dr = dt.NewRow();

            // This DataRow contains the ColorTextField and ColorValueField 
            // fields, as defined in the CreateDataSource method. Set the 
            // fields with the appropriate value. Remember that column 0 
            // is defined as ColorTextField, and column 1 is defined as 
            // ColorValueField.
            dr[0] = Text;
            dr[1] = Value;

            return dr;
        }


        protected void AltaTratamiento(object sender, EventArgs e)
        {
            IRepoAnimal repo = new RepoAnimal();
            Animal animal = new Animal();
            try
            {
                animal.DICOSE = Convert.ToInt64(listEstablecimientos.SelectedItem.Value);
                animal.ID = Convert.ToInt32(listAnimales.SelectedItem.Value);


             

                repo.Add(animal);
                // Aca deberiamos mostrar algun cuadro de dialogo confirmando la creacion del animal.
                navegarHome();
            }
            catch (Exception)
            {

                Session.Add("error", "No fue posible agregar el animal");
                Response.Redirect("ErrorPages/Error.aspx");
            }
        }
    }
}