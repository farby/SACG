using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACG_DAL;
using SACG_BLL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SACG_Mappers
{
    public class EstablecimientoMapper: AbstractBase
    {
        private Establecimiento establecimiento { get; set; }
        private Persona persona { get; set; }

        public EstablecimientoMapper(Establecimiento e)
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
            ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {
            establecimiento = e;
        }

        public EstablecimientoMapper(Establecimiento e, Persona p)
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
            ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {
            establecimiento = e;
            persona = p;
        }

        #region PERSISTENCIA

        public void Insertar()
        {

            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pDICOSE = CrearParametro("@DICOSE", establecimiento.DICOSE);
            IDataParameter pRUT = CrearParametro("@RUT", establecimiento.RUT);
            IDataParameter pBPS = CrearParametro("@BPS", establecimiento.BPS);
            IDataParameter pRazonSocial = CrearParametro("@RazonSocial", establecimiento.RazonSocial);
            IDataParameter pResponsable = CrearParametro("@Responsable", establecimiento.Responsable);
            IDataParameter pDepartamento = CrearParametro("@Departamento", establecimiento.Departamento);
            IDataParameter pSPolicial = CrearParametro("@SeccionalPolicial", establecimiento.SeccionalPolicial);
            IDataParameter pParaje = CrearParametro("@Paraje", establecimiento.Paraje);
            IDataParameter pDireccion = CrearParametro("@Direccion", establecimiento.Direccion);
            IDataParameter pTelefono = CrearParametro("@Telefono", establecimiento.Telefono);
            IDataParameter pEmail = CrearParametro("@Email", establecimiento.Email);
            IDataParameter pSuperficie = CrearParametro("@Superficie", establecimiento.Superficie);

            IDataParameter pNombre = CrearParametro("@Nombre", persona.Nombre);
            IDataParameter pApellido = CrearParametro("@Apellido", persona.Apellido);

            listaParametros.Add(pDICOSE);
            listaParametros.Add(pRUT);
            listaParametros.Add(pBPS);
            listaParametros.Add(pRazonSocial);
            listaParametros.Add(pResponsable);
            listaParametros.Add(pDepartamento);
            listaParametros.Add(pSPolicial);
            listaParametros.Add(pParaje);
            listaParametros.Add(pDireccion);
            listaParametros.Add(pTelefono);
            listaParametros.Add(pEmail);
            listaParametros.Add(pSuperficie);

            listaParametros.Add(pNombre);
            listaParametros.Add(pApellido);

            EjecutarActualizacion(CommandType.StoredProcedure, "spAltaEstablecimiento", listaParametros);
        }

        public void Eliminar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            listaParametros.Add(pDICOSE);
            EjecutarActualizacion(CommandType.StoredProcedure, "spBajaEstablecimiento", listaParametros);
        }

        public void Modificar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            IDataParameter pRUT = this.CrearParametro("@RUT", establecimiento.RUT);
            IDataParameter pBPS = this.CrearParametro("@BPS", establecimiento.BPS);
            IDataParameter pRazonSocial = this.CrearParametro("@RazonSocial", establecimiento.RazonSocial);
            IDataParameter pDepartamento = this.CrearParametro("@Departamento", establecimiento.Departamento);
            IDataParameter pSPolicial = this.CrearParametro("@SeccionalPolicial", establecimiento.SeccionalPolicial);
            IDataParameter pParaje = this.CrearParametro("@Paraje", establecimiento.Paraje);
            IDataParameter pDireccion = this.CrearParametro("@Direccion", establecimiento.Direccion);
            IDataParameter pTelefono = this.CrearParametro("@Telefono", establecimiento.Telefono);
            IDataParameter pEmail = this.CrearParametro("@Email", establecimiento.Email);
            IDataParameter pSuperficie = this.CrearParametro("@Superficie", establecimiento.Superficie);

            listaParametros.Add(pDICOSE);
            listaParametros.Add(pRUT);
            listaParametros.Add(pBPS);
            listaParametros.Add(pRazonSocial);
            listaParametros.Add(pDepartamento);
            listaParametros.Add(pSPolicial);
            listaParametros.Add(pParaje);
            listaParametros.Add(pDireccion);
            listaParametros.Add(pTelefono);
            listaParametros.Add(pEmail);
            listaParametros.Add(pSuperficie);

            EjecutarActualizacion(CommandType.StoredProcedure, "spModificarEstablecimiento", listaParametros);
        }

        public void Activar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            listaParametros.Add(pDICOSE);
            EjecutarActualizacion(CommandType.StoredProcedure, "spActivarEstablecimiento", listaParametros);
        }

        public void Responsable()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            IDataParameter pResponsable = this.CrearParametro("@Responsable", establecimiento.Responsable);
            listaParametros.Add(pDICOSE);
            listaParametros.Add(pResponsable);
            EjecutarActualizacion(CommandType.StoredProcedure, "spResponsableEstablecimiento", listaParametros);
        }

        #endregion

        public void load(IDataRecord dr)
        {
            if (establecimiento != null)
            {
                establecimiento.DICOSE = dr.GetInt64(dr.GetOrdinal("DICOSE"));
                establecimiento.RUT = dr.GetInt64(dr.GetOrdinal("RUT"));
                establecimiento.BPS = dr.GetInt64(dr.GetOrdinal("BPS"));
                establecimiento.RazonSocial = dr.GetString(dr.GetOrdinal("RazonSocial"));
                establecimiento.Responsable = dr.GetInt32(dr.GetOrdinal("Responsable"));
                establecimiento.Departamento = dr.GetString(dr.GetOrdinal("Departamento"));
                establecimiento.SeccionalPolicial = dr.GetInt32(dr.GetOrdinal("SeccionPolicial"));
                establecimiento.Paraje = dr.GetString(dr.GetOrdinal("Paraje"));
                establecimiento.Direccion = dr.GetString(dr.GetOrdinal("Direccion"));
                establecimiento.Telefono = dr.GetString(dr.GetOrdinal("Telefono"));
                establecimiento.Email = dr.GetString(dr.GetOrdinal("Email"));
                establecimiento.Superficie = dr.GetInt32(dr.GetOrdinal("Superficie"));
            }
        }
    }
}
