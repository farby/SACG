using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SACG_BLL.IRepos;
using SACG_Mappers;

namespace SACG_Repos
{
    public class RepoAnimal : IRepoAnimal
    {
        public void Add(SACG_BLL.Animal a)
        {
            AnimalMapper mapper = new AnimalMapper(a);
            mapper.Insertar();
            //
            mapper = null;
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
            throw new NotImplementedException();
        }

        public SACG_BLL.Animal find(long dicose)
        {
            throw new NotImplementedException();
        }
    }
}
