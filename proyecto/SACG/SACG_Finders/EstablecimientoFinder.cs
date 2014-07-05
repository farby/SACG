using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACG_DAL;
using SACG_BLL;
using SACG_Mappers;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SACG_Finders
{
    public class EstablecimientoFinder: AbstractBase
    {
        public EstablecimientoFinder()
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
            ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {
  
        }
    
        public Establecimiento Buscar(Int64 DICOSE)
        {
            List<IDataParameter> listaParametros = new List<IDataParameter>(); 
            IDataParameter pDICOSE = CrearParametro("@DICOSE", DICOSE);
            listaParametros.Add(pDICOSE);
            IDataReader dr = EjecutarReader(CommandType.Text, "Select * from Establecimientos where DICOSE = @DICOSE", listaParametros);

            if (dr != null)
            {
                if (dr.Read())
                {
                    Establecimiento e = new Establecimiento();
                    EstablecimientoMapper m = new EstablecimientoMapper(e);
                    m.load(dr);
                    dr.Close();
                    return e;
                }
            }  
            return null;        
        }

        public List<Int64> Pendientes()
        {
            IDataReader dr = EjecutarReader(CommandType.Text, "Select * from Pendientes");
            List<Int64> listaPendientes;

            if (dr != null)
            {
                listaPendientes = new List<Int64>();
                while (dr.Read())
                {
                    listaPendientes.Add(dr.GetInt64(dr.GetOrdinal("DICOSE")));
                }
                dr.Close();
                return listaPendientes;
            }
            return null;
        }

        public List<Int64> Activos()
        {
            IDataReader dr = EjecutarReader(CommandType.Text, "Select * from Activos");
            List<Int64> listaActivos;

            if (dr != null)
            {
                listaActivos = new List<Int64>();
                while (dr.Read())
                {
                    listaActivos.Add(dr.GetInt64(dr.GetOrdinal("DICOSE")));
                }
                dr.Close();
                return listaActivos;
            }
            return null;
        }
    }
}
