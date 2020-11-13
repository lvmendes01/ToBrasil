using NUnit.Framework;
using System;
using System.Collections.Generic;
using Totvs.Entidade;
using Totvs.Servico;

namespace Testes
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var transacao = new Transacao();
            transacao.ValorTroco = 10.42;
            var xxx = new TrocoServico().ObterTroco(transacao);



            Assert.Pass();
        }


       
       
    }
}