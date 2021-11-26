using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMock
{
    public class RepositoryMockIndirizzi : IRepositoryIndirizzi
    {
        // metto una lista di indirizzi, che è il mio finto repository

        public static List<Indirizzo> indirizzi = new List<Indirizzo>();
        public Indirizzo Add(Indirizzo item)
        {
            if (indirizzi.Count == 0)
            {
                item.IdIndirizzo = 1;
            }
            else
            {
                int max = 1;
                foreach (var i in indirizzi)
                {
                    if (i.IdIndirizzo > max)
                    {
                        max = i.IdIndirizzo;
                    }
                }
                item.IdIndirizzo = max + 1;
            }
            indirizzi.Add(item);
            return item;
        }

        public bool IsThereAdress(int id)
        {
            foreach (var item in indirizzi)
            {
                if(item.IdContatto == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
