using System;
using System.Collections.Generic;

namespace basecs.Models
{
    public partial class Livros
    {
        #region CONSTRUTOR
        public Livros()
        {
            Autores = new HashSet<Autores>();
            Listas = new HashSet<Listas>();
        }
        #endregion

        #region ATRIBUTOS
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public string Autor { get; set; }
        public string Resumo { get; set; }
        public string Capa { get; set; }
        public int? Quantidade { get; set; }
        #endregion

        #region IMPORTS
        public ICollection<Autores> Autores { get; set; }
        public ICollection<Listas> Listas { get; set; }
        #endregion
    }
}
