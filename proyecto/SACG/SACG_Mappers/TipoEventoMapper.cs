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
    public class TipoEventoMapper: AbstractBase
    {
        private TipoEvento tEvento {get; set;}

        public TipoEventoMapper(TipoEvento obj)
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
                ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {
            tEvento = obj;
        }

        public void load(IDataRecord dr)
        {
            if (tEvento != null)
            {
                tEvento.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                tEvento.Tipo = dr.GetString(dr.GetOrdinal("TIPO"));
                tEvento.Nombre = dr.GetString(dr.GetOrdinal("NOMBRE"));
            }
        }
    }
}
