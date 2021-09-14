using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
    [Table("atendimento")]
    public class Atendimento
    {
        [Key]
        [Column("idatendimento")]
        [Required (ErrorMessage = "O campo id é obrigatório")]

        public Int32 IdAtendimento { get; set; }

        [Column("descricao")]

        public string Descricao { get; set; }

        [Column("idcliente")]
        [Required (ErrorMessage ="O campo id é obrigatório")]

        public int IdCliente { get; set; }
    }
}
