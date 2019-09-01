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
    public class AutoresServico
    {
        private MyDbContext _context;

        public AutoresServico(MyDbContext context)
        {
            _context = context;
        }

        public Autores FindAutoresByAutoresId(int autorId)
        {
            try
            {
                return this._context.Autores.SingleOrDefault(c => c.AutorId == autorId);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Autor." + ex.Message);
            }
        }
        public List<Autores> ReturnListAutoresWithParameters(
        Int32? autorId,
        string nome,
        string email)
        {
            try
            {

                List<Autores> lstAutores = _context.Autores.Where(c => (c.AutorId == autorId || autorId == null) &&
                   (c.Nome.Contains(nome) || nome == null) &&
                   (c.Email.Contains(email) || email == null)).ToList();

                return lstAutores;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Autor: " + ex.Message);
            }

        }

        public Autores UpdateAutor(Autores autor)
        {
            try
            {
                if (autor.AutorId == 0)
                    throw new KeyNotFoundException("AutorId");
                this._context.Update(autor);
                this._context.SaveChanges();
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
        public Autores InsertAutor(Autores autors)
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
                    context.Autores.Add(autors);
                    context.SaveChanges();
                    return autors;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Autor: " + ex.Message);
            }
        }
        /*
        public void DeleteAutor(int autorId)
        {
            try
            {
                if (autorId == 0)
                    throw new KeyNotFoundException("Autor");

                Autores autors = this.FindAutoresByAutoresId(autorId);
                autors.Ativo = false;

                this.UpdateAutor(autors);
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
        */
    }
}