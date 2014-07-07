using SACG_BLL.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACG_Mappers;
using SACG_Finders;
using SACG_BLL;

namespace SACG_Repos
{
    public class RepoEvento : IRepoEvento
    {

        public void Add(Evento obj)
        {
            try
            {
                EventoMapper mapper = new EventoMapper(obj);
                mapper.Insertar();
                mapper = null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddTransaction(Evento obj)
        {
            try
            {
                EventoMapper mapper = new EventoMapper(obj);
                mapper.InsertarTransaccion();
                mapper = null;
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Buscar tipos de Eventos
        public List<TipoEvento> getTipoEventosPorTipo(String tipo)
        {
            TipoEventoFinder finder = new TipoEventoFinder();
            return finder.buscarTipoEventosPorCategoria(tipo);

        }
    }
}
