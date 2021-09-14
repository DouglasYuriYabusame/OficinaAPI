using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
    [Table("funcionario")]
    public class Funcionario
    {
       [Key]
       [Column("idfuncionario")]
       [Required (ErrorMessage = "O id não pode ser nulo")]
       public Int32 IdFuncionario { get; set; }

        [Column("nome")]

        public string Nome { get; set; }

        [Column("idoficina")]
        [Required(ErrorMessage = "o id não pode ser nulo")]

        public int IdOficina { get; set; }

    }
}
