using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMock
{
    public class RepositoryMockContatti : IRepositoryContatti
    {
        public static List<Contatto> contatti = new List<Contatto>();
      
        public Contatto Add(Contatto item)
        {
            if (contatti.Count == 0)
            {
                item.IdContatto = 1;
            }
            else
            {
                int max = 1;
                foreach (var i in contatti)
                {
                    if (i.IdContatto > max)
                    {
                        max = i.IdContatto;
                    }
                }
                item.IdContatto = max + 1;
            }
            contatti.Add(item);
            return item;
        }
       
        public bool Delete(int id) 
        {
            foreach (var item in contatti)
            {
                if( item.IdContatto == id)
                {
                    contatti.Remove(item);
                    return true;
                }
            }
            return false;           
        }

        public List<Contatto> GetAll() 
        {
            return contatti;
        }

        public Contatto GetByCode(int id) 
        {
            foreach (var item in contatti)
            {
                if (item.IdContatto == id) 
                {
                    return item;
                }
            }
            return null;
        }
    }
}
