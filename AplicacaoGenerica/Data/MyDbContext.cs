using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
//using basecs.Auxiliar.Exceptions;
//using basecs.Models;
using Microsoft.EntityFrameworkCore;

namespace AplicacaoGenerica.Data
{
    public class MyDbContext : DbContext
    {
        //public DbSet<Parametro> Parametros { get; set; }

        public MyDbContext(DbContextOptions options) :
            base(options)
        { }
    }
}
