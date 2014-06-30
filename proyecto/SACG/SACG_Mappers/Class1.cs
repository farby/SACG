using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACG_DAL;
using SACG_BLL;
using System.Data;
using System.Configuration;

namespace SACG_Mappers
{
    public class EstablecimientoMapper: AbstractBase
    {
        private Establecimiento est { get; set; }

        public EstablecimientoMapper(Establecimiento e)
            :base(FabricaObjetosConectados.Proveedores.SqlServer,
            System.Configuration.config
    }
}


namespace AdoptameMappers
{
    public class AnimalMapper : AbstractBase
    {

        private Animal animal { get; set; }

        public AnimalMapper(Animal a)
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
                System.Configuration.ConfigurationManager.ConnectionStrings["conexionAdoptame"].ConnectionString)
        {
            this.animal = a;
        }

        #region Métodos de persistencia
        public void Insertar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter paramNombre = this.CrearParametro("@nombre", animal.Nombre);
            IDataParameter paramFecha = this.CrearParametro("@fechaNacimiento", animal.FechaNacimiento);
            IDataParameter paramAdoptado = this.CrearParametro("@adoptado", animal.Adoptado);
            paramAdoptado.DbType = DbType.Boolean;
            IDataParameter paramIdDuenio = this.CrearParametro("@idDuenio", (animal.duenio == null) ? DBNull.Value : (object)animal.duenio.Id);
            listaParametros.Add(paramNombre);
            listaParametros.Add(paramFecha);
            listaParametros.Add(paramAdoptado);
            listaParametros.Add(paramIdDuenio);
            this.EjecutarActualización(CommandType.StoredProcedure, "spu_InsertarAnimal", listaParametros);
        }
        public void Eliminar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter paramID = this.CrearParametro("@id", animal.Id);
            listaParametros.Add(paramID);
            this.EjecutarActualización(CommandType.StoredProcedure, "spu_EliminarAnimal", listaParametros);
        }
        public void Modificar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter paramNombre = this.CrearParametro("@nombre", animal.Nombre);
            IDataParameter paramFecha = this.CrearParametro("@fechaNacimiento", animal.FechaNacimiento);
            IDataParameter paramAdoptado = this.CrearParametro("@adoptado", animal.Adoptado);
            paramAdoptado.DbType = DbType.Boolean;
            IDataParameter paramID = this.CrearParametro("@id", animal.Id);
            listaParametros.Add(paramID);
            listaParametros.Add(paramNombre);
            listaParametros.Add(paramFecha);
            listaParametros.Add(paramAdoptado);
            this.EjecutarActualización(CommandType.StoredProcedure, "spu_ModificarAnimal", listaParametros);
        }

        #endregion

        public void load( IDataRecord dr)
        {
            
            if (animal != null)
            {
                animal.Nombre = dr.GetString(dr.GetOrdinal("nombre"));
                animal.Id = dr.GetInt32(dr.GetOrdinal("id"));
                animal.FechaNacimiento = dr.GetDateTime(dr.GetOrdinal("fechaNacimiento"));
                animal.Adoptado = dr.GetBoolean(dr.GetOrdinal("adoptado"));
                int idDuenio = (dr["idDuenio"] == System.DBNull.Value) ? 0 : (int)dr["idDuenio"];

                // Ya que se accedió a la BD para obtener el animal, y esta incluye el Id de dueño, se deja
                //preparada la referencia para cargarse cuando se requiera.
                {
                    Persona duenio = new Persona();
                    duenio.Id = idDuenio;
                }
            }
        }
    }
}
