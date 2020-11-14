using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Totvs.Entidade;
using Totvs.Repositorio;
using Totvs.Repositorio.Interfaces;
using Totvs.Servico;
using Totvs.Servico.Interfaces;

namespace Testes
{
    public class Tests
    {
        private readonly INotasServico servicoNotas;
        private readonly IMoedaServico servicoMoedas;
        private readonly ITransacaoServico servicoTransacao;

        public Tests()
        {
       
            var services = new ServiceCollection();
            services.AddTransient<IConexao, Conexao>();
            services.AddTransient<IMoedaServico, MoedaServico>();
            services.AddTransient<IMoedasRepositorio, MoedasRepositorio>();
            services.AddTransient<INotasServico, NotasServico>();
            services.AddTransient<INotasRepositorio, NotasRepositorio>();
            services.AddTransient<ITransacaoServico, TransacaoServico>();
            services.AddTransient<ITransacaoRepositorio, TransacaoRepositorio>();


            var provider = services.BuildServiceProvider();
            servicoNotas = provider.GetService<INotasServico>();
            servicoMoedas = provider.GetService<IMoedaServico>();
            servicoTransacao = provider.GetService<ITransacaoServico>();

        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var transacao = new Transacao();
            transacao.ValorCompra = 85.50;
            transacao.ValorEntregue = 100;
            transacao.DataTransacao = DateTime.Now;
            var xxx = new TrocoServico(servicoTransacao, servicoNotas, servicoMoedas).ObterTroco(transacao);

            Assert.AreNotEqual(xxx.ValorTroco , 0);
        }

       

    }
}