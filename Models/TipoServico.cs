using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaVesp.Models
{
    [Table("tipo_servico")]
    public class TipoServico
    {
        [Key]
        [Column("idtipo_servico")]
        [Required(ErrorMessage = "O campo id é obrigatório")]
        public Int32 IdTipo_Servico { get; set; }
        [Column("idfuncionario")]
        [Required(ErrorMessage = "O campo id é obrigatório")]
        public Int32 IdFuncionario { get; set; }
        [Column("idservico")]
        [Required(ErrorMessage = "O campo id é obrigatório")]
        public Int32 IdServico { get; set; }
    }
}
