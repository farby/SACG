using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL.IRepos
{
    public interface IRepoEstablecimiento
    {
        void Add(Establecimiento e);
        void Rem(Establecimiento e);
        void Upd(Establecimiento e);
        //Establecimiento Fnd(Int64 DICOSE);
        //List<Establecimiento> All();
    }
}