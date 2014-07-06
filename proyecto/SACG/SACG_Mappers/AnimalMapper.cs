using SACG_BLL;
using SACG_DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_Mappers
{
    public class AnimalMapper: AbstractBase
    {
        private Animal animal { get; set; }

        public AnimalMapper(Animal a)
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
                ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {
            animal = a;
        }


        #region PERSISTENCIA

        public void Insertar()
        {

            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pDICOSE = CrearParametro("@DICOSE", animal.DICOSE);
            IDataParameter pSexo = CrearParametro("@SEXO", animal.Sexo);
            IDataParameter pAno = CrearParametro("@ANO", animal.AnoNacimiento);
            IDataParameter pEstacion = CrearParametro("@ESTACION", animal.EstacionNacimiento);
            IDataParameter pRaza = CrearParametro("@RAZA", animal.RazaCruza);

            listaParametros.Add(pDICOSE);
            listaParametros.Add(pSexo);
            listaParametros.Add(pAno);
            listaParametros.Add(pEstacion);
            listaParametros.Add(pRaza);
           

            EjecutarActualizacion(CommandType.StoredProcedure, "spAltaAnimal", listaParametros);
        }

        /*
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

            EjecutarActualizacion(CommandType.StoredProcedure, "spModificarEstablecimiento", listaParametros);
        }

        public void Activar()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pDICOSE = this.CrearParametro("@DICOSE", establecimiento.DICOSE);
            listaParametros.Add(pDICOSE);
            EjecutarActualizacion(CommandType.StoredProcedure, "spActivarEstablecimiento", listaParametros);
        }
        */

        #endregion
    }
}
