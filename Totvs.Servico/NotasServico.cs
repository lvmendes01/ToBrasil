using System;
using System.Collections.Generic;
using System.Text;
using Totvs.Entidade;
using Totvs.Repositorio;
using Totvs.Servico.Interfaces;

namespace Totvs.Servico
{
    public class NotasServico : INotasServico
    {
        private readonly INotasRepositorio repositorio;
        public NotasServico(INotasRepositorio _repositorio)
        {
            repositorio = _repositorio;
        }

        public string Atualizar(Notas o)
        {
            return repositorio.Atualizar(o);
        }

        public Notas Carregar(long i)
        {
            return repositorio.Carregar(i);
        }

        public string Delete(Notas o)
        {
            return repositorio.Delete(o);
        }

        public IList<Notas> Listar()
        {
            return repositorio.Listar();
        }

        public string Salvar(Notas o)
        {
            return repositorio.Salvar(o);
        }
    }
}
