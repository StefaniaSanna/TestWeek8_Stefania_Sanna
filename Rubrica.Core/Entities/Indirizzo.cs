using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.Entities
{
    public class Indirizzo
    {
        public int IdIndirizzo { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Citta { get; set; }
        public string Cap { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }
        public int IdContatto { get; set; }
        public Contatto Contatto { get; set; }

        public override string ToString()
        {
            return $"{IdIndirizzo} - {Tipologia} - {Via} - {Citta} - {Cap} - {Provincia} - {Nazione}";
        }
    }
}
