using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace basecs.Auxiliar
{
    public class ModelPadrao
    {
        [Key]
        public Int64 Id { get; set; }

        [Required]
        public DateTime DataInclusao { get; set; }

        [Required]
        public DateTime DataUltimaAlteracao { get; set; }

        public DateTime? DataInativacao { get; set; }

        [Required]
        public Boolean Ativo { get; set; }
    }
}