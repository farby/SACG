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
    public class EventoMapper : AbstractBase
    {
        private Evento evento { get; set; }

        public EventoMapper(Evento obj)
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
                ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        { 
            evento = obj; 
        }


        #region PERSISTENCIA

        public void Insertar()
        {

            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pTipo = CrearParametro("@TIPO", evento.Tipo);
            IDataParameter pNombre = CrearParametro("@NOMBRE", evento.Nombre);
            IDataParameter pFecha = CrearParametro("@FECHA", evento.Fecha);
            IDataParameter pObs = CrearParametro("@OBSERVACIONES", evento.Observaciones);
            IDataParameter pEstOrigen = CrearParametro("@DICOSEORIGEN", evento.DicoseOrg);
            IDataParameter pAnimal = CrearParametro("@ANIMAL", evento.idAnimal);

            listaParametros.Add(pTipo);
            listaParametros.Add(pNombre);
            listaParametros.Add(pFecha);
            listaParametros.Add(pObs);
            listaParametros.Add(pEstOrigen);
            listaParametros.Add(pAnimal);

            try
            {
                    EjecutarActualizacion(CommandType.StoredProcedure, "spAgregarEvento", listaParametros);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void InsertarTransaccion()
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>();

            IDataParameter pTipo = CrearParametro("@TIPO", evento.Tipo);
            IDataParameter pNombre = CrearParametro("@NOMBRE", evento.Nombre);
            IDataParameter pFecha = CrearParametro("@FECHA", evento.Fecha);
            IDataParameter pEstOrigen = CrearParametro("@DICOSEORIGEN", evento.DicoseOrg);
            IDataParameter pEstDestino = CrearParametro("@DICOSEDESTINO", evento.DicoseDest);
            IDataParameter pObs = CrearParametro("@OBSERVACIONES", evento.Observaciones);
            IDataParameter pAnimal = CrearParametro("@ANIMAL", evento.idAnimal);

            listaParametros.Add(pTipo);
            listaParametros.Add(pNombre);
            listaParametros.Add(pFecha);
            listaParametros.Add(pObs);
            listaParametros.Add(pEstOrigen);
            listaParametros.Add(pEstDestino);
            listaParametros.Add(pAnimal);

            try
            {
                EjecutarActualizacion(CommandType.StoredProcedure, "spAgregarTransferencia", listaParametros);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        public void load(IDataRecord dr)
        {
            if (evento != null)
            {
                evento.Tipo = dr.GetString(dr.GetOrdinal("TIPO"));
                evento.Nombre = dr.GetString(dr.GetOrdinal("NOMBRE"));
                evento.Fecha = dr.GetDateTime(dr.GetOrdinal("FECHA"));
                evento.Observaciones = dr.GetString(dr.GetOrdinal("OBSERVACIONES"));
                evento.DicoseOrg = dr.GetInt64(dr.GetOrdinal("DICOSEORIGEN"));
                evento.DicoseDest = dr.GetInt64(dr.GetOrdinal("DICOSEDESTINO"));
                evento.idAnimal = dr.GetInt64(dr.GetOrdinal("ANIMAL"));
                evento.ID = dr.GetInt32(dr.GetOrdinal("ID"));
            }
        }


    }
}
