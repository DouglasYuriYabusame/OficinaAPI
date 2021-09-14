using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
    [Table("servico")]
    public class Servico
    {
        [Key]
        [Column("idservico")]
        [Required(ErrorMessage = "O id não pode ser nulo")]
        public Int32 IdServico { get; set; }

        [Column("descricao")]

        public string Descricao { get; set; }

        [Column("preco")]
        public decimal Preco { get; set; }
        [Column("prazo")]
        public DateTime Prazo { get; set; }
        [Column("idatendimento")]
        [Required(ErrorMessage = "O id não pode ser nulo")]
        public int IdAtendimento { get; set; }


    }
}