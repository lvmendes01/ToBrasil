using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Totvs.Entidade
{
   public  class Transacao
    {
        [Key]
        public Int64 Id { get; set; }
        public DateTime DataTransacao { get; set; }
        public double ValorCompra { get; set; }
        public double ValorEntregue { get; set; }
        public double ValorTroco { get; set; }
        public String Observacao { get; set; }
    }
}
