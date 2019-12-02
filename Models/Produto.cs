using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace basecs.Models
{
    public partial class Produto
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(60)]
        public string Nome { get; set; }
        public decimal? Preco { get; set; }
        public bool? Ativo { get; set; }
        public int? IdUsuarioCadastro { get; set; }
        public int? IdUsuarioUpdate { get; set; }
    }
}
