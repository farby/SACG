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
    public class RepoEstablecimiento : IRepoEstablecimiento
    {
        public void Add(Establecimiento e, Persona p)
        {
            EstablecimientoMapper m;
            //VALIDAR
            m = new EstablecimientoMapper(e, p);
            m.Insertar();
            m = null;
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

        public void Act(Establecimiento e)
        {
            EstablecimientoMapper m;
            m = new EstablecimientoMapper(e);
            m.Activar();
        }

        public void Res(Establecimiento e)
        {
            EstablecimientoMapper m;
            m = new EstablecimientoMapper(e);
            m.Responsable();
        }

        public Establecimiento Fnd(Int64 DICOSE)
        {
            //CREO FINDER
            EstablecimientoFinder f = new EstablecimientoFinder();
            //BUSCO Y DEVUELVO EL ESTABLECIMIENTO
            Establecimiento e = f.Buscar(DICOSE);
            return e;
        }

        public List<Int64> Sby()
        {
            //CREO FINDER
            EstablecimientoFinder f = new EstablecimientoFinder();
            return f.Pendientes();
        }

        //Retorna la lista de Establecimientos activos.
        public List<Int64> All()
        {
            //CREO FINDER
            EstablecimientoFinder f = new EstablecimientoFinder();
            return f.Activos();
        }


    }
}
