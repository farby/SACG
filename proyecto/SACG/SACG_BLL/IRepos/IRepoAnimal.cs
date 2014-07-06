using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SACG_BLL.IRepos
{
    public interface IRepoAnimal
    {
        void Add(Animal a);
        void Update(Animal a);
        void Delete(Animal a);
        List<Animal> getAll();
        List<Animal> getAllByEst(Int64 idEstablecimiento);
        Animal find(Int64 dicose);
    }
}
