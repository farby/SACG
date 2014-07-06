using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SACG_BLL;
using SACG_BLL.IRepos;
using SACG_Mappers;
using SACG_Finders;

namespace SACG_Repos
{
    public class RepoUsuario : IRepoUsuario
    {
        public void Add(Usuario u)
        {
            UsuarioMapper m;
            //VALIDAR
            m = new UsuarioMapper(u);
            m.Insertar();
            m = null;
        }

        public void Rem(Usuario u)
        {
            UsuarioMapper m;
            //VALIDAR
            m = new UsuarioMapper(u);
            m.Eliminar();
        }

        public void Upd(Usuario u)
        {
            UsuarioMapper m;
            //VALIDAR
            m = new UsuarioMapper(u);
            m.Modificar();
        }

        public Usuario Login(String user, String pass)
        {
            //CREO FINDER
            UsuarioFinder f = new UsuarioFinder();
            //BUSCO Y DEVUELVO EL ESTABLECIMIENTO
            Usuario u = f.Login(user, pass);
            return u;
        }
    }
}
