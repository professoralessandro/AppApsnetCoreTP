using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using basecs.Auxiliar.Padroes;
using basecs.Data;
using basecs.Models;
using basecs.Services;
using Microsoft.EntityFrameworkCore;

namespace basecs.Services
{
    public class LivrosServico
    {
        private MyDbContext _context;

        public LivrosServico(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Livros> FindLivrosByLivrosId(int id)
        {
            try
            {
                return await this._context.Livros.SingleOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Livro." + ex.Message);
            }
        }
        public async Task<List<Livros>> ReturnListLivrosWithParameters(
            int? id,
            string titulo,
            string autor
            )
        {
            try
            {
                autor = "";

                List<Livros> lstLivros = await _context.Livros.Where(c => (c.Id == id || id == null) &&
                   (c.Titulo.Contains(titulo) || titulo == null) &&
                   (c.Autor.Contains(autor) || autor == null)
                   ).ToListAsync();

                return lstLivros;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Livro: " + ex.Message);
            }

        }

        public async Task<Livros> UpdateLivro(Livros livro)
        {
            try
            {
                if (livro.Id == 0)
                    throw new KeyNotFoundException("LivroId");
                this._context.Update(livro);
                await this._context.SaveChangesAsync();
                return livro;
            }
            catch (KeyNotFoundException key)
            {
                throw new Exception("Um campo necessário para essa ação não foi informado: " + key.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar editar o registro: " + ex.Message);
            }
        }
        public async Task<Livros> InsertLivro(Livros livros)
        {
            try
            {
                using (var context = this._context)
                {
                    context.Livros.Add(livros);
                    await context.SaveChangesAsync();
                    return livros;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Livro: " + ex.Message);
            }
        }
        public async Task<Livros> DeleteLivro(int id)
        {
            try
            {
                if (id == 0)
                    throw new KeyNotFoundException("Livro");

                Livros livros = await this.FindLivrosByLivrosId(id);

                using (var context = this._context)
                {
                    context.Livros.Remove(livros);
                    await context.SaveChangesAsync();
                    return livros;
                }
            }
            catch (KeyNotFoundException key)
            {
                throw new Exception("Um campo necessário para essa ação não foi informado: " + key.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao tentar deletar o registro: " + ex.Message);
            }
        }
    }
}