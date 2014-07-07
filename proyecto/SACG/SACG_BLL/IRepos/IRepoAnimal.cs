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
        List<Animal> sinPesar(DateTime fecha);
        List<String> Pesajes(Int32 id);
        List<Int32> getAll();
        List<Animal> getAllByEst(Int64 idEstablecimiento, String sexo);
        Animal find(Int64 dicose);

    }
}
