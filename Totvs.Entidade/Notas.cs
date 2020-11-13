using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Totvs.Entidade
{
    public class Notas
    {
        [Key]
        public Int64 Id { get; set; }
        public double Valor { get; set; }
        public Int64 Qtd { get; set; }

       

        public List<Notas> listaNotas()
        {
            List<Notas> lista = new List<Notas>();
            lista.Add(new Notas { Id= 1, Valor = 10, Qtd = 10 });
            lista.Add(new Notas { Id = 2, Valor = 20, Qtd = 10 });
            lista.Add(new Notas { Id = 3, Valor = 50, Qtd = 10 });
            lista.Add(new Notas { Id = 4, Valor = 100, Qtd = 10 });
            return lista;
        }
    }
}
