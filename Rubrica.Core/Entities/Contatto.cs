using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.Entities
{
    public class Contatto
    {
        public int IdContatto { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public List<Indirizzo> ListaIndirizzi { get; set; } = new List<Indirizzo>(); //di fatto non la uso

                
        public override string ToString()
        {
            return $"{IdContatto} - {Nome} - {Cognome}";
        }
    }
}
