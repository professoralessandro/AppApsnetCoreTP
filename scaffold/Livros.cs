using System;
using System.Collections.Generic;

namespace basecs.Scaffold
{
    public partial class Livros
    {
        public Livros()
        {
            Autores = new HashSet<Autores>();
            Listas = new HashSet<Listas>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Autor { get; set; }
        public string Resumo { get; set; }
        public string Capa { get; set; }
        public int? Quantidade { get; set; }

        public ICollection<Autores> Autores { get; set; }
        public ICollection<Listas> Listas { get; set; }
    }
}
