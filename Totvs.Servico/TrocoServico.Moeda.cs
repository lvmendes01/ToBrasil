using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totvs.Entidade;

namespace Totvs.Servico
{
    public partial class TrocoServico
    {
        public void TratarMoedas(decimal parteFracionaria)
        {
            while (parteFracionaria != 0)
            {
                if (parteFracionaria >= 50 && MoedasExistente.SingleOrDefault(s => s.Valor == 50).Qtd > 0)
                {
                    parteFracionaria -= 50;
                    c50++;
                    MoedasExistente.SingleOrDefault(s => s.Valor == 50).Qtd--;
                }

                else if (parteFracionaria >= 10 && MoedasExistente.SingleOrDefault(s => s.Valor == 10).Qtd > 0)
                {
                    parteFracionaria -= 10;
                    c10++;
                    MoedasExistente.SingleOrDefault(s => s.Valor == 10).Qtd--;
                }
                else if (parteFracionaria >= 5 && MoedasExistente.SingleOrDefault(s => s.Valor == 5).Qtd > 0)
                {
                    parteFracionaria -= 5;
                    c5++;
                    MoedasExistente.SingleOrDefault(s => s.Valor == 5).Qtd--;
                }
                else if (parteFracionaria >= 1 && MoedasExistente.SingleOrDefault(s => s.Valor == 1).Qtd > 0)
                {
                    parteFracionaria -= 1;
                    c1++;
                    MoedasExistente.SingleOrDefault(s => s.Valor == 1).Qtd--;
                }
                else if (parteFracionaria > 0)
                {
                    TrocoDisponivel = false;
                    parteFracionaria = 0;
                }

            }

        }

    }
}
