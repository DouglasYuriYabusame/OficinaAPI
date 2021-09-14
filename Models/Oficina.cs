using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
    [Table("oficina")]
    public class Oficina
    {
        [Key]
        [Column("idoficina")]
        [Required(ErrorMessage ="O campo id é obrigatório")]

        public Int32 IdOficina {get;set;}
        [Column("nome")]

        public string Nome { get; set; }
    }
}
