using SACG_BLL;
using SACG_DAL;
using SACG_Mappers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_Finders
{
    public class TipoEventoFinder : AbstractBase
    {
        public TipoEventoFinder()
            : base(FabricaObjetosConectados.Proveedores.SqlServer,
                ConfigurationManager.ConnectionStrings["conexionSACG"].ConnectionString)
        {

        }



        //Buscar Animales de un Establecimiento
        public List<TipoEvento> buscarTipoEventosPorCategoria(String tipo)
        {
            List<TipoEvento> tipos = null;
            List<IDataParameter> listaParametros = new List<IDataParameter>();
            IDataParameter pTipo = CrearParametro("@TIPO", tipo);
            listaParametros.Add(pTipo);
            IDataReader dr = EjecutarReader(CommandType.Text,
                "select * from TipoEventos where TIPO = @TIPO",
                listaParametros);

            if (dr != null)
            {
                tipos = new List<TipoEvento>();
                while (dr.Read())
                {
                    TipoEvento obj = new TipoEvento();
                    TipoEventoMapper mapper = new TipoEventoMapper(obj);
                    mapper.load(dr);
                    tipos.Add(obj);
                }
                dr.Close();
            }
            return tipos;
        }
    }
}
