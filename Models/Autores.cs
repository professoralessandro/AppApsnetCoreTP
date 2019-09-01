using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Models
{
    public class Autores
    {
        [Key]
        public Int32 AutorId { get; set; }

        public String Nome { get; set; }

        public String Email { get; set; }

        public String Genero { get; set; }

        public Int32 LivroId { get; set; }

    }
}
