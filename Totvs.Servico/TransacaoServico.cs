using System;
using System.Collections.Generic;
using System.Text;
using Totvs.Entidade;
using Totvs.Repositorio;
using Totvs.Servico.Interfaces;

namespace Totvs.Servico
{
    public class TransacaoServico : ITransacaoServico
    {
        private readonly ITransacaoRepositorio repositorio;
        public TransacaoServico(ITransacaoRepositorio _repositorio)
        {
            repositorio = _repositorio;
        }
        public string Atualizar(Transacao o)
        {
            return repositorio.Atualizar(o);
        }

        public Transacao Carregar(long i)
        {
            return repositorio.Carregar(i);
        }

        public string Delete(Transacao o)
        {
            return repositorio.Delete(o);
        }

        public IList<Transacao> Listar()
        {
            return repositorio.Listar();
        }

        public string Salvar(Transacao o)
        {
            return repositorio.Salvar(o);
        }
    }
}
