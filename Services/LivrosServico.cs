using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using basecs.Auxiliar.Padroes;
using basecs.Data;
using basecs.Models;
using basecs.Services;

namespace basecs.Services
{
    public class LivrosServico
    {
        private MyDbContext _context;

        public LivrosServico(MyDbContext context)
        {
            _context = context;
        }

        public Livros FindLivrosByLivrosId(int livroId)
        {
            try
            {
                return this._context.Livros.SingleOrDefault(c => c.LivroId == livroId);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Livro." + ex.Message);
            }
        }
        public List<Livros> ReturnListLivrosWithParameters(
        int? livroId,
        string autor
        )
        {
            try
            {
                autor = "";

                List<Livros> lstLivros = _context.Livros.Where(c => (c.LivroId == livroId || livroId == null) &&
                   (c.autor.Contains(autor) || autor == null)).ToList();

                return lstLivros;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Livro: " + ex.Message);
            }

        }

        public Livros UpdateLivro(Livros livro)
        {
            try
            {
                if (livro.LivroId == 0)
                    throw new KeyNotFoundException("LivroId");
                this._context.Update(livro);
                this._context.SaveChanges();
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
        public Livros InsertLivro(Livros livros)
        {
            try
            {
                using (var context = this._context)
                {
                    /*
                    if (sede.Imagem != null && sede.Imagem.Trim() != string.Empty)
                    {
                        sede.Imagem = common.Base64ToFile(sede.Imagem);
                    }
                    */
                    context.Livros.Add(livros);
                    context.SaveChanges();
                    return livros;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Livro: " + ex.Message);
            }
        }
        /*
        public void DeleteLivro(int livroId)
        {
            try
            {
                if (livroId == 0)
                    throw new KeyNotFoundException("Livro");

                Livros livros = this.FindLivrosByLivrosId(livroId);
                livros.Ativo = false;

                this.UpdateLivro(livros);
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
        */
    }
}