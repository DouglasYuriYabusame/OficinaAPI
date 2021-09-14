using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
   [Table("tipo_pagamento")]
    public class TipoPagamento
    {
        [Key]
        [Column("idtipo_pagamento")]
        [Required(ErrorMessage = "O campo id é obrigatório")]

        public Int32 IdTipo_Pagamento{ get; set; }
        [Column("parcela")]
        public decimal Parcela { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("idatendimento")]
        [Required(ErrorMessage = "O campo id é obrigatório")]
        public int IdAtendimento { get; set; }
    }
}