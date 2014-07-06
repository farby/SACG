using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL.IRepos
{
    public interface IRepoUsuario
    {
        void Add(Usuario e);
        void Rem(Usuario e);
        void Upd(Usuario e);
        Usuario Login(String user, String pass);
    }
}