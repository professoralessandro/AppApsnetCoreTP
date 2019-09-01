using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Models
{
    public class Livros
    {
        [Key]
        public Int32 LivroId { get; set; }

        public String nome { get; set; }

        public String autor { get; set; }

        public Decimal preco { get; set; }

        public Int32 quantidade { get; set; }

    }
}
