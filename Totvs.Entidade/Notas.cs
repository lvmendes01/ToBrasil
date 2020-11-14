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

       

      
    }
}
