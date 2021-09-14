using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [Column("idcliente")]
        [Required(ErrorMessage = "O campo id é obrigatório")]

        public Int32 IdCliente { get; set; }
        [Column("nome")]

        public string Nome { get; set; }
        [Column("email")]

        public string Email { get; set; }
        
    }
}
