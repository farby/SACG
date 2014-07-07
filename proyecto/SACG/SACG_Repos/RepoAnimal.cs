using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACG_BLL.IRepos;
using SACG_Mappers;
using SACG_Finders;

namespace SACG_Repos
{
    public class RepoAnimal : IRepoAnimal
    {
        public void Add(SACG_BLL.Animal a)
        {
            try
            {
                AnimalMapper mapper = new AnimalMapper(a);
                mapper.Insertar();
                mapper = null;
            }
            catch (Exception)
            {
                
                throw;
            }


        }

        public void Update(SACG_BLL.Animal a)
        {
            throw new NotImplementedException();
        }

        public void Delete(SACG_BLL.Animal a)
        {
            throw new NotImplementedException();
        }

        public List<SACG_BLL.Animal> getAll()
        {
            throw new NotImplementedException();
        }

        public List<SACG_BLL.Animal> getAllByEst(long idEstablecimiento)
        {
            AnimalFinder finder = new AnimalFinder();
            return finder.buscarAnimales(idEstablecimiento);
        }

        public SACG_BLL.Animal find(long dicose)
        {
            throw new NotImplementedException();
        }
    }
}
