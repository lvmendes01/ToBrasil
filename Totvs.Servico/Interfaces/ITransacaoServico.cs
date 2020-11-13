using System;
using System.Collections.Generic;
using System.Text;
using Totvs.Entidade;
using Totvs.Repositorio;

namespace Totvs.Servico.Interfaces
{
    public interface ITransacaoServico : ICrud<Int64, Transacao>
    {
    }
}
