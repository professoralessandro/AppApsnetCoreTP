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
    public class ListasServico
    {
        private MyDbContext _context;

        public ListasServico(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Listas> FindListasByListasId(int id)
        {
            try
            {
                return await this._context.Listas.SingleOrDefaultAsync(c => c.ListaId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Lista." + ex.Message);
            }
        }
        public async Task<List<Listas>> ReturnListListasWithParameters(
            int? id,
            string nome
            )
        {
            try
            {
                List<Listas> lstListas = await _context.Listas.Where(c => (c.ListaId == id || id == null) &&
                   (c.Nome.Contains(nome) || nome == null)
                   ).ToListAsync();

                return lstListas;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Lista: " + ex.Message);
            }

        }

        public async Task<Listas> UpdateLista(Listas lista)
        {
            try
            {
                if (lista.ListaId == 0)
                    throw new KeyNotFoundException("ListaId");
                this._context.Update(lista);
                await this._context.SaveChangesAsync();
                return lista;
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
        public async Task<Listas> InsertLista(Listas listas)
        {
            try
            {
                using (var context = this._context)
                {
                    context.Listas.Add(listas);
                    await context.SaveChangesAsync();
                    return listas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Lista: " + ex.Message);
            }
        }
        public async Task<Listas> DeleteLista(int id)
        {
            try
            {
                if (id == 0)
                    throw new KeyNotFoundException("Lista");

                Listas listas = await this.FindListasByListasId(id);

                using (var context = this._context)
                {
                    context.Listas.Remove(listas);
                    await context.SaveChangesAsync();
                    return listas;
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