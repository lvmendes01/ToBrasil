using System;
using System.Collections.Generic;
using System.Text;
using Totvs.Entidade;

namespace Totvs.Servico.Interfaces
{
    public interface ITrocoServico
    {
        Transacao ObterTroco(Transacao transacao);
        String AdicionarMoeda(Moedas moedas);
        String RemoverMoedas(Moedas moedas);
        String AdicionarNotas(Notas notas);
        String RemoverNotas(Notas notas);
    }
}
