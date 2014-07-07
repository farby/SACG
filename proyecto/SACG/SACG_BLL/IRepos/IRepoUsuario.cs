using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL.IRepos
{
    public interface IRepoUsuario
    {
        void Add(Usuario u);
        void Rem(Usuario u);
        void Pas(Usuario u);
        Usuario Login(String user, String pass);
    }
}