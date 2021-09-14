using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
    [Table("marca")]
    public class Marca
    {
        [Key]
        [Column("idmarca")]
        [Required(ErrorMessage = "O id não pode ser nulo")]
        public Int32 IdMarca { get; set; }

        [Column("nome")]

        public string Nome { get; set; }

        [Column("idcarro")]
        [Required(ErrorMessage = "o id não pode ser nulo")]

        public int IdCarro { get; set; }

    }
}