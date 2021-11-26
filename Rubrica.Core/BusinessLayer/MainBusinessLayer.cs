using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryContatti contattiRepo; 
        private readonly IRepositoryIndirizzi indirizziRepo; 

        public MainBusinessLayer(IRepositoryContatti contatti, IRepositoryIndirizzi indirizzi) //questo è un costruttore
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }
        public Esito AddAdress(Indirizzo i)
        {
            Contatto contattoEsistente = contattiRepo.GetByCode(i.IdContatto);
            if(contattoEsistente!= null)
            {
                indirizziRepo.Add(i);
                return new Esito { Messaggio = "Indirizzo aggiunto correttamente", IsOk = true };
            }
            return new Esito { Messaggio = "Non è possibile aggiungere l'indirizzo perchè non è presente nessun contatto associato all'ID", IsOk = false };

        }

        public Esito AddContact(Contatto c)
        {
            contattiRepo.Add(c);
            return new Esito { Messaggio = "Contatto aggiunto correttamente", IsOk = true };
        }

        public Esito DeleteContact(int id)
        {
            Contatto contattoEsistente = contattiRepo.GetByCode(id);
            if (contattoEsistente != null)
            {
                if (indirizziRepo.IsThereAdress(id) == false) 
                {
                    contattiRepo.Delete(id);
                    return new Esito { Messaggio = "Indirizzo cancellato correttamente", IsOk = true };
                }
                return new Esito { Messaggio = "Impossibile cancellare il contatto perchè ha associati degli indirizzi", IsOk = false };
            }
            return new Esito { Messaggio = "Non è possibile cancellare il contatto perchè non è presente nessun contatto associato all'ID", IsOk = false };
        }

        public List<Contatto> GetAllContacts() 
        {
            return contattiRepo.GetAll();
        }
    }
}
