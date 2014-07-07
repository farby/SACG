using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL.IRepos
{
    public interface IRepoEvento
    {
        void Add(Evento obj);
        void AddTransaction(Evento obj);
        List<TipoEvento> getTipoEventosPorTipo(String tipo);
    }
}
