using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryADO;
using Rubrica.RepositoryMock;
using System;
using System.Collections.Generic;

namespace Rubrica.Presentation
{
    class Program
    {
        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryMockContatti(), new RepositoryMockIndirizzi());
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryADOContatti(), new RepositoryADOIndirizzi());
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nella rubrica!");
            bool continua = true;
            do
            {
                Console.WriteLine("\n**********Menù**********");
                Console.WriteLine("[1] Visualizza tutti i contatti");
                Console.WriteLine("[2] Aggiungi un contatto");
                Console.WriteLine("[3] Aggiungi un indirizzo");
                Console.WriteLine("[4] Elimina un contatto");
                Console.WriteLine("[5] Esci");

                int scelta;
                do
                {
                    Console.WriteLine("Fai la tua scelta");
                }
                while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 4));

                switch (scelta)
                {
                    case 1:
                        VisualizzaContatti();
                        break;
                    case 2:
                        AggiungiContatto();
                        break;
                    case 3:
                        AggiungiIndirizzo();
                        break;                       
                    case 4:
                        EliminaContatto();
                        break;
                    case 0:
                        continua = false;
                        Console.WriteLine("Arrivederci");
                        break;
                }
            }
            while (continua == true);
        }

        private static void EliminaContatto()
        {
            Console.WriteLine("Ecco l'elenco dei contatti");
            VisualizzaContatti();
            int idContatto;
            do
            {
                Console.WriteLine("Inserisci l'ID del contatto che si desidera eliminare");
            }
            while (!(int.TryParse(Console.ReadLine(), out idContatto) && idContatto > 0));
            Esito esito = bl.DeleteContact(idContatto);
            Console.WriteLine(esito.Messaggio);
        }

        private static void AggiungiIndirizzo()
        {
            Console.WriteLine("Inserisci la tipologia");
            string tipologia = Console.ReadLine();
            Console.WriteLine("Inserisci la via");
            string via = Console.ReadLine();
            Console.WriteLine("Inserisci la città");
            string citta = Console.ReadLine();
            Console.WriteLine("Inserisci il cap");
            string cap = Console.ReadLine();
            Console.WriteLine("Inserisci la provincia");
            string provincia = Console.ReadLine();
            Console.WriteLine("Inserisci la nazione");
            string nazione = Console.ReadLine();
            int idContatto;
            do
            {
                Console.WriteLine("Inserisci l'ID del contatto");
            }
            while (!(int.TryParse(Console.ReadLine(), out idContatto) && idContatto > 0));

            Indirizzo nuovoIndirizzo = new Indirizzo();

            nuovoIndirizzo.Tipologia = "Domicilio";
            nuovoIndirizzo.Via = via;
            nuovoIndirizzo.Citta = citta;
            nuovoIndirizzo.Cap = cap;
            nuovoIndirizzo.Nazione = nazione;
            nuovoIndirizzo.Provincia = provincia;
            nuovoIndirizzo.IdContatto = idContatto;
            Esito esito = bl.AddAdress(nuovoIndirizzo);
            Console.WriteLine(esito.Messaggio);
        }

        private static void AggiungiContatto()
        {
            Console.WriteLine("Inserire il nome del nuovo contatto");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserire il cognome del nuovo contatto");
            string cognome = Console.ReadLine();
            Contatto nuovoContatto = new Contatto();
            nuovoContatto.Nome = nome;
            nuovoContatto.Cognome = cognome;
            Esito esito = bl.AddContact(nuovoContatto);
            Console.WriteLine(esito.Messaggio);         
        }

        private static void VisualizzaContatti()
        {
            List<Contatto> contatti = bl.GetAllContacts();
            if (contatti.Count != 0)
            {
                foreach (var item in contatti)
                {
                    Console.WriteLine(item.ToString());                    
                }
            }
            else
            {
                Console.WriteLine("Non sono presenti contatti");
            }           
        }
    }
}
