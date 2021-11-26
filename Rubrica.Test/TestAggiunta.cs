using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryMock;
using System;
using System.Collections.Generic;
using Xunit;

namespace Rubrica.Test
{
    
    public class TestAggiunta
    {
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryMockContatti(), new RepositoryMockIndirizzi());
        [Fact]
        public void Test1()
        {
            
            List<Contatto> contatti = bl.GetAllContacts();
            int numeroContatti = contatti.Count;

            
            Contatto nuovoContatto = new Contatto();
            nuovoContatto.Nome = "Mario";
            nuovoContatto.Cognome = "Rossi";
            
            contatti.Add(nuovoContatto);

            Assert.True(contatti.Count == numeroContatti + 1);



        }
    }
}
