using System;
using System.Collections.Generic;
using System.Text;
using Totvs.Entidade;
using Totvs.Repositorio;
using Totvs.Servico.Interfaces;

namespace Totvs.Servico
{
    public class MoedaServico : IMoedaServico
    {
        private readonly IMoedasRepositorio repositorio;
        public MoedaServico(IMoedasRepositorio _repositorio)
        {
            repositorio = _repositorio;
        }

        public string Atualizar(Moedas o)
        {
            throw new NotImplementedException();
        }

        public Moedas Carregar(long i)
        {
            throw new NotImplementedException();
        }

        public string Delete(Moedas o)
        {
            throw new NotImplementedException();
        }

        public IList<Moedas> Listar()
        {
            return repositorio.Listar();
        }

        public string Salvar(Moedas o)
        {
            return repositorio.Salvar(o);
        }
    }
}
