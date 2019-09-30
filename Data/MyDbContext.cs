using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
//using backend_adm.Models;
using basecs.Auxiliar.Exceptions;
using basecs.Models;
using Microsoft.EntityFrameworkCore;

namespace basecs.Data
{
    public class MyDbContext : DbContext
    {
        //Tabelas
        public DbSet<Bls> Bls { get; set; }
        public DbSet<Containers> Containers { get; set; }

        public MyDbContext(DbContextOptions options) :
            base(options)
        { }

        public override int SaveChanges()
        {
            var entities = (from entry in ChangeTracker.Entries() where entry.State == EntityState.Modified || entry.State == EntityState.Added select entry.Entity);

            ListStringException exs = new ListStringException();

            var validationResults = new List<ValidationResult>();

            foreach (var entity in entities)
            {
                if (!Validator.TryValidateObject(entity, new ValidationContext(entity), validationResults))
                {
                    foreach (ValidationResult result in validationResults)
                    {
                        result.ErrorMessage = result.ErrorMessage.Replace("The", "O campo").Replace(" field is required.", " é obrigatório.");

                        exs.TaskExceptions.Add(new Exception(result.ErrorMessage));
                    }
                }
            }

            if (exs.TaskExceptions.Count() > 0)
                throw exs;

            return base.SaveChanges();
        }
    }
}