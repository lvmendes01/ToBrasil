using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totvs.Entidade;

namespace Totvs.Servico
{
    public partial class TrocoServico
    {
      
        public void TratarNota(decimal parteInteira)
        {
            while (parteInteira != 0)
            {
                if (parteInteira >= 100 && NotasExistente.SingleOrDefault(s => s.Valor == 100).Qtd > 0)
                {
                    parteInteira -= 100;
                    r100++;
                    NotasExistente.SingleOrDefault(s => s.Valor == 100).Qtd--;
                }
                else if (parteInteira >= 50 && NotasExistente.SingleOrDefault(s => s.Valor == 50).Qtd > 0)
                {
                    parteInteira -= 50;
                    r50++;
                    NotasExistente.SingleOrDefault(s => s.Valor == 50).Qtd--;
                }
                else if (parteInteira >= 20 && NotasExistente.SingleOrDefault(s => s.Valor == 20).Qtd > 0)
                {
                    parteInteira -= 20;
                    r20++;
                    NotasExistente.SingleOrDefault(s => s.Valor == 20).Qtd--;
                }
                else if (parteInteira >= 10 && NotasExistente.SingleOrDefault(s => s.Valor == 10).Qtd > 0)
                {
                    parteInteira -= 10;
                    r10++;
                    NotasExistente.SingleOrDefault(s => s.Valor == 10).Qtd--;
                }
                else if (parteInteira > 0)
                {


                    parteFracionaria = parteInteira * 100 + parteFracionaria;
                    parteInteira = 0;
                }
            }

        }

    }
}
