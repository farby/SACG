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
                FillDicoseList();
                // Escondo todas las rows.
                trRow1.Visible = false;
                trRow2.Visible = false;
                trRow3.Visible = false;
                trRow4.Visible = false;
                trRow5.Visible = false;
                trRow6.Visible = false;
            }
        }

        protected void Selection_Change(Object sender, EventArgs e)
        {
            FillAnimalList(null); // Solo con los animales vivos.
        }

        protected void treatment_change(Object sender, EventArgs e)
        {
            String option = listTratamiento.SelectedItem.Value;
            if (option.Equals("MUERTE"))
            {
                trRow1.Visible = true;
                trRow2.Visible = false;
                trRow3.Visible = false;
                trRow4.Visible = false;
                trRow5.Visible = false;
                trRow6.Visible = false;
                FillAnimalList(null); // Solo con los animales vivos.
            }
            else if (option.Equals("PESAJE"))
            { 
                trRow1.Visible = false;
                trRow2.Visible = true;
                trRow3.Visible = false;
                trRow4.Visible = false;
                trRow5.Visible = false;
                trRow6.Visible = false;
                FillAnimalList(null); // Solo con los animales vivos.
            }
            else if (option.Equals("VACUNAS"))
            {
                trRow1.Visible = false;
                trRow2.Visible = false;
                trRow3.Visible = true;
                trRow4.Visible = false;
                trRow5.Visible = false;
                trRow6.Visible = false;
                FillAnimalList(null); // Solo con los animales vivos.
            }
            else if (option.Equals("TRATAMIENTOS"))
            {
                trRow1.Visible = false;
                trRow2.Visible = false;
                trRow3.Visible = false;
                trRow4.Visible = true;
                trRow5.Visible = false;
                trRow6.Visible = false;
                FillAnimalList(null); // Solo con los animales vivos.
            }
            else if (option.Equals("PRENIA"))
            {
                trRow1.Visible = false;
                trRow2.Visible = false;
                trRow3.Visible = false;
                trRow4.Visible = false;
                trRow5.Visible = true;
                trRow6.Visible = false;
                FillAnimalList("H"); // Solo con los animales vivos.
            }
            else
            {
                trRow1.Visible = false;
                trRow2.Visible = false;
                trRow3.Visible = false;
                trRow4.Visible = false;
                trRow5.Visible = false;
                trRow6.Visible = true;
                FillAnimalList("H"); // Solo con los animales vivos.
            }
        }

        protected void cancel(Object sender, EventArgs e)
        {
            navegarHome();
        }

        // Navega a la home de la aplicacion.
        private void navegarHome() { Response.Redirect("home.aspx"); }


        #region Listas
        protected void FillTreatmentList()
        {

            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(String)));

            IRepoEvento repo = new RepoEvento();
            List<TipoEvento> tipos = repo.getTipoEventosPorTipo("SANITARIO");

            // Populate the table with sample values.
            dt.Rows.Add(CreateRow("", "", dt));

            foreach (TipoEvento tipo in tipos)
            {
                dt.Rows.Add(CreateRow(tipo.Nombre, tipo.Nombre, dt));
            }

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

        protected void FillAnimalList(string sexo)
        {
            Int64 dicose = Convert.ToInt64(listEstablecimientos.SelectedItem.Value);

            IRepoAnimal repo = new RepoAnimal();
            List<Animal> animales = repo.getAllByEst(dicose, sexo);
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
            //listAnimales.SelectedIndex = 0;

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
        #endregion

        protected void AltaTratamiento(object sender, EventArgs e)
        {
            IRepoEvento repo = new RepoEvento();
            Animal animal = new Animal();
            Evento evento = new Evento();

            
            try
            {
                evento.idAnimal = Convert.ToInt32(listAnimales.SelectedItem.Value);
                evento.DicoseOrg = Convert.ToInt64(listEstablecimientos.SelectedItem.Value);

                String option = listTratamiento.SelectedItem.Value;
                if (option.Equals("MUERTE"))
                {
                    evento.Fecha = Calendar1.SelectedDate;
                    evento.Nombre = "Muerte";
                    evento.Tipo = evento.Nombre;
                    evento.Observaciones = "";
                }
                else if (option.Equals("PESAJE"))
                {
                    evento.Fecha = Calendar2.SelectedDate;
                    evento.Nombre = "Pesaje";
                    evento.Tipo = evento.Nombre;
                    evento.Observaciones = txtKilos.Text;
                }
                else if (option.Equals("VACUNAS"))
                {
                    evento.Fecha = DateTime.Now;
                    evento.Nombre = txtNombreVacuna.Text;
                    evento.Tipo = "VACUNAS";
                    evento.Observaciones = txtDosisVacuna.Text;
                }
                else if (option.Equals("TRATAMIENTO"))
                {
                    evento.Fecha = DateTime.Now;
                    evento.Nombre = txtNomTratamiento.Text;
                    evento.Tipo = "TRATAMIENTO";
                    evento.Observaciones = txtAplicacionTratamiento.Text;
                }
                else if (option.Equals("PRENIA"))
                {
                    evento.Fecha = Calendar3.SelectedDate;
                    evento.Nombre = "PRENIA";
                    evento.Tipo = "PRENIA";
                    evento.Observaciones = txtPrenia.Text;
                }
                else
                {
                    evento.Fecha = Calendar4.SelectedDate;
                    evento.Nombre = "NACIMIENTOS";
                    evento.Tipo = "NACIMIENTOS";
                    evento.Observaciones = txtParto.Text;
                }
 

                repo.Add(evento);
               
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