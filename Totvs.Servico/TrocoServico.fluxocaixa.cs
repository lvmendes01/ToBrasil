using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Totvs.Entidade;

namespace Totvs.Servico
{
    public partial class TrocoServico
    {
        public string AdicionarMoeda(Moedas moedas)
        {
            try
            {
                MoedasExistente.Single(s => s.Id == moedas.Id).Qtd = +moedas.Qtd;
                return "Ok";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string AdicionarNotas(Notas notas)
        {
            try
            {
                NotasExistente.Single(s => s.Id == notas.Id).Qtd = +notas.Qtd;
                return "Ok";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

  
        public string RemoverMoedas(Moedas moedas)
        {
            try
            {
                MoedasExistente.Single(s => s.Id == moedas.Id).Qtd =- moedas.Qtd;
                return "Ok";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string RemoverNotas(Notas notas)
        {
            try
            {
                NotasExistente.Single(s => s.Id == notas.Id).Qtd =- notas.Qtd;
                return "Ok";
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
