using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
    [Table("carro")]
    public class Carro
    {
        [Key]
        [Column("idcarro")]
        [Required(ErrorMessage = "O campo id é obrigatório")]

        public Int32 IdCarro { get; set; }
        [Column("descricao")]

        public string Descricao { get; set; }
        [Column("placa")]

        public string Placa { get; set; }

        [Column("idcliente")]
        [Required(ErrorMessage = "O campo id é obrigatório")]
        public Int32 IdCliente { get; set; }
    }
}
