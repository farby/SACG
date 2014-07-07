using SACG_BLL;
using SACG_BLL.IRepos;
using SACG_Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SACG_APP.Pages
{
    public partial class CompraVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDicoseList();
                FillTreatmentList();
            }
        }

        protected void Selection_Change(Object sender, EventArgs e)
        {
            removeDicoseDestino();
            FillAnimalList(null);
        }


        protected void cancel(Object sender, EventArgs e)
        {
            navegarHome();
        }

        // Navega a la home de la aplicacion.
        private void navegarHome() { Response.Redirect("home.aspx"); }


        #region Lists


        protected void removeDicoseDestino() 
        {

            IRepoEstablecimiento repoEst = new RepoEstablecimiento();
            List<Int64> activos = repoEst.All();
            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(String)));

            Int64 dicoseVendedor = Convert.ToInt64(listEstablecimientos.SelectedItem.Value);
            foreach (Int64 dicose in activos)
            {
                // Populate the table with sample values.
                if (dicoseVendedor != dicose)
                {
                     dt.Rows.Add(CreateRow(Convert.ToString(dicose), Convert.ToString(dicose), dt));
                }
               
            }

            listEstablecimientosDestino.DataSource = new DataView(dt);
            listEstablecimientosDestino.DataTextField = "TextField";
            listEstablecimientosDestino.DataValueField = "ValueField";

            // Bind the data to the control.
            listEstablecimientosDestino.DataBind();

            // Set the default selected item, if desired.
            listEstablecimientosDestino.SelectedIndex = 0;

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

        protected void FillTreatmentList()
        {

            // Create a table to store data for the DropDownList control.
            DataTable dt = new DataTable();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("TextField", typeof(String)));
            dt.Columns.Add(new DataColumn("ValueField", typeof(String)));

            IRepoEvento repo = new RepoEvento();
            List<TipoEvento> tipos = repo.getTipoEventosPorTipo("COMPRAVENTA");

            // Populate the table with sample values.
            dt.Rows.Add(CreateRow("", "", dt));

            foreach (TipoEvento tipo in tipos)
            {
                dt.Rows.Add(CreateRow(tipo.Nombre, tipo.Nombre, dt));
            }

            // Create a DataView from the DataTable to act as the data source
            // for the DropDownList control.

            listOperacion.DataSource = new DataView(dt);
            listOperacion.DataTextField = "TextField";
            listOperacion.DataValueField = "ValueField";

            // Bind the data to the control.
            listOperacion.DataBind();

            // Set the default selected item, if desired.
            listOperacion.SelectedIndex = 0;


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
            listAnimales.SelectedIndex = 0;

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



        protected void RealizarTransaccion(object sender, EventArgs e)
        {
            IRepoEvento repo = new RepoEvento();
            Animal animal = new Animal();
            Evento evento = new Evento();
            try
            {
                evento.idAnimal = Convert.ToInt32(listAnimales.SelectedItem.Value);
                evento.DicoseOrg = Convert.ToInt64(listEstablecimientos.SelectedItem.Value);
                evento.DicoseDest = Convert.ToInt64(listEstablecimientosDestino.SelectedItem.Value);
                evento.Fecha = Calendar2.SelectedDate;
                evento.Observaciones = txtObs.Text;

                String option = listOperacion.SelectedItem.Value;
                if (option.Equals("COMPRA"))
                {
                   
                    evento.Nombre = "COMPRA";
                    evento.Tipo = evento.Nombre;
                   
                }
                else 
                {
                    evento.Nombre = "VENTA";
                    evento.Tipo = evento.Nombre;
                }
                repo.AddTransaction(evento);
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