using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Totvs.Entidade
{
    public class Moedas
    {
        [Key]
        public Int64 Id { get; set; }
        public Double Valor { get; set; }
        public Int64 Qtd { get; set; }

        public List<Moedas> listaMoedas()
        {
            List<Moedas> lista = new List<Moedas>();
            lista.Add(new Moedas { Id = 1, Valor = 0.1, Qtd = 10 });
            lista.Add(new Moedas { Id = 2, Valor = 0.5, Qtd = 10 });
            lista.Add(new Moedas { Id = 3, Valor = 0.10, Qtd = 0 });
            lista.Add(new Moedas { Id = 4, Valor = 0.50, Qtd = 10 });
            return lista;
        }
    }
}
