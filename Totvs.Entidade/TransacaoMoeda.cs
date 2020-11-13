using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Totvs.Entidade
{
    public class TransacaoMoeda
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 TransacaoId { get; set; }
        public Int64 MoedaId { get; set; }
        public Int64 Qtdade { get; set; }
        public DateTime DataRegistro { get; set; }
    }
}
