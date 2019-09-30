using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace basecs.Models
{
    public class Bls
    {
        [Key]
        public int BlId { get; set; }
        public int Numero { get; set; }
        public String Consignee { get; set; }
        public String Navio { get; set; }
    }
}
