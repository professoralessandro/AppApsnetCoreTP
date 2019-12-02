using System;
using System.Collections.Generic;

namespace basecs.Scaffold
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal? Preco { get; set; }
        public short? Ativo { get; set; }
        public int? IdUsuarioCadastro { get; set; }
        public int? IdUsuarioUpdate { get; set; }
    }
}
