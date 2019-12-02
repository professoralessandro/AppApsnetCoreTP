using System;
using System.Collections.Generic;

namespace basecs.Scaffold
{
    public partial class Autores
    {
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public int? LivroId { get; set; }

        public Livros Livro { get; set; }
    }
}
