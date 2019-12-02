using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace basecs.Models
{
    public partial class Usuario
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(60)]
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
