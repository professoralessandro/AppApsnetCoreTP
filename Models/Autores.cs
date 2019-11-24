using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace basecs.Models
{
    public partial class Autores
    {
        #region ATRIBUTOS
        [Key]
        public int AutorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        [ForeignKey("LivroId")]
        public int? LivroId { get; set; }
        #endregion

        #region IMPORTS
        public Livros Livro { get; set; }
        #endregion
    }
}
