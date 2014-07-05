using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL.IRepos
{
    public interface IRepoEstablecimiento
    {
        void Add(Establecimiento e, Persona p);
        void Rem(Establecimiento e);
        void Upd(Establecimiento e, Persona p);
        void Act(Establecimiento e);
        Establecimiento Fnd(Int64 DICOSE);
        List<Int64> Sby();
        List<Int64> All();
    }
}