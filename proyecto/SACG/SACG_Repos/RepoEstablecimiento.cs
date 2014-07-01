using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SACG_BLL;
using SACG_BLL.IRepos;
using SACG_Mappers;

namespace SACG_Repos
{
    public class RepoEstablecimiento : IRepoEstablecimiento
    {
        public void Add(Establecimiento e)
        {
            EstablecimientoMapper m;
            //VALIDAR
            m = new EstablecimientoMapper(e);
            m.Insertar();
        }

        public void Rem(Establecimiento e)
        {
            EstablecimientoMapper m;
            //VALIDAR
            m = new EstablecimientoMapper(e);
            m.Eliminar();
        }

        public void Upd(Establecimiento e)
        {
            EstablecimientoMapper m;
            //VALIDAR
            m = new EstablecimientoMapper(e);
            m.Modificar();
        }


        //FALTA IMPLEMENTAE FINDERS

       /* public Establecimiento Fnd(Int64 DICOSE)
        {
            EstablecimientoMapper m;

            AdoptameFinders.FinderAnimal f = new AdoptameFinders.FinderAnimal();
            Animal a = f.findById(id);
            return a;
        }

        public List<Animal> FindAll()
        {
            AdoptameFinders.FinderAnimal f = new AdoptameFinders.FinderAnimal();
            return f.findAll();
        }*/


    }
}
