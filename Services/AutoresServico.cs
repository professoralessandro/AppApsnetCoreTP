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
    public class AutoresServico
    {
        private MyDbContext _context;

        public AutoresServico(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Autores> FindAutoresByAutoresId(int autorId)
        {
            try
            {
                return await this._context.Autores.SingleOrDefaultAsync(c => c.AutorId == autorId);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Autor." + ex.Message);
            }
        }
        public async Task<List<Autores>> ReturnListAutoresWithParameters(
        Int32? autorId,
        string nome,
        string email)
        {
            try
            {

                List<Autores> lstAutores = await _context.Autores.Where(c => (c.AutorId == autorId || autorId == null) &&
                   (c.Nome.Contains(nome) || nome == null) &&
                   (c.Email.Contains(email) || email == null)).ToListAsync();

                return lstAutores;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Autor: " + ex.Message);
            }

        }

        public async Task<Autores> UpdateAutor(Autores autor)
        {
            try
            {
                if (autor.AutorId == 0)
                    throw new KeyNotFoundException("AutorId");
                this._context.Update(autor);
                await this._context.SaveChangesAsync();
                return autor;
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
        public async Task<Autores> InsertAutor(Autores autors)
        {
            try
            {
                using (var context = this._context)
                {
                    context.Autores.Add(autors);
                    await context.SaveChangesAsync();
                    return autors;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Autor: " + ex.Message);
            }
        }
        public async Task<Autores> DeleteAutor(int id)
        {
            try
            {
                if (id == 0)
                    throw new KeyNotFoundException("Autor");

                Autores autor = await this.FindAutoresByAutoresId(id);

                using (var context = this._context)
                {
                    context.Autores.Remove(autor);
                    await context.SaveChangesAsync();
                    return autor;
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
        }//DELETAR
    }
}