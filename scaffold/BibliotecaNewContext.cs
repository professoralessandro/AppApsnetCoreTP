using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace basecs.scaffold
{
    public partial class BibliotecaNewContext : DbContext
    {
        public BibliotecaNewContext()
        {
        }

        public BibliotecaNewContext(DbContextOptions<BibliotecaNewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<Listas> Listas { get; set; }
        public virtual DbSet<Livros> Livros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=BibliotecaNew;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autores>(entity =>
            {
                entity.HasKey(e => e.AutorId);

                entity.Property(e => e.AutorId).HasColumnName("autorId");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasColumnName("genero")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.LivroId).HasColumnName("livroId");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.Autores)
                    .HasForeignKey(d => d.LivroId)
                    .HasConstraintName("fk_livros");
            });

            modelBuilder.Entity<Listas>(entity =>
            {
                entity.HasKey(e => e.ListaId);

                entity.Property(e => e.LivroId).HasColumnName("livroId");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.Listas)
                    .HasForeignKey(d => d.LivroId)
                    .HasConstraintName("fk_livros_Lista");
            });

            modelBuilder.Entity<Livros>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Autor)
                    .HasColumnName("autor")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Capa)
                    .HasColumnName("capa")
                    .IsUnicode(false);

                entity.Property(e => e.Quantidade).HasColumnName("quantidade");

                entity.Property(e => e.Resumo)
                    .HasColumnName("resumo")
                    .IsUnicode(false);

                entity.Property(e => e.Subtitulo)
                    .HasColumnName("subtitulo")
                    .IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .IsUnicode(false);
            });
        }
    }
}
