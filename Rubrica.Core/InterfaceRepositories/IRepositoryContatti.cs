using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.InterfaceRepositories
{
    public interface IRepositoryContatti : IRepository<Contatto>
    {
        public List<Contatto> GetAll();
        
        public Contatto GetByCode(int id);

        public bool Delete(int id);
    }
}
