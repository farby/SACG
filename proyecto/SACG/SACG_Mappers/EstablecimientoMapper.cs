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
        private Establecimiento establecimiento { get; set; }

        public EstablecimientoMapper(Establecimiento e)
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
            System.Configuration.ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {
            this.establecimiento = e;
        }

        #region PERSISTENCIA

        public void Insertar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            IDataParameter pRUT = this.CrearParametro("@RUT", establecimiento.RUT);
            IDataParameter pBPS = this.CrearParametro("@BPS", establecimiento.BPS);
            IDataParameter pRazonSocial = this.CrearParametro("@RazonSocial", establecimiento.RazonSocial);
            IDataParameter pResponsable = this.CrearParametro("@Responsable", establecimiento.Responsable);
            IDataParameter pDepartamento = this.CrearParametro("@Departamento", establecimiento.Departamento);
            IDataParameter pSPolicial = this.CrearParametro("@SeccionalPolicial", establecimiento.SeccionalPolicial);
            IDataParameter pParaje = this.CrearParametro("@Paraje", establecimiento.Paraje);
            IDataParameter pDireccion = this.CrearParametro("@Direccion", establecimiento.Direccion);
            IDataParameter pTelefono = this.CrearParametro("@Telefono", establecimiento.Telefono);
            IDataParameter pEmail = this.CrearParametro("@Email", establecimiento.Email);
            IDataParameter pSuperficie = this.CrearParametro("@Superficie", establecimiento.Superficie);
            IDataParameter pEstado = this.CrearParametro("@Estado", "Pendiente");

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
            listaParametros.Add(pEstado);

            this.EjecutarActualización(CommandType.StoredProcedure, "spInsertarEstablecimiento", listaParametros);
        }

        public void Eliminar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            listaParametros.Add(pDICOSE);
            this.EjecutarActualización(CommandType.StoredProcedure, "spEliminarEstablecimiento", listaParametros);
        }

        public void Modificar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            IDataParameter pRUT = this.CrearParametro("@RUT", establecimiento.RUT);
            IDataParameter pBPS = this.CrearParametro("@BPS", establecimiento.BPS);
            IDataParameter pRazonSocial = this.CrearParametro("@RazonSocial", establecimiento.RazonSocial);
            IDataParameter pResponsable = this.CrearParametro("@Responsable", establecimiento.Responsable);
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
            listaParametros.Add(pResponsable);
            listaParametros.Add(pDepartamento);
            listaParametros.Add(pSPolicial);
            listaParametros.Add(pParaje);
            listaParametros.Add(pDireccion);
            listaParametros.Add(pTelefono);
            listaParametros.Add(pEmail);
            listaParametros.Add(pSuperficie);

            this.EjecutarActualización(CommandType.StoredProcedure, "spModificarEstablecimiento", listaParametros);
        }

        public void Activar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            IDataParameter pEstado = this.CrearParametro("@RUT", "Activo");

            listaParametros.Add(pDICOSE);
            listaParametros.Add(pEstado);

            this.EjecutarActualización(CommandType.StoredProcedure, "spCambiarEstadoEstablecimiento", listaParametros);
        }

        public void Inactivar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            IDataParameter pEstado = this.CrearParametro("@RUT", "Inactivo");

            listaParametros.Add(pDICOSE);
            listaParametros.Add(pEstado);

            this.EjecutarActualización(CommandType.StoredProcedure, "spCambiarEstadoEstablecimiento", listaParametros);
        }

        #endregion

        public void load(IDataRecord dr)
        {

            if (establecimiento != null)
            {
                establecimiento.DICOSE = dr.GetInt64(dr.GetOrdinal("DICOSE"));
                //faltan agregar los otros atts
            }
        }
    }
}
