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
               
                servicoMoedas.Atualizar(moedas);
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
              
                servicoNotas.Atualizar(notas);
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
              
                servicoMoedas.Atualizar(moedas);
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
                servicoNotas.Atualizar(notas);
                return "Ok";
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
