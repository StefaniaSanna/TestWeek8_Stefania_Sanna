using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.InterfaceRepositories
{
    public interface IRepository<T>
    {
        //metto l'unico metodo comune
        public T Add(T item);
        

    }
}
