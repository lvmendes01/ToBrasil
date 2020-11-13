using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totvs.Entidade;
using Totvs.Servico.Interfaces;

namespace Totvs.Servico
{
    public partial class TrocoServico : ITrocoServico
    {
        List<Notas> NotasExistente = new Notas().listaNotas();
        List<Moedas> MoedasExistente = new Moedas().listaMoedas();

        public Transacao ObterTroco(Transacao transacao)
        {
            decimal Dinheiro = 0;
            int r10 = 0, r20 = 0, r50 = 0, r100 = 0;
            int c1 = 0, c5 = 0, c10 = 0, c50 = 0;


            Dinheiro =(decimal) transacao.ValorTroco;
            decimal parteInteira = (int)Dinheiro;
            decimal parteFracionaria = Math.Ceiling((Dinheiro - parteInteira) * 100);
            transacao.NotasUtilizada = new List<TransacaoNota>();
            transacao.MoedasUtilizada = new List<TransacaoMoeda>();



            // Loop para converter a parte inteira em cédulas
            while (parteInteira != 0)
            {
                if (parteInteira >= 100 && NotasExistente.SingleOrDefault(s=>s.Id == 4).Qtd > 0)
                {
                    parteInteira -= 100;
                    r100++;
                }
                else if (parteInteira >= 50 && NotasExistente.SingleOrDefault(s => s.Id == 3).Qtd > 0)
                {
                    parteInteira -= 50;
                    r50++;
                }
                else if (parteInteira >= 20 && NotasExistente.SingleOrDefault(s => s.Id == 2).Qtd > 0)
                {
                    parteInteira -= 20;
                    r20++;
                }
                else if (parteInteira >= 10 && NotasExistente.SingleOrDefault(s => s.Id == 1).Qtd > 0)
                {
                    parteInteira -= 10;
                    r10++;
                }
            }


            while (parteFracionaria != 0)
            {
                if (parteFracionaria >= 50 && MoedasExistente.SingleOrDefault(s => s.Id == 4).Qtd > 0)
                {
                    parteFracionaria -= 50;
                    c50++;
                }
                                            
                else if (parteFracionaria >= 10 && MoedasExistente.SingleOrDefault(s => s.Id ==3).Qtd > 0)
                {
                    parteFracionaria -= 10;
                    c10++;
                }
                else if (parteFracionaria >= 5 && MoedasExistente.SingleOrDefault(s => s.Id == 2).Qtd > 0)
                {
                    parteFracionaria -= 5;
                    c5++;
                }
                else if (parteFracionaria >= 1 && MoedasExistente.SingleOrDefault(s => s.Id == 1).Qtd > 0)
                {
                    parteFracionaria -= 1;
                    c1++;
                }

            }


            if (r100 > 0)
            {
                var notascem = new Notas
                {
                    Valor = 100,
                    Qtd = r100,
                    Id = 4
                };
                RemoverNotas(notascem);
            }
            if (r50 > 0)
            {
                var notascem = new Notas
                {
                    Valor = 50,
                    Qtd = r50,
                    Id = 3
                };
                RemoverNotas(notascem);
               
            }
            if (r20 > 0)
            {
                var notascem = new Notas
                {
                    Valor = 20,
                    Qtd = r20,
                    Id = 2
                };
                RemoverNotas(notascem);
               
            }
            if (r10 > 0)
            {
                var notascem = new Notas
                {
                    Valor = 10,
                    Qtd = r10,
                    Id = 1
                };
                RemoverNotas(notascem);
               
            }


            if (c50 > 0)
            {

                var notascem = new Moedas
                {
                    Valor = 0.50,
                    Qtd = c50,
                    Id = 4
                };
                RemoverMoedas(notascem);


            }           
            if (c10 > 0)
            {
                var notascem = new Moedas
                {
                    Valor = 0.10,
                    Qtd = c10,
                    Id = 4
                };
                RemoverMoedas(notascem);
            }
            if (c5 > 0)
            {
               
            }
            if (c1 > 0)
            {
               
            }

            return transacao;
        }

    }
}
