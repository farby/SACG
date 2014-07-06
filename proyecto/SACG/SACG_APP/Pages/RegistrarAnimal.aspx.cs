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
    public partial class RegistrarAnimal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Specify the data source and field names for the Text 
                // and Value properties of the items (ListItem objects) 
                // in the DropDownList control.
               FillGenderList();
               FillStationList();
               FillYearList();
              
            }
        }

        protected void Selection_Change(Object sender, EventArgs e)
        {
           String sexo =  genderList.SelectedItem.Value;
           String estacion = stationList.SelectedItem.Value;

        }

        protected void cancel(Object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void FillGenderList()
        {

            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(Char)));

            // Populate the table with sample values.
            dt.Rows.Add(CreateRow("Macho", "M", dt));
            dt.Rows.Add(CreateRow("Hembra", "H", dt));

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.

            genderList.DataSource = new DataView(dt);
            genderList.DataTextField = "TextField";
            genderList.DataValueField = "ValueField";

            // Bind the data to the control.
            genderList.DataBind();

            // Set the default selected item, if desired.
            genderList.SelectedIndex = 0;


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
            for (year = 1980; year <= actualYear; year++) {
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

        protected void FillStationList()
        {

            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(Char)));

            // Populate the table with sample values.
            dt.Rows.Add(CreateRow("Verano", "V", dt));
            dt.Rows.Add(CreateRow("Otonio", "O", dt));
            dt.Rows.Add(CreateRow("Invierno", "I", dt));
            dt.Rows.Add(CreateRow("Primavera", "P", dt));

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.
            stationList.DataSource = new DataView(dt);
            stationList.DataTextField = "TextField";
            stationList.DataValueField = "ValueField";

            // Bind the data to the control.
            stationList.DataBind();

            // Set the default selected item, if desired.
            stationList.SelectedIndex = 0;

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

        protected void AltaAnimal(object sender, EventArgs e)
        {

            IRepoAnimal repo = new RepoAnimal();
            Animal animal = new Animal();
            try
            {
                //CREO EL ESTABLECIMIENTO
                animal.DICOSE = Convert.ToInt64(txtDicose.Text);

                animal.Sexo = Convert.ToChar(genderList.SelectedItem.Value);
                animal.AnoNacimiento = Convert.ToInt32(yearList.SelectedItem.Value);
                animal.EstacionNacimiento = Convert.ToChar(stationList.SelectedItem.Value);
                animal.RazaCruza = txtRaza.Text;
    
                //AGREGO EL ESTABLECIMIENTO Y SU RESPONSABLE
                repo.Add(animal);
            }
            catch
            {
                throw;
            }
        }
    }
}