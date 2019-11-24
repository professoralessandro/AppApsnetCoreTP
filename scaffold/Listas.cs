using System;
using System.Collections.Generic;

namespace basecs.scaffold
{
    public partial class Listas
    {
        public int ListaId { get; set; }
        public string Nome { get; set; }
        public int? LivroId { get; set; }

        public Livros Livro { get; set; }
    }
}
