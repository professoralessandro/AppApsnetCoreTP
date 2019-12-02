using System;
using System.Collections.Generic;

namespace basecs.Scaffold
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public short? Ativo { get; set; }
    }
}
