using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totvs.Entidade;
using Totvs.Repositorio;
using Totvs.Servico.Interfaces;

namespace Totvs.Servico
{
    public partial class TrocoServico : ITrocoServico
    {
        List<Notas> NotasExistente;
        List<Moedas> MoedasExistente;

        private readonly INotasServico servicoNotas;
        private readonly IMoedaServico servicoMoedas;
        private readonly ITransacaoServico servicoTransacao;


        int r10 = 0, r20 = 0, r50 = 0, r100 = 0;
        int c1 = 0, c5 = 0, c10 = 0, c50 = 0;
        decimal parteInteira = 0;
        decimal parteFracionaria = 0;
        Boolean TrocoDisponivel = true;


        public TrocoServico(ITransacaoServico _servicoTransacao, INotasServico _servicoNotas, IMoedaServico _servicoMoedas)
        {
            servicoTransacao = _servicoTransacao;
               servicoNotas = _servicoNotas;
            servicoMoedas = _servicoMoedas;
        }
        public Transacao ObterTroco(Transacao transacao)
        {

            transacao.ValorTroco = transacao.ValorEntregue - transacao.ValorCompra;

            if (transacao.ValorTroco <= 0 )
            {
                transacao.Observacao = transacao.ValorTroco == 0? "Sem Troco ": "Faltando "+ transacao.ValorTroco.ToString("c").Replace("-", "");
                servicoTransacao.Salvar(transacao);
                return transacao;
            }


            NotasExistente = (List<Notas>)servicoNotas.Listar();
            MoedasExistente = (List<Moedas>)servicoMoedas.Listar();
            decimal Dinheiro = 0;


            Dinheiro =(decimal) transacao.ValorTroco;
             parteInteira = (int)Dinheiro;
             parteFracionaria = Math.Ceiling((Dinheiro - parteInteira) * 100);

            string ValoresTexto = "";


            TratarNota(parteInteira);
            TratarMoedas(parteFracionaria);


            if (!TrocoDisponivel)
            {
                transacao.Observacao = "Troco Não Disponivel";
                servicoTransacao.Salvar(transacao);
                return transacao;
            }


            if (r100 > 0)
            {
                var notas = NotasExistente.SingleOrDefault(s => s.Valor == 100);

                ValoresTexto += r100 + " R$ 100 |";
                RemoverNotas(notas);
            }
            if (r50 > 0)
            {
                var notas = NotasExistente.SingleOrDefault(s => s.Valor == 50);
                ValoresTexto += r50 + " R$ 50 |";
                RemoverNotas(notas);
               
            }
            if (r20 > 0)
            {
                var notas = NotasExistente.SingleOrDefault(s => s.Valor == 20);
                ValoresTexto += r20 + " R$ 20 |";
                RemoverNotas(notas);
               
            }
            if (r10 > 0)
            {

                var notas = NotasExistente.SingleOrDefault(s => s.Valor == 10);
                ValoresTexto += r10 + " R$ 10 ";
                RemoverNotas(notas);
               
            }


            if (c50 > 0)
            {

                var moeda = MoedasExistente.SingleOrDefault(s => s.Valor == 50);
                ValoresTexto += c50 + " R$ 0,50 |";
                RemoverMoedas(moeda);


            }           
            if (c10 > 0)
            {
                var moeda = MoedasExistente.SingleOrDefault(s => s.Valor == 10);
                ValoresTexto += c10 + " R$ 0,10 |";
                RemoverMoedas(moeda);
            }
            if (c5 > 0)
            {
                var moeda = MoedasExistente.SingleOrDefault(s => s.Valor == 5);
                ValoresTexto += c5 + " R$ 0,05 |";
                RemoverMoedas(moeda);

            }
            if (c1 > 0)
            {
                var moeda = MoedasExistente.SingleOrDefault(s => s.Valor == 1);
                ValoresTexto += c1 + " R$ 0,01 |";
                RemoverMoedas(moeda);

            }


            transacao.Observacao = "TROCO DE "+ transacao.ValorTroco.ToString("c") + "  MELHOR TROCO " + ValoresTexto;
            servicoTransacao.Salvar(transacao);
            return transacao;
        }

    }
}
