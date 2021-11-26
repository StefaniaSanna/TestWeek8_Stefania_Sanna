using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.InterfaceRepositories
{
    public interface IRepositoryIndirizzi: IRepository<Indirizzo>
    {
        public bool IsThereAdress(int id);
    }
}
