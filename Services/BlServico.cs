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
    public class BlServico
    {
        private MyDbContext _context;

        public BlServico(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Bls> FindBlByBlId(int blId)
        {
            try
            {
                return this._context.Bls.SingleOrDefault(c => c.BlId == blId);
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao buscar o Bl." + ex.Message);
            }
        }
        public async Task<List<Bls>> ReturnListBlWithParameters(
            Int32? blId,
            String consignatario)
        {
            try
            {
                List<Bls> lstBl = await _context.Bls.Where(c => (c.BlId == blId || blId == null) &&
                   (c.Consignee.Contains(consignatario) || consignatario == null)).ToListAsync();

                return lstBl;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível realizar a busca por Bl: " + ex.Message);
            }

        }

        public async Task<Bls> UpdateBl(Bls bl)
        {
            try
            {
                if (bl.BlId == 0)
                    throw new KeyNotFoundException("BlId");
                this._context.Update(bl);
                this._context.SaveChanges();
                return bl;
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
        public async Task<Bls> InsertBl(Bls bls)
        {
            try
            {
                using (var context = this._context)
                {
                    context.Bls.Add(bls);
                    context.SaveChanges();
                    return bls;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao incluir Bl: " + ex.Message);
            }
        }
        public async Task<Bls> DeleteBl(int blId)
        {
            try
            {
                if (blId == 0)
                    throw new KeyNotFoundException("Bl");

                Bls bls = await this.FindBlByBlId(blId);

                using (var context = this._context)
                {
                    context.Bls.Remove(bls);
                    context.SaveChanges();
                    return bls;
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