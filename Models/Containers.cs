using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace basecs.Models
{
    public class Containers
    {
        [Key]
        public int ContainerId { get; set; }
        public int Numero { get; set; }
        public String Tipo { get; set; }
        public decimal Tamanho { get; set; }
        public int BlId { get; set; }
    }
}
