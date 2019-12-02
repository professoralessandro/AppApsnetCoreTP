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
    public class ProdutoServico
    {
        private MyDbContext _context;

        public ProdutoServico(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> FindProdutosByProdutosId(int id)
        {
            try
            {
                return await this._context.Produtos.SingleOrDefaultAsync(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Produto." + ex.Message);
            }
        }
        public async Task<List<Produto>> ReturnListProdutosWithParameters(
            int? id,
            string nome,
            Boolean? ativo
            )
        {
            try
            {
                List<Produto> lstProdutos = await _context.Produtos.Where(c => (c.Id == id || id == null) &&
                   (c.Nome.Contains(nome) || nome == null) &&
                   (c.Ativo == ativo || ativo == null)
                   ).ToListAsync();

                return lstProdutos;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Produto: " + ex.Message);
            }

        }

        public async Task<Produto> UpdateProduto(Produto produto)
        {
            try
            {
                if (produto.Id == 0)
                    throw new KeyNotFoundException("Id");
                this._context.Update(produto);
                await this._context.SaveChangesAsync();
                return produto;
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
        public async Task<Produto> InsertProduto(Produto produto)
        {
            try
            {
                using (var context = this._context)
                {
                    context.Produtos.Add(produto);
                    await context.SaveChangesAsync();
                    return produto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Produto: " + ex.Message);
            }
        }
        public async Task<Produto> DeleteProduto(int id)
        {
            try
            {
                if (id == 0)
                    throw new KeyNotFoundException("Produto");

                Produto produto = await this.FindProdutosByProdutosId(id);

                produto.Ativo = false;

                await this.UpdateProduto(produto);

                return produto;
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